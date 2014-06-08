using System;
using System.Collections.Generic;
using System.Linq;
using MessengerClientLib.MessengerServiceReference;
using IMessengerService = MessengerClientLib.Interfaces.IMessengerService;

namespace MessengerClientLib.Services
{
    /// <summary>
    ///     Сервис мессенджера
    /// </summary>
    public class MessengerService : IMessengerService
    {
        /// <summary>
        ///     Клиент
        /// </summary>
        public MessengerServiceReference.IMessengerService Client;

        /// <summary>
        ///     Конструктор по умолчанию
        /// </summary>
        public MessengerService()
        {
            Client = new MessengerServiceClient();
        }

        /// <summary>
        ///     Конструктор, принимающий в качестве параметра клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        public MessengerService(MessengerServiceReference.IMessengerService client)
        {
            Client = client;
        }

        /// <summary>
        ///     Пользователя для которого запущен чат
        /// </summary>
        public static User LoggedUser { get; private set; }

        /// <summary>
        ///     Отправка сообщения
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        public void SendMessage(Message message)
        {
            Client.SendMessage(message);
        }

        /// <summary>
        ///     Инициализация мессенджера
        /// </summary>
        public void Initialize()
        {
            FocusedUser = null;
            ShowedUserList = new List<ShowedUser>();

            Histories = new List<History>();

            Messages = new List<Message>();

            if (ShowedUserList != null)
                foreach (ShowedUser user in ShowedUserList)
                    Histories.Add(new History(user));
        }

        /// <summary>
        ///     Список пользователей для показа
        /// </summary>
        public List<ShowedUser> ShowedUserList { get; set; }

        /// <summary>
        ///     Пользователя для которого запущен чат
        /// </summary>
        User IMessengerService.LoggedUser
        {
            get { return LoggedUser; }
            set { LoggedUser = value; }
        }

        /// <summary>
        ///     Выделенный пользователь
        /// </summary>
        public User FocusedUser { get; set; }

        /// <summary>
        ///     Сообщения
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        ///     Истории переписки
        /// </summary>
        public List<History> Histories { get; set; }


        /// <summary>
        ///     Получение пользователей
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        public void GetUsers(int userId)
        {
            ShowedUserList.Clear();
            foreach (User user in Client.GetUsers(userId))
            {
                ShowedUserList.Add(new ShowedUser(
                    user.Idk__BackingField,
                    user.Usernamek__BackingField,
                    user.Onlinek__BackingField,
                    (Messages != null)
                        ? (Messages.Where(m => m.SenderId == user.Idk__BackingField).ToList()).Count
                        : 0
                    ));
            }
        }

        /// <summary>
        ///     Получение новых сообщений
        /// </summary>
        public void GetNewMessages(object sender, EventArgs eventArgs)
        {
            foreach (ShowedUser user in ShowedUserList)
            {
                Messages.AddRange(Client.GetMessages(user.Idk__BackingField, LoggedUser.Idk__BackingField).ToList());
            }
        }

        /// <summary>
        ///     Выделение пользователя
        /// </summary>
        /// <param name="index">Индекс</param>
        public void DoSelectedIndexChangeAct(int index)
        {
            if (index == -1)
                return;

            FocusedUser = ShowedUserList[index];

            if (Histories.All(h => h.User.Idk__BackingField != FocusedUser.Idk__BackingField))
                Histories.Add(new History(FocusedUser));

            while (Messages.Any(m => m.SenderId == FocusedUser.Idk__BackingField))
                Histories.First(h => h.User.Idk__BackingField == FocusedUser.Idk__BackingField).Add(GetNextNewMessage());
        }

        /// <summary>
        ///     Получение следующего сообщения
        /// </summary>
        /// <returns>Новое сообщение</returns>
        public Message GetNextNewMessage()
        {
            Message message = Messages.First(m => m.SenderId == FocusedUser.Idk__BackingField);
            Messages.Remove(message);

            return message;
        }

        /// <summary>
        ///     Установка пользователя для которого запущен чат
        /// </summary>
        /// <param name="loggedUser">Пользователь для которого запущен чат</param>
        public void SetLoggedUser(User loggedUser)
        {
            LoggedUser = loggedUser;
        }
    }
}