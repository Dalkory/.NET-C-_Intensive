using System;
using s21_d07_ex02;

ConsoleSetter<IdentityUser> consoleSetter = new ConsoleSetter<IdentityUser>();
IdentityUser identityUser = new IdentityUser();
consoleSetter.SetValues(identityUser);
Console.WriteLine(identityUser);
Console.WriteLine();
var identityRole = new IdentityRole();
ConsoleSetter<IdentityRole> consoleSetterRole = new ConsoleSetter<IdentityRole>();
consoleSetterRole.SetValues(identityRole);
Console.WriteLine(identityRole);