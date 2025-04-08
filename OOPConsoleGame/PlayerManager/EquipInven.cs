using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.PlayerManager
{
    public class EquipInven
    {
        //장비창
        //-> 장착한 무기 이름, 희귀도, 설명 나열.
        //장착한 아이템이 있는지 여부 변수(isEquip)


        //1. 무기 장착 

        //1) 장착한 무기가 없을 때
        // 해당 아이템이 장착아이템인지 판별 후
        // 아이템 효과(공격력 등)를 적용
        //장비창에 해당 아이템 추가
        //isEquip -> true

        //2) 장착한 무기가 있을 때.
        // 해당 아이템이 장착아이템인지 판별 후
        // 장착한 무기를 먼저 장착 해제(무기 효과 제거도 동반됨.)
        // 무기 효과를 적용
        //장비창에 해당 아이템 추가


        //2. 장착 해제 
        //-> 해제 시 장비창에서 해당 장비 제거 및
        //   인벤토리에 해당 아이템 추가.
        //장착한 아이템 변수(isEquip) -> false
        //무기 효과 제거


    }
}
