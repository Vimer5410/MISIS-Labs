using Laba5.Patterns.Common;

namespace Laba5.Patterns.Command
{
    
    public class HealCommand : ICommand
    {
        private readonly PlayableCharacter _receiver; 
        private readonly int _healAmount;

        public HealCommand(PlayableCharacter receiver, int healAmount)
        {
            _receiver = receiver;
            _healAmount = healAmount;
        }

        public void Execute()
        {
            _receiver.Heal(_healAmount);
        }
    }
}