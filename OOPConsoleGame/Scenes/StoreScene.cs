using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class StoreScene : SceneManager
    {
        //선택지(1. 사용아이템 구매 2. 장착아이템 구매 3.아이템 판매)가 있는 상점

        //1. 사용아이템 구매
        //-> 체력 포션, 마나 포션을 판매하며 개수를 입력하면 해당 개수만큼 구매 가능.(보유 골드에 따른 구매 가능 최대 개수 보여줌.), 골드로 구매 가능. 
        //돈이 있을 경우 구매했다는 알림(ex) 체력 포션 0개를 구매했습니다)과 함께 인벤토리에 아이템 추가.
        //돈이 없을 때 구매 시도하면 돈 없다는 알림출력

        //2. 장착아이템 구매
        // 부위별(우선은 무기만. 추후 업데이트)로 판매하며, 희귀도(Common, Rare, Legendary)가 나뉘어져 있음. 
        // 장착 시 무기 공격력을 플레이어는 획득하며, 희귀도에 따라 추가 데미지(추가 공격력)을 획득
        //


        //3. 아이템 판매
        //구매(혹은 획득) 했던 골드의 70%가격으로 상점에 판매 가능.(아이템 가치의 70%로 판매 가능.)
        //개수를 입력하여 판매 가능하며, 판매시 플레이어 인벤토리에서 해당 개수만큼 제거
        //최대 판매 개수를 보여주며, 이상한 입력을 받으면 오류 메세지 보여주기.
        //판매시 골드 획득.

        //4. 되돌아가기
        //이전 맵으로 이동.
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
