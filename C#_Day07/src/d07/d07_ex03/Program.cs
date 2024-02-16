using System;
using s21_d07_ex03;

Console.WriteLine(typeof(IdentityUser));
var typeFactoryUser = new TypeFactory<IdentityUser>();
var identityUser1 = typeFactoryUser.CreateWithActivator();
var identityUser2 = typeFactoryUser.CreateWithActivator();
Console.WriteLine("user1 {0} user2", (identityUser1 == identityUser2 ? "==" : "!="));
identityUser1 = typeFactoryUser.CreateWithConstructor();
identityUser2 = typeFactoryUser.CreateWithConstructor();
Console.WriteLine("user1 {0} user2", (identityUser1 == identityUser2 ? "==" : "!="));

Console.WriteLine(typeof(IdentityRole));
var typeFactoryRole = new TypeFactory<IdentityRole>();
var identityRole1 = typeFactoryRole.CreateWithActivator();
var identityRole2 = typeFactoryRole.CreateWithActivator();
Console.WriteLine("role1 {0} role2", (identityRole1 == identityRole2 ? "==" : "!="));
identityRole1 = typeFactoryRole.CreateWithConstructor();
identityRole2 = typeFactoryRole.CreateWithConstructor();
Console.WriteLine("role1 {0} role2", (identityRole1 == identityRole2 ? "==" : "!="));

Console.WriteLine($"{Environment.NewLine}{typeof(IdentityUser)}");
Console.WriteLine("Set name:");
var param = Console.ReadLine();
object[] parameters = { param };
var parmUser = typeFactoryUser.CreateWithParameters(parameters);
Console.WriteLine($"Username set: {parmUser.UserName}");