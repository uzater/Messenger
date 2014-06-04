using System;
using System.Linq.Expressions;

namespace MessengerClientLib.Interfaces
{
    /// <summary>
    /// Контейнер
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Регистрация сервиса
        /// </summary>
        /// <typeparam name="TService">Представление</typeparam>
        /// <typeparam name="TImplementation">Реализация</typeparam>
        void Register<TService, TImplementation>() where TImplementation : TService;

        /// <summary>
        /// Регистрация сервиса (без представления)
        /// </summary>
        /// <typeparam name="TService">Реализация</typeparam>
        void Register<TService>();

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <param name="instance">Зависимость</param>
        void RegisterInstance<T>(T instance);

        /// <summary>
        /// Решение
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <returns>Реализация сервиса</returns>
        TService Resolve<TService>();

        /// <summary>
        /// Проверка, зарегистрирован ли сервис
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <returns>зарегистрирован ли сервис</returns>
        bool IsRegistered<TService>();

        /// <summary>
        /// Регистрация сервиса (фабричная)
        /// </summary>
        /// <typeparam name="TService">Тип сервиса</typeparam>
        /// <typeparam name="TArgument">Тип аргументов</typeparam>
        /// <param name="factory">Фабрика</param>
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}