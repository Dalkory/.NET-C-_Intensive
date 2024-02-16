using System.ComponentModel;

namespace s21_d07_ex02
{
    public class IdentityRole
    {
        public IdentityRole()
        {
        }

        [Description("Role Name")]
        [DefaultValue("You")]
        public string Name { get; set; }
        [Description("Role Description")]
        [DefaultValue("Meybe you write something?")]
        public string Description { get; set; }

        public override string ToString()
            => $"{Name}, {Description}";
    }
}