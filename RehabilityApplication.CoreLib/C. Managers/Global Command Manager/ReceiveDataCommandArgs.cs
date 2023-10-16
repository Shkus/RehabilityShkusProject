using System;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс аргументов события получения сообщения с данными.
    /// </summary>
    public class ReceiveDataCommandArgs : EventArgs
    {
        /// <summary>
        /// Свойство - тип команды.
        /// </summary>
        public Enum Command { get; set; }

        /// <summary>
        /// Свойство - полученные данные.
        /// </summary>
        public dynamic Data { get; set; } = null;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="_command">Тип команды.</param>
        /// <param name="_data">Данные.</param>
        public ReceiveDataCommandArgs(Enum _command, dynamic _data)
        {
            Command = _command;
            Data = _data;
        }
    }
}
