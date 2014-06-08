using System;
using System.Collections.Generic;
using MessengerClientLib.MessengerServiceReference;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// ��������� ������� �����������
    /// </summary>
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

        /// <summary>
        ///     ��������� �������������
        /// </summary>
        /// <param name="userId">Id ������������</param>
        void GetUsers(int userId);

        /// <summary>
        ///     ��������� ����� ���������
        /// </summary>
        void GetNewMessages(object sender, EventArgs eventArgs);

        /// <summary>
        ///     �������� ���������
        /// </summary>
        /// <param name="message">��������� ��� ��������</param>
        void SendMessage(Message message);

        /// <summary>
        ///     ������������� �����������
        /// </summary>
        void Initialize();

        /// <summary>
        ///     ��������� ������������
        /// </summary>
        /// <param name="index">������</param>
        void DoSelectedIndexChangeAct(int index);

        /// <summary>
        ///     ��������� ���������� ���������
        /// </summary>
        /// <returns>����� ���������</returns>
        Message GetNextNewMessage();

        /// <summary>
        ///     ��������� ������������ ��� �������� ������� ���
        /// </summary>
        /// <param name="loggedUser">������������ ��� �������� ������� ���</param>
        void SetLoggedUser(User loggedUser);
    }
}