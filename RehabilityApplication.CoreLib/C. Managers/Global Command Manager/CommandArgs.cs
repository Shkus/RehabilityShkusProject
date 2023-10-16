using System;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс аргументов события без передачи данных.
    /// </summary>
    public class CommandArgs : EventArgs
    {
        /// <summary>
        /// Свойство - тип команды.
        /// </summary>
        public Enum Command { get; set; }

        /// <summary>
        /// Свойство - дежурный текст сообщения. Убрать, если не пригодится.
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// Конструтор класс.
        /// </summary>
        /// <param name="_command">Тип команды.</param>
        /// <param name="_text">Сообщение.</param>
        public CommandArgs(Enum _command, string _text)
        {
            Command = _command;
            Text = _text;
        }
    }
}
