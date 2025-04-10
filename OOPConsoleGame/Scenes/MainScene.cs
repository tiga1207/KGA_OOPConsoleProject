using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OOPConsoleGame.Scenes
{
    public class MainScene : SceneManager
    {
        private ConsoleKey input;
        //메인 맵
        public MainScene()
        {
            sceneName = "Main";
        }


        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        //상점, 필드, 인벤토리, 장착

        public override void Render()
        {
            Console.WriteLine("메인 마을에 드디어 도착했다 . . .");
            Console.WriteLine("다음 중 어떤 행동을 취할까? . . .");
            UtilManager.DelayedPrint("1. 필드로 나간다", ConsoleColor.Green);
            UtilManager.DelayedPrint("2. 상점으로 진입한다", ConsoleColor.Green);
            UtilManager.DelayedPrint("3. 인벤토리를 구경한다", ConsoleColor.Green);
            UtilManager.DelayedPrint("4. 장착 아이템을 확인하러 간다", ConsoleColor.Green);
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    UtilManager.ReadAnyKey("마을 밖으로 나갑니다.");
                    GameManager.ChangeScene("Stage1");
                    break;
                case ConsoleKey.D2:
                    UtilManager.ReadAnyKey("상점으로 들어갑니다");
                    GameManager.ChangeScene("Store");

                    break;
                case ConsoleKey.D3:
                    UtilManager.ReadAnyKey("인벤토리를 확인합니다");
                    GameManager.ChangeScene("Inven");

                    break;
                case ConsoleKey.D4:
                    UtilManager.ReadAnyKey("장비창을 확인합니다");
                    GameManager.ChangeScene("Equip");

                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        public override void Update()
        {
        }
    }
}
