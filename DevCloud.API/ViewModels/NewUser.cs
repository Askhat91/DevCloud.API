using System.ComponentModel.DataAnnotations;

namespace DevCloud.API.ViewModels
{
    public class NewUser
    {
        [
           StringLength(maximumLength: 100, MinimumLength = 3,
           ErrorMessage = "Поле должно быть строкой с минимальной длиной {2} и максимальной длиной {1}.")
       ]
        [RegularExpression(@"^\w+$", ErrorMessage = "Поле должно содержать только буквы, цифры и подчеркивания.")]
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [
            StringLength(maximumLength: 255, MinimumLength = 5,
            ErrorMessage = "Поле должно быть строкой с минимальной длиной {2} и максимальной длиной {1}."),
            DataType(DataType.Password)
        ]
        public string Password { get; set; }

        [
            StringLength(maximumLength: 255, MinimumLength = 5,
            ErrorMessage = "Поле должно быть строкой с минимальной длиной {2} и максимальной длиной {1}."),
            DataType(DataType.Password),
            Compare("Password", ErrorMessage = "Пароли не совпадают.")
        ]
        public string ConfirmPassword { get; set; }
    }
}
