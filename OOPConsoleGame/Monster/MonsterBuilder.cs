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

        public IMonsterBuilder setName(string name)
        {
            monster.name = name;
            return this;
        }
        public IMonsterBuilder setHp(int hp, int maxHp)
        {
            monster.hp = hp;
            monster.maxHp = maxHp;
            return this;
        }


        public IMonsterBuilder setReward(ItemBase item)
        {
            monster.item = item;
            return this;
        }
        public IMonsterBuilder setDmg(int damage)
        {
            monster.damage = damage;
            return this;
        }
        public Monster Build()
        {
            return monster;
        }

    }
}
