using D20Tek.DiceNotation;
using D20Tek.DiceNotation.DieRoller;

namespace SimpleRPG.Game.Engine.Services
{
    public interface IDiceService
    {
        public enum RollerType
        {
            Random = 0,
            Crypto = 1,
            MathNet = 2,
            Constant = 3
        }

        IDice Dice { get; }
        IDiceConfiguration Configuration { get; }
        IDieRollTracker? RollTracker { get; }
        void Configure(RollerType rollerType, bool enableTracker = false, int constantValue = 1);
        DiceResult Roll();
        DiceResult Roll(string diceNotation);
    }
}
