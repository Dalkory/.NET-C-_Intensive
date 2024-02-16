using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Http;

var httpContext = new DefaultHttpContext();
var type = httpContext.GetType();
Console.WriteLine($"Type: {type.FullName}{Environment.NewLine}Assembly: {type.Assembly.FullName}");
var baseType = type.BaseType;
if (baseType != null)
{
    Console.WriteLine($"Based on: {baseType.FullName}");
}

WriteFields();
WriteProperties();
WriteMethods();

void WriteFields()
{
    var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
    if (fields.Length > 0)
    {
        Console.WriteLine($"{Environment.NewLine}Fields:");
        foreach (var field in fields)
        {
            var fieldType = field.FieldType.FullName ?? field.FieldType.Name;
            Console.WriteLine($"{fieldType} {field.DeclaringType?.FullName}.{field.Name}");
        }
    }
}

void WriteProperties()
{
    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    if (properties.Length > 0)
    {
        Console.WriteLine($"{Environment.NewLine}Properties:");
        foreach (var property in properties)
        {
            Console.WriteLine($"{property.PropertyType.FullName} {property.Name}");
        }
    }
}

void WriteMethods()
{
    var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
    if (methods.Length > 0)
    {
        Console.WriteLine($"{Environment.NewLine}Methods:");
        foreach (var method in methods)
        {
            var args = method.GetParameters();
            var sb = new StringBuilder();
            sb.Append($"{method.ReturnType.Name} {method.Name} (");
            if (args.Length > 0)
            {
                sb.Append($"{args[0].ParameterType.Name} {args[0].Name}");
                for (int index = 1; index < args.Length; index++)
                {
                    sb.Append($", {args[index].ParameterType.Name} {args[index].Name}");
                }
            }
            sb.Append(")");
            Console.WriteLine(sb.ToString());
        }
    }
}