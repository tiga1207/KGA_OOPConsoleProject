using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class BattleScene : SceneManager
    {
        //전투 선택지 씬(1.싸우기, 2. 도망가기)

        //1. 전투 시
        // 전투시 몬스터는 플레이어 도망 여부 컨트롤(isPlayerRun -> false)
        //

        //2. 플레이어 도망 시 (isPlayerRun -> true)
        //-> 이전 씬으로 복귀하며, 몬스터는 최대체력으로 다시 회복하고 플레이어 도망갔음을 알리기.

        //3. 전투 종료시
        //-> 이전 씬으로 복귀.(만약 몬스터가 죽지 않는다면 몬스터는 파괴되지 않는다.)

    }
}
