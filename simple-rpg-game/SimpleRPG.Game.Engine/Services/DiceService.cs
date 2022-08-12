﻿using D20Tek.DiceNotation;
using D20Tek.DiceNotation.DieRoller;
using System;

namespace SimpleRPG.Game.Engine.Services
{
    public class DiceService : IDiceService
    {
        private static readonly IDiceService _instance = new DiceService();

        /// <summary>
        /// Make constructor private to implement singleton pattern.
        /// </summary>
        private DiceService()
        {
        }

        /// <summary>
        /// Static singleton property
        /// </summary>
        public static IDiceService Instance => _instance;

        //--- IDiceService implementation

        public IDice Dice { get; } = new Dice();
        public IDieRoller DieRoller { get; private set; } = new RandomDieRoller();

        public IDiceConfiguration Configuration => Dice.Configuration;

        public IDieRollTracker? RollTracker { get; private set; } = null;

        public void Configure(IDiceService.RollerType rollerType, bool enableTracker = false, int constantValue = 1)
        {
            RollTracker = enableTracker ? new DieRollTracker() : null;

            // NOTE: cool new switch assignment syntax
            DieRoller = rollerType switch
            {
                IDiceService.RollerType.Random => new RandomDieRoller(RollTracker),
                IDiceService.RollerType.Crypto => new CryptoDieRoller(RollTracker),
                IDiceService.RollerType.MathNet => new MathNetDieRoller(RollTracker),
                IDiceService.RollerType.Constant => new ConstantDieRoller(constantValue),
                _ => throw new ArgumentOutOfRangeException(nameof(rollerType))
            };
        }

        public DiceResult Roll() => Dice.Roll(DieRoller);
        public DiceResult Roll(string diceNotation) => Dice.Roll(diceNotation, DieRoller);

        public DiceResult Roll(int sides, int numDice = 1, int modifier = 0)
        {
            var result = Dice.Dice(sides, numDice).Constant(modifier).Roll(DieRoller);
            Dice.Clear();
            return result;
        }
    }
}