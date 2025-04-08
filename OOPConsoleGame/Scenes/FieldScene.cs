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
        //1. 몬스터를 밟으면 즉시 전투 씬으로 이동,
        //2. 전투 종료 시 필드맵으로 복귀하며, 해당 몬스터는 사라짐.
        //3. 아이템 밟으면(아이템은 그 즉시 파괴) 아이템 획득(인벤토리에 추가.)
        //4. 벽이면 이동 불가능.
        //5. 플레이어 사망 시 메인 맵으로 이동하며 최대 체력의 10%만큼 회복한 상태로 부활.

    }
}
