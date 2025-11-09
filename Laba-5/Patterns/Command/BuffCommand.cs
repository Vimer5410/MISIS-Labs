using Laba5.Patterns.Common;

namespace Laba5.Patterns.Command
{
    // 2b. Конкретная Команда
    public class BuffCommand : ICommand
    {
        private readonly PlayableCharacter _receiver; // Получатель
        private readonly string _buffName;

        public BuffCommand(PlayableCharacter receiver, string buffName)
        {
            _receiver = receiver;
            _buffName = buffName;
        }

        public void Execute()
        {
            _receiver.ApplyBuff(_buffName);
        }
    }
}