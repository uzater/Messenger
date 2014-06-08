using System;
using System.Collections.Generic;
using System.Linq;
using MessengerClientLib.MessengerServiceReference;
using IMessengerService = MessengerClientLib.Interfaces.IMessengerService;

namespace MessengerClientLib.Services
{
    /// <summary>
    ///     ������ �����������
    /// </summary>
    public class MessengerService : IMessengerService
    {
        /// <summary>
        ///     ������
        /// </summary>
        public MessengerServiceReference.IMessengerService Client;

        /// <summary>
        ///     ����������� �� ���������
        /// </summary>
        public MessengerService()
        {
            Client = new MessengerServiceClient();
        }

        /// <summary>
        ///     �����������, ����������� � �������� ��������� �������
        /// </summary>
        /// <param name="client">������</param>
        public MessengerService(MessengerServiceReference.IMessengerService client)
        {
            Client = client;
        }

        /// <summary>
        ///     ������������ ��� �������� ������� ���
        /// </summary>
        public static User LoggedUser { get; private set; }

        /// <summary>
        ///     �������� ���������
        /// </summary>
        /// <param name="message">��������� ��� ��������</param>
        public void SendMessage(Message message)
        {
            Client.SendMessage(message);
        }

        /// <summary>
        ///     ������������� �����������
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
        ///     ������ ������������� ��� ������
        /// </summary>
        public List<ShowedUser> ShowedUserList { get; set; }

        /// <summary>
        ///     ������������ ��� �������� ������� ���
        /// </summary>
        User IMessengerService.LoggedUser
        {
            get { return LoggedUser; }
            set { LoggedUser = value; }
        }

        /// <summary>
        ///     ���������� ������������
        /// </summary>
        public User FocusedUser { get; set; }

        /// <summary>
        ///     ���������
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        ///     ������� ���������
        /// </summary>
        public List<History> Histories { get; set; }


        /// <summary>
        ///     ��������� �������������
        /// </summary>
        /// <param name="userId">Id ������������</param>
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
        ///     ��������� ����� ���������
        /// </summary>
        public void GetNewMessages(object sender, EventArgs eventArgs)
        {
            foreach (ShowedUser user in ShowedUserList)
            {
                Messages.AddRange(Client.GetMessages(user.Idk__BackingField, LoggedUser.Idk__BackingField).ToList());
            }
        }

        /// <summary>
        ///     ��������� ������������
        /// </summary>
        /// <param name="index">������</param>
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
        ///     ��������� ���������� ���������
        /// </summary>
        /// <returns>����� ���������</returns>
        public Message GetNextNewMessage()
        {
            Message message = Messages.First(m => m.SenderId == FocusedUser.Idk__BackingField);
            Messages.Remove(message);

            return message;
        }

        /// <summary>
        ///     ��������� ������������ ��� �������� ������� ���
        /// </summary>
        /// <param name="loggedUser">������������ ��� �������� ������� ���</param>
        public void SetLoggedUser(User loggedUser)
        {
            LoggedUser = loggedUser;
        }
    }
}