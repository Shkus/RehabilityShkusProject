using System.ComponentModel;

namespace RehabilityApplication.CoreLib
{
    public enum UserRoleType
    {
        [Description("Неизвестно")]
        None,
        [Description("Пользователь")]
        User,
        [Description("Менеджер")]
        Manager,
        [Description("Водитель")]
        Driver,
        [Description("Администратор")]
        Administrator,
        [Description("Разработчик")]
        Developer
    }
}
