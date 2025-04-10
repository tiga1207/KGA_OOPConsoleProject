using OOPConsoleGame.PlayerManager;
using OOPConsoleGame.PlayerManager.Item;
using OOPConsoleGame.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPConsoleGame.Management
{
    public class GameManager
    {
        //씬
        private static Dictionary<string, SceneManager> scene;
        private static SceneManager currentScene;

        //씬 스택저장관리
        public static Stack<SceneManager> SceneStackManager;

        private static Player player;
        public static Player Player1 { get { return player; } }

        //아이템
        public static ItemBase[] item;

        //게임 종료 조건
        public static bool isGameOver;

        //1. 게임 첫 시작
        public static void GameStart()
        {
            //초기 값 세팅

            //1. 게임 종료 조건 설정
            isGameOver = false;

            //2. 플레이어 초기 설정
            //최대(체력,마나),공격력,보유골드
            player = new Player(100, 100, 10, 0);
            //인벤토리
            
            //장비창

            //플레이어 사망 이벤트 구독
            player.OnPlayerDied += PlayerDied;
            

            //3. 씬 설정
            scene = new Dictionary<string, SceneManager>();

            //씬들 추가 될 때마다 딕셔너리에 추가 선언 ex) scene.Add(string, new SceneManger());
            scene.Add("Battle", new BattleScene()); //전투씬
            scene.Add("Field", new FieldScene()); //투기장
            scene.Add("Main", new MainScene()); //메인
            scene.Add("Store", new StoreScene()); //상점
            scene.Add("Title", new TitleScene()); //타이틀
            scene.Add("Inven", new InventoryScene()); //인벤토리
            scene.Add("Equip", new EquipInvenScene()); //장비창

            //초기 씬 세팅
            currentScene = scene["Title"];   
        }

        private static void PlayerDied()
        {
            Console.Clear();
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("\t\t-----------사망하셨습니다.--------\n\n");
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("아무 키나 누르면 게임을 메인 마을로 이동합니다.");
            Console.ReadLine();
            ChangeScene("Main");
            //최소 1은 회복할 수 있도록 구성.
            player.HP = (int)(player.MaxHP * 0.1) > 0 ? (int)(player.MaxHP * 0.1) : 1;
            player.MP = (int)(player.MaxMP * 0.1) > 0 ? (int)(player.MaxMP * 0.1) : 1;
        }

        //2. 게임 구동
        public static void GameUpdate()
        {
            while (!isGameOver)
            {
                Console.Clear();

                currentScene.Render();
                currentScene.Input();
                currentScene.Wait();
                currentScene.Result();
            }
        }
        

        ////3. 게임 종료
        //public static void GameOver(string str)
        //{
        //    Console.Clear();
        //    Console.WriteLine("\t\t---------------------------------\n\n");
        //    Console.WriteLine("\t\t-----------사망하셨습니다.--------\n\n");
        //    Console.WriteLine("\t\t---------------------------------\n\n");
        //    Console.WriteLine(str);//사망 사유
        //    //Console.WriteLine($"플레이어의 점수는 {Player.Score}점 입니다 !!");
        //    //if (Player.Score > 100)
        //    //{
        //    //    Console.WriteLine("상당한 점수입니다 ! ! !");
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("형편없군요 . . 다음에는 분발해보세요!");
        //    //}
        //    Console.WriteLine("아무 키나 누르면 게임을 종료합니다.");
        //    Console.ReadLine();
        //    isGameOver = true;
        //}

        //4. 씬 전환
        public static void ChangeScene(string str)
        {
            currentScene = scene[str];
        }




    }
}
