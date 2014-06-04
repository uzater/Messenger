using System;
using System.Collections.Generic;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    public interface IMessengerService
    {
        /// <summary>
        /// ������ ������������� ��� ������
        /// </summary>
        List<ShowedUser> ShowedUserList { get; set; } 

        /// <summary>
        /// ������� ������
        /// </summary>
        User LoggedUser { get; set; }

        /// <summary>
        /// ������������ � ������� ������ ���
        /// </summary>
        User FocusedUser { get; set; }

        /// <summary>
        /// ������ ���������
        /// </summary>
        List<Message> Messages { get; set; }

        /// <summary>
        /// ������ �������
        /// </summary>
        List<History> Histories { get; set; }

        void GetUsers(int userId);
        void GetNewMessages(object sender, EventArgs eventArgs);

        void SendMessage(Message message);

        void Initialize();

        void DoSelectedIndexChangeAct(int index);
        Message GetNextNewMessage();

        void SetLoggedUser(User loggedUser);
    }
}