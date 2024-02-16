using System;
using System.Reflection;
using BindingFlags = System.Reflection.BindingFlags;

namespace s21_d07_ex03
{
    public class TypeFactory<T> where T : class
    {
        public T CreateWithConstructor()
        {
            var type = typeof(T);
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null,
                CallingConventions.HasThis, Array.Empty<Type>(), null);
            return (T)constructor.Invoke(null);
        }

        public T CreateWithActivator()
        {
            return Activator.CreateInstance<T>();
        }

        public T CreateWithParameters(in object[] parameters)
        {
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }
    }
}