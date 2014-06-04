using System;
using System.Linq.Expressions;
using LightInject;
using MessengerClientLib.Interfaces;
using ServiceContainer = LightInject.ServiceContainer;

namespace MessengerClientLib.ApplicationController
{
    /// <summary>
    /// Обертка для библиотеки LightInject
    /// </summary>
    public class LightInjectAdapter : IContainer
    {
        /// <summary>
        /// Контейнер
        /// </summary>
        private readonly IServiceContainer _container = new ServiceContainer();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public LightInjectAdapter()
        {
        }

        /// <summary>
        /// Конструктор от конкретного контейнера
        /// </summary>
        /// <param name="container"></param>
        public LightInjectAdapter(IServiceContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Регистрация сервиса
        /// </summary>
        /// <typeparam name="TService">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
        }

        /// <summary>
        /// Регистрация сервиса (без представления)
        /// </summary>
        /// <typeparam name="TService">Реализация</typeparam>
        public void Register<TService>()
        {
            _container.Register<TService>();
        }

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <param name="instance">Зависимость</param>
        public void RegisterInstance<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }

        /// <summary>
        /// Регистрация сервиса (фабричная)
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <typeparam name="TArgument">Тип аргументов</typeparam>
        /// <param name="factory">Фабрика</param>
        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _container.Register(serviceFactory => factory);
        }

        /// <summary>
        /// Решение
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <returns>Реализация сервиса</returns>
        public TService Resolve<TService>()
        {
            return _container.GetInstance<TService>();
        }

        /// <summary>
        /// Проверка, зарегистрирован ли сервис
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <returns>зарегистрирован ли сервис</returns>
        public bool IsRegistered<TService>()
        {
            return _container.CanGetInstance(typeof(TService), string.Empty);
        }
    }
}