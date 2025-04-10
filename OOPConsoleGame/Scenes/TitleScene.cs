using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class TitleScene : SceneManager
    {
        //메인 타이틀
        public TitleScene()
        {
            sceneName = "Title";
        }

        //1. 게임 시작(시작 시 메인 맵으로 이동.)
        //2. 게임종료(종료시 콘솔 끄기.)
        public override void Input()
        {
            input =Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("\t\t----------TRPG 콘솔게임----------\n\n");
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("1. 게임 시작하기");
            Console.WriteLine("2. 게임 종료하기");
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("메인 마을로 이동합니다 ! ! !");
                    UtilManager.ReadAnyKey("아무 키나 눌러 메인 마을로 이동하세요.");
                    GameManager.ChangeScene("Main");
                    break;
                case ConsoleKey.D2:
                    GameManager.GameOver("게임 종료를 선택하셨습니다.");
                    break;
                default:
                    UtilManager.ReadAnyKey("잘못된 입력입니다. . .");
                    break;
            }
        }

        public override void Update()
        {
        }
    }
}
