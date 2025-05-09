﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.Management;
public enum ItemType { UsingItem, EquipItem } //사용 아이템, 장착 아이템

namespace OOPConsoleGame.PlayerManager.Item
{
    //아이템 공통 클래스
    public abstract class ItemBase : ObjectManager
    {
        protected ItemBase(ConsoleColor color, char symbol, Vector2 position, bool isOnce) : base(color, symbol, position, isOnce)
        {
        }

        //아이템 이름
        public string Name { get; set; }

        //아이템 가치(골드)
        public int Price { get; set; }

        //아이템 설명
        public string Desc { get; set; }

        //아이템 타입
        public ItemType Type { get; protected set; }

        public abstract void Use(Player player);
    }
}
