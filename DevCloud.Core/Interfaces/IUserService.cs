using DevCloud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCloud.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Получение пользователя по логину и паролю
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Результат выполнения операции</returns>
        Task<User> GetByLoginPassword(string login, string password);

        /// <summary>
        /// Создание пользователя по типу
        /// </summary>
        /// <param name="newUser">Новый пользователь</param>
        /// <returns>Результат выполнения операции</returns>
        Task Create(User newUser);

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Результат выполнения операции</returns>
        Task<User> GetByLogin(string login);
    }
}
