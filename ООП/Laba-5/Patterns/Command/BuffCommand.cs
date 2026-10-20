using Laba5.Patterns.Common;

namespace Laba5.Patterns.Command
{
    
    public class BuffCommand : ICommand
    {
        private readonly PlayableCharacter _receiver; // <-- получатель
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