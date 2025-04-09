using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class EquipInvenScene : SceneManager
    {

        //장착한 장비창
        // 장비 현황-> 기본으로 보여주는 창(선택지 x)

        // 선택지
        // 1.장비(장착한 장비가 있을 떄 보여주는 선택지) 장착해제 2.되돌아가기

        //1. 아무것도 장착하지 않을 때.
        //-> 장착한 무기가 없습니다.
        //-> 장착해제 옵션도 안보여주기.


        //2. 장착한 무기가 있을 때
        //-> 장착한 무기 이름, 희귀도, 설명 나열.
        //1) 장착 해제 
        //-> 해제 시 장비창에서 해당 장비 제거 및
        //   인벤토리에 해당 아이템 추가.
        public override void Input()
        {
            throw new NotImplementedException();
        }

        public override void NextStep()
        {
            throw new NotImplementedException();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Result()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
