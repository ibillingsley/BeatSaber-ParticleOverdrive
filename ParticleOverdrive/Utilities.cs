using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ParticleOverdrive
{
    public delegate ref U RefGetter<T, U>(T obj);
    public static class Utilities
    {
        /// <summary>
        /// Creates a delegate to retrieve a reference to an object's private field (very fast).
        /// </summary>
        /// <typeparam name="T"><see cref="Type"/> of class the private field belongs to.</typeparam>
        /// <typeparam name="U"><see cref="Type"/> of the private field.</typeparam>
        /// <param name="s_field">Name of the private field</param>
        /// <returns><see cref="RefGetter{T, U}"/> delegate to reference the private field.</returns>
        /// <remarks>From: https://stackoverflow.com/a/45046664 </remarks>
        public static RefGetter<T, U> CreateRefGetter<T, U>(string s_field)
        {
            const BindingFlags bf = BindingFlags.NonPublic |
                                    BindingFlags.Instance |
                                    BindingFlags.DeclaredOnly;

            var fi = typeof(T).GetField(s_field, bf);
            if (fi == null)
                throw new MissingFieldException(typeof(T).Name, s_field);

            var s_name = "__refget_" + typeof(T).Name + "_fi_" + fi.Name;

            // workaround for using ref-return with DynamicMethod:
            //   a.) initialize with dummy return value
            var dm = new DynamicMethod(s_name, typeof(U), new[] { typeof(T) }, typeof(T), true);

            //   b.) replace with desired 'ByRef' return value
            var f_returnType = dm.GetType().GetField("m_returnType", bf);
            if (f_returnType == null)
                f_returnType = dm.GetType().GetField("returnType", bf); // For Unity/Mono

            f_returnType.SetValue(dm, typeof(U).MakeByRefType());


            var il = dm.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldflda, fi);
            il.Emit(OpCodes.Ret);

            return (RefGetter<T, U>)dm.CreateDelegate(typeof(RefGetter<T, U>));
        }
    }
}
