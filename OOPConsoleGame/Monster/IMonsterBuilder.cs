using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Monster
{
    public interface IMonsterBuilder
    {
        IMonsterBuilder setName(string name);
        IMonsterBuilder setDmg(int damage);
        IMonsterBuilder setHp(int hp, int maxHp);
        IMonsterBuilder setReward(int gold);
        Monster Build();

    }
}
