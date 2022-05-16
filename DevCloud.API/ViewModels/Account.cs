using System.ComponentModel.DataAnnotations;

namespace DevCloud.API.ViewModels
{
    public class Account
    {
        [
            StringLength(maximumLength: 100, MinimumLength = 3,
            ErrorMessage = "Поле {0} должно быть строкой с минимальной длиной {2} и максимальной длиной {1}."),
            Display(Name = "Логин")
        ]
        public string Login { get; set; }

        [
            StringLength(maximumLength: 255, MinimumLength = 5,
            ErrorMessage = "Поле {0} должно быть строкой с минимальной длиной {2} и максимальной длиной {1}."),
            DataType(DataType.Password),
            Display(Name = "Пароль")
        ]
        public string Password { get; set; }
    }
}
