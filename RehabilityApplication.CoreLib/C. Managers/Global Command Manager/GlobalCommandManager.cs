using System;

namespace RehabilityApplication.CoreLib
{
    /// <summary>
    /// Класс менеджера глобального оповещения.
    /// </summary>
    public static class CoreGlobalCommandManager
    {
        /// <summary>
        /// Событие старта команды без передачи данных.
        /// </summary>
        public static event EventHandler<CommandArgs> CommandInitialized;

        /// <summary>
        /// Обработчик события внешнего запуска команды без передачи данных.
        /// </summary>
        /// <param name="_command">Тип команды.</param>
        /// <param name="_text">Дежурное сообщение (по умолчанию пустое).</param>
        public static void StartCommand(Enum _command, string _text = "")
        {
            CommandInitialized?.Invoke(null, new CommandArgs(_command, _text));
        }

        /// <summary>
        /// Событие старта команды с получением данных.
        /// </summary>
        public static event EventHandler<ReceiveDataCommandArgs> CommandDataReceivingInitialized;

        /// <summary>
        /// Обработчик события внешнего запуска команды с передачей данных.
        /// </summary>
        /// <param name="_command">Тип команды.</param>
        /// <param name="_data">Передаваемые данные.</param>
        public static void StartReceiveDataCommand(Enum _command, dynamic _data)
        {
            CommandDataReceivingInitialized?.Invoke(null, new ReceiveDataCommandArgs(_command, _data));
        }
    }
}
