using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleRPG.Game.Engine.Factories;
using SimpleRPG.Game.Engine.Services;

namespace SimpleRPG.Game.Engine.Models
{
    public class Location
    {
        public Location()
        {

        }

        public Location(int x, int y, string name, string description, string image)
        {
            XCoordinate = x;
            YCoordinate = y;
            Name = name;
            Description = description;
            ImageName = image;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public IList<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public void AddMonsterEncounter(int monsterId, int chanceOfEncountering)
        {
            if (MonstersHere.Any(m => m.MonsterId == monsterId))
            {
                // Already present? Update the encounter chance
                MonstersHere.First(m => m.MonsterId == monsterId)
                    .ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterId, chanceOfEncountering));
            }
        }

        public bool HasMonster() => MonstersHere.Any();

        public Monster GetMonster()
        {
            if (HasMonster() == false)
            {
                throw new InvalidOperationException();
            }

            var totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Select a random number between 1 and our chance
            var result = DiceService.Instance.Roll(totalChances);

            // loop through the monster list, 
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // when the random number is lower than the runningTotal, that is the monster to return.
            int runningTotal = 0;
            foreach (var monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if (result.Value <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterId);
                }
            }
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterId);
        }
    }
}
