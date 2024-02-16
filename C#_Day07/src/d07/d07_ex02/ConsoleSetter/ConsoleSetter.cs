using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace s21_d07_ex02
{
    public class ConsoleSetter<T> where T : class
    {
        public void SetValues(T input)
        {
            var type = input.GetType();
            Console.WriteLine($"Let's set {type.Name}!");
            var properties = type.GetProperties()
                .Where(property => property.GetCustomAttribute<NoDisplayAttribute>() == null);
            foreach (var property in properties)
            {
                var description = property.GetCustomAttribute<DescriptionAttribute>();
                if (description != null)
                    Console.WriteLine($"Set {description.Description}:");
                else
                    Console.WriteLine($"Set {property.Name}:");
                var propertyType = property.PropertyType;
                var inputLine = Console.ReadLine();
                if (string.IsNullOrEmpty(inputLine) 
                    && property.GetCustomAttribute<DefaultValueAttribute>() is { } defaultValue)
                {
                    property.SetValue(input, defaultValue.Value);
                    continue;
                }
                if (propertyType == typeof(string))
                {
                    property.SetValue(input, inputLine);
                    continue;
                }
                var parser = propertyType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static);
                if (parser == null)
                    throw new Exception("Property has no parser");
                object tempValue;
                tempValue = parser.Invoke(null, new object[] { inputLine });
                property.SetValue(input, tempValue);
                
            }
            Console.WriteLine("\nWe've set our instance!");
        }
    }
}