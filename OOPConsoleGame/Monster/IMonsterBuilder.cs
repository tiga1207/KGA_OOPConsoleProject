using OOPConsoleGame.Management;
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
        IMonsterBuilder SetName(string name);
        IMonsterBuilder SetDmg(int damage);
        IMonsterBuilder SetHp(int hp, int maxHp);
        IMonsterBuilder SetReward(int gold);
        IMonsterBuilder SetPosition(Vector2 pos);
        IMonsterBuilder SetSymbol(char symbol);
        IMonsterBuilder SetColor(ConsoleColor color) ;
        Monster Build();

    }
}
