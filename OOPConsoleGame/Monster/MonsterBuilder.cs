using OOPConsoleGame.Management;
using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Monster
{
    public class MonsterBuilder : IMonsterBuilder
    {
        private Monster monster = new Monster();

        public IMonsterBuilder SetName(string name)
        {
            monster.name = name;
            return this;
        }
        public IMonsterBuilder SetHp(int hp, int maxHp)
        {
            monster.hp = hp;
            monster.maxHp = maxHp;
            return this;
        }


        public IMonsterBuilder SetReward(int gold)
        {
            monster.gold = gold;
            return this;
        }
        public IMonsterBuilder SetDmg(int damage)
        {
            monster.damage = damage;
            return this;
        }
        public IMonsterBuilder SetPosition(Vector2 pos)
        {
            monster.position = pos;
            return this;
        }

        public IMonsterBuilder SetSymbol(char symbol)
        {
            monster.symbol = symbol;
            return this;
        }

        public IMonsterBuilder SetColor(ConsoleColor color)
        {
            monster.color = color;
            return this;
        }
        public Monster Build()
        {
            return monster;
        }

    }
}
