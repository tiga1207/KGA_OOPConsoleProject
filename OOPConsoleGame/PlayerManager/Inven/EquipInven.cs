using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.PlayerManager.Inven
{
    public class EquipInven
    {
        //장비창
        //-> 장착한 무기 이름, 희귀도, 설명 나열.
        //장착한 아이템이 있는지 여부 변수(isEquip)
        private EquipItem equipedItem = null;
        public bool isEquip = false;

        //1. 무기 장착 
        public void Equip(EquipItem equipItem, Player player, Inventory inventory)
        {
            //1) 장착한 무기가 없을 때
            // 해당 아이템이 장착아이템인지 판별 후
            // 아이템 효과(공격력 등)를 적용
            //장비창에 해당 아이템 추가
            //isEquip -> true
            if(!isEquip && equipedItem == null) 
            {
                //장착
                equipedItem = equipItem;
                //효과 적용
                player.ATK += equipItem.WeaponAtk;
                isEquip = true; 
            }

            //2) 장착한 무기가 있을 때.
            // 해당 아이템이 장착아이템인지 판별 후
            // 장착한 무기를 먼저 장착 해제(무기 효과 제거도 동반됨.)
            // 무기 효과를 적용
            //장비창에 해당 아이템 추가
            else if(isEquip && equipedItem != null) 
            {
                UnEquip(player, inventory);
                equipedItem = equipItem;
                player.ATK += equipItem.WeaponAtk;
                isEquip = true;
            }

        }

        //2. 장착 해제 
        public void UnEquip(Player player, Inventory inventory)
        {
            //-> 해제 시 장비창에서 해당 장비 제거 및
            //   인벤토리에 해당 아이템 추가.
            //장착한 아이템 변수(isEquip) -> false
            //무기 효과 제거
            if(isEquip && equipedItem!=null) 
            {
                inventory.AddItem(equipedItem);
                player.ATK -= equipedItem.WeaponAtk;
                equipedItem = null;
                isEquip=false;
            }
        }

        //3. 장착 아이템 불러오기.
        public EquipItem GetEquipItem()
        {
            return equipedItem;
        }



    }
}
