using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

try
{
    var httpContext = new DefaultHttpContext();
    Console.WriteLine($"Old Response value: {httpContext.Response}");

    var field = httpContext.GetType().GetField("_response", BindingFlags.Instance | BindingFlags.NonPublic);

    if (field != null)
    {
        if (field.FieldType.IsAssignableFrom(typeof(HttpResponse)) || field.FieldType.IsAssignableFrom(typeof(object)))
        {
            field.SetValue(httpContext, null);
            Console.WriteLine($"New Response value: {httpContext.Response}");
        }
        else
        {
            Console.WriteLine("The field '_response' cannot be set to null.");
        }
    }
    else
    {
        Console.WriteLine("The field '_response' was not found.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}