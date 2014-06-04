using System;
using System.Linq;
using System.Windows.Forms;
using MessengerClientLib.EventsArgs;
using MessengerClientLib.Interfaces;
using MessengerClientLib.MessengerServiceReference;
using MessengerClientLib.Services;
using IMessengerService = MessengerClientLib.Interfaces.IMessengerService;
using Message = MessengerClientLib.MessengerServiceReference.Message;

namespace MessengerClientLib.Presenters
{
    /// <summary>
    ///     Презентер формы мессенджера
    /// </summary>
    public class MessengerPresenter : BasePresener<IMessengerForm, User>
    {
        private readonly IMessengerService _service;

        /// <summary>
        ///     Конструктор презентера мессенджера
        /// </summary>
        /// <param name="controller">Контроллер приложения</param>
        /// <param name="view">Интерфейс формы мессенджера</param>
        /// <param name="service">Прослойка</param>
        public MessengerPresenter(IApplicationController controller, IMessengerForm view,
            IMessengerService service = null)
            : base(controller, view)
        {
            _service = service ?? new MessengerService();

            View.SelectedIndexChangedAct += DoSelectedIndexChangedAct;
            View.SendMessageAct += DoSendMessage;
        }

        /// <summary>
        ///     Таймер
        /// </summary>
        public Timer Timer { get; set; }

        /// <summary>
        ///     Обновления списка пользователей
        /// </summary>
        public void RefreshUserList(object sender, EventArgs e)
        {
            _service.GetUsers(_service.LoggedUser.Idk__BackingField);

            View.RefreshUserList(_service.ShowedUserList,
                (_service.FocusedUser != null)
                    ? _service.ShowedUserList.FindIndex(
                        u => u.Idk__BackingField == _service.FocusedUser.Idk__BackingField)
                    : -1);
        }

        /// <summary>
        ///     Выбор пользователя в списка пользователей на форме
        /// </summary>
        private void DoSelectedIndexChangedAct(object sender, SelectedIndexChangedArgs e)
        {
            _service.DoSelectedIndexChangeAct(e.Position);

            View.StartChatWithUser(_service.FocusedUser.Usernamek__BackingField,
                _service.Histories.First(h => h.User.Idk__BackingField == _service.FocusedUser.Idk__BackingField).Text);
        }

        /// <summary>
        ///     Отправка сообщения
        /// </summary>
        private void DoSendMessage(object sender, SendMessageArgs e)
        {
            if (e.Message == string.Empty) return;

            var message = new Message
            {
                SenderId = _service.LoggedUser.Idk__BackingField,
                RecieverId = _service.FocusedUser.Idk__BackingField,
                Time = DateTime.Now,
                Text = e.Message
            };

            History currentHistory =
                _service.Histories.First(h => h.User.Idk__BackingField == _service.FocusedUser.Idk__BackingField);
            currentHistory.Add(message, _service.LoggedUser.Usernamek__BackingField);

            _service.SendMessage(message);

            View.UpdateHistory(currentHistory.Text);
        }

        /// <summary>
        ///     Запуск формы и инициализация
        /// </summary>
        /// <param name="argument">Пользователь под которым запущен мессенджер</param>
        public override void Run(User argument)
        {
            _service.SetLoggedUser(argument);
            _service.Initialize();

            View.SetMyName(argument.Usernamek__BackingField);

            Timer = new Timer {Interval = 1000};
            Timer.Tick += RefreshUserList;
            Timer.Tick += _service.GetNewMessages;
            Timer.Enabled = true;

            View.Show();
        }
    }
}