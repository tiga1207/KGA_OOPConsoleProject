using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class FieldScene : SceneManager
    {

        //필드 맵

        //1. 몬스터를 밟으면 전투 씬으로 이동 여부 콘솔에 띄우기,
        //2. 전투 종료 시 필드맵으로 복귀하며, 해당 몬스터는 사라짐.
        //3. 아이템 밟으면(아이템은 그 즉시 파괴) 아이템 획득(인벤토리에 추가.)
        //4. 벽이면 이동 불가능.

        //5. 키를 찾아서 목적지에 키를 꽂으면 스테이지 클리어. -> 클리어 화면(플레이어 체력, 공격력, 보유 골드 등) 보여주고 게임 종료
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
