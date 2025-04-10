using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.Management;

namespace OOPConsoleGame.PlayerManager.Item
{
    //2. 장착 아이템
    public enum Rarity { Common, Rare, Legendary }
    public class EquipItem : ItemBase
    {

        //1) 희귀도
        public Rarity Rarity { get; set; }
        //2) 공격력
        public int WeaponAtk;

        //Vetor에 따른 생성자 오버로딩
        public EquipItem(string name, int price, string desc, int atk, Rarity rarity, Vector2 position)
            : base(ConsoleColor.DarkBlue, 'E', position, true)
        {
            Init(name, price, desc, atk, rarity);
        }

        public EquipItem(string name, int price, string desc, int atk, Rarity rarity)
            : base(ConsoleColor.DarkBlue, 'E', new Vector2(-1, -1), true) // 의미 없는 위치로 설정
        {
            Init(name, price, desc, atk, rarity);
        }
        private void Init(string name, int price, string desc, int atk, Rarity rarity)
        {
            Type = ItemType.EquipItem;
            Name = name;
            Price = price;
            Desc = desc;
            WeaponAtk = atk;
            Rarity = rarity;
            Extradamage();
        }
        public void Extradamage() // 희귀도에 따른 추가 데미지
        {
            switch (Rarity)
            {
                case Rarity.Common:
                    WeaponAtk *= 1;
                    break;
                case Rarity.Rare:
                    WeaponAtk *= 2;
                    break;
                case Rarity.Legendary:
                    WeaponAtk *= 3;
                    break;
            }
        }

        public override void Use(Player player)
        {
            player.equipInven.Equip(this, player,player.inventory);
        }

        public override void Interact(Player player)
        {
            player.inventory.AddItem(this, 1);
        }
    }
}
