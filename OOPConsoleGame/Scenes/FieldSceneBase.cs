using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class FieldSceneBase : SceneManager
    {

        //필드 맵

        //1. 몬스터를 밟으면 전투 씬으로 이동 여부 콘솔에 띄우기,
        //2. 전투 종료 시 필드맵으로 복귀하며, 해당 몬스터는 사라짐.
        //3. 아이템 밟으면(아이템은 그 즉시 파괴) 아이템 획득(인벤토리에 추가.)
        //4. 벽이면 이동 불가능.

        //5. 키를 찾아서 목적지에 키를 꽂으면 스테이지 클리어. -> 클리어 화면(플레이어 체력, 공격력, 보유 골드 등) 보여주고 게임 종료
        protected ConsoleKey input;
        protected string[] mapData;
        protected bool[,] map;
        protected List<ObjectManager> gameObjects;

        public override void Render()
        {
            PrintMap();
            foreach (var obj in gameObjects)
            {
                obj.Print();
            }
            GameManager.Player1.RenderPlayer();

            Console.SetCursorPosition(0, map.GetLength(0) + 1);
            Console.WriteLine($"플레이어 HP: {GameManager.Player1.HP}/{GameManager.Player1.MaxHP}, 플레이어 MP: {GameManager.Player1.MP}/{GameManager.Player1.MaxMP}, 보유 골드: {GameManager.Player1.Gold}");

        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            GameManager.Player1.InputControll(input);
        }

        public override void Result()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                var obj = gameObjects[i];
                if (obj.position.x == GameManager.Player1.PlayerPos.x &&
                    obj.position.y == GameManager.Player1.PlayerPos.y)
                {
                    obj.Interact(GameManager.Player1);
                    gameObjects.RemoveAt(i);
                    break;
                }
            }
        }

        protected void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x] ? ' ' : '#');
                }
                Console.WriteLine();
            }
        }

        protected bool IsWalkable(Vector2 pos)
        {
            return pos.y >= 0 && pos.y < map.GetLength(0)
                && pos.x >= 0 && pos.x < map.GetLength(1)
                && map[pos.y, pos.x];
        }
    }
}
