using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.PlayerManager.Inven
{
    public class Inventory
    {
        //인벤토리

        //1. 인벤토리는 리스트로 관리.
        private List<InventorySlot> slots = new List<InventorySlot>();

        //2. 인벤토리 아이템 추가
        //인벤토리에 추가되야할 아이템이 있을 경우, 겹칠 수 있으면(isOverlap) count만 추가. 아닐 경우 새로 추가.
        public void AddItem(ItemBase item, int count =1)
        {

            //using 아이템 타입이면서 겹칠 수 있으면
            if(item is UsingItem usingItem &&
                usingItem.isOverlap)
            {
                //슬롯 내부에서 같은 이름이 있는 아이템 찾기.
                foreach(var slot in slots) 
                { 
                    if(slot.Item.Name == item.Name)
                    {
                        slot.Count +=count;
                        return;
                    }
                }
            }
            //아닐 경우 슬롯에 그냥 추가.
            slots.Add(new InventorySlot(item, count));

        }

        //3. 인벤토리 아이템 제거
        //아이템을 다 사용했을 경우, 혹은 아이템을 장착했을 경우 인벤토리에서 제거.
        public void RemoveItem(int index)
        {
            slots.RemoveAt(index);
        }

        //4. 사용 아이템 사용
        // 아이템 사용시 count -1 or count 만큼 차감. 
        public void UsingItemUsed(int index, Player player, int count = 1) 
        {
            //index가 비정상적인 범위로 입력될 때
            if(index < 0 || index >= slots.Count) { return; }

            var slot = slots[index];
            if (slot.Count < count)
            {
                Console.WriteLine("보유 아이템 수량이 부족합니다. 다시 확인하세요.");
                return;
            }

            //사용 아이템일 경우
            if (slot.Item is UsingItem)
            {
                for (int i= 0; i < count; i++) 
                {
                    slot.Item.Use(player);
                }
            }
           
            slot.Count -= count;

            //아이템 수량이 0보다 작거나 같으면.
            if(slot.Count <=0)
            {
                RemoveItem(index);
            }

        }

        //5. 장착 아이템 사용
        
        public void EquipItemUsed(int index, Player player)
        {
            //index가 비정상적인 범위로 입력될 때
            if (index < 0 || index >= slots.Count) { return; }

            var slot = slots[index];
            //장착 아이템일 경우
            if (slot.Item is EquipItem)
            {
                // 1) 장비창에 장착된 아이템이 없을 경우
                // 장착된 장비 : 인벤토리에 추가
                // 장착할 아이템 : 인벤토리에서 제거, 장비창에 추가.

                // 2) 장비창에 장착된 아이템이 없을 경우
                // 장착할 아이템 : 인벤토리에서 제거, 장비창에 추가.

                slot.Item.Use(player);
            }


            //아이템 수량이 0보다 작거나 같으면.
            if (slot.Count <= 0)
            {
                RemoveItem(index);
            }
        }

        




    }
}
