﻿using D20Tek.DiceNotation;
using D20Tek.DiceNotation.DieRoller;
using System;

namespace SimpleRPG.Game.Engine.Services
{
    public class DiceService : IDiceService
    {
        private static readonly IDiceService _instance = new DiceService();

        /// <summary>
        /// Make constructor private to implement singletone pattern.
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

        public void Configure(IDiceService.RollerType rollerType, bool enableTracker = false)
        {
            RollTracker = enableTracker ? new DieRollTracker() : null;

            // NOTE: cool new switch assigment syntax
            DieRoller = rollerType switch
            {
                IDiceService.RollerType.Random => new RandomDieRoller(RollTracker),
                IDiceService.RollerType.Crypto => new CryptoDieRoller(RollTracker),
                IDiceService.RollerType.MathNet => new MathNetDieRoller(RollTracker),
                _ => throw new ArgumentOutOfRangeException(nameof(rollerType))
            };
        }

        public DiceResult Roll() => Dice.Roll(DieRoller);
        public DiceResult Roll(string diceNotation) => Dice.Roll(diceNotation, DieRoller);
    }
}
