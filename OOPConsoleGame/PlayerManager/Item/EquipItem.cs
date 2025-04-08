using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.PlayerManager.Item
{
    //2. 장착 아이템
    //1) 희귀도
    public enum Rarity { Common, Rare, Legendary }
    public class EquipItem : ItemBase
    {
        //2) 공격력
        public int WeaponAtk;

        public EquipItem()
        {
            Type = ItemType.EquipItem;
        }
    }
}
