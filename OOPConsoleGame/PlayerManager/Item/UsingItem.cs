﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.Management;

namespace OOPConsoleGame.PlayerManager.Item
{
    public enum EffectTarget {Hp, Mp}
    public class UsingItem : ItemBase
    {
        //1. 사용아이템
        //아이템 개수 -> 겹칠 수 있는지 여부(isOverlap)

        public bool isOverlap { get; set; } = true;
        public EffectTarget Target { get; set; }
        public int EffectAmount { get; set; }

        //생성자 오버로딩
        public UsingItem(string name, int price, string desc, bool isOverlap, EffectTarget effectTarget, int effectAmount ,Vector2 position) 
        :base(ConsoleColor.DarkBlue, 'U', position, true)
        {
            Init(name,price,desc,isOverlap,effectTarget,effectAmount);
        }
        public UsingItem(string name, int price, string desc, bool isOverlap, EffectTarget effectTarget, int effectAmount) 
        :base(ConsoleColor.DarkBlue, 'U', new Vector2(-1, -1), true)
        {
            Init(name,price,desc,isOverlap,effectTarget,effectAmount);
        }
        private void Init(string name, int price, string desc, bool isOverlap, EffectTarget effectTarget, int effectAmount)
        {
            Name = name;
            Price = price;
            Desc = desc;
            this.isOverlap = isOverlap;
            Target = effectTarget;
            EffectAmount = effectAmount;
            Type = ItemType.UsingItem;
        }

        //아이템 사용 효과 메서드
        public override void Use(Player player)
        {
            switch (Target)
            {
                case EffectTarget.Hp:
                    player.HealHp(EffectAmount);
                    break;
                case EffectTarget.Mp:
                    player.HealMp(EffectAmount);
                    break;
            }
        }

        public override void Interact(Player player)
        {
            player.inventory.AddItem(this, 1);

        }
    }
}
