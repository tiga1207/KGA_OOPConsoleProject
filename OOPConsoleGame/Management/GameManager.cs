using OOPConsoleGame.PlayerManager;
using OOPConsoleGame.PlayerManager.Inven;
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
            //커서 깜빡임 안 보이게
            Console.CursorVisible = false;

            //1. 게임 종료 조건 설정
            isGameOver = false;

            //2. 플레이어 초기 설정
            //최대(체력,마나),공격력,보유골드,인벤,장비창
            player = new Player(100, 100, 10, 0);

            //플레이어 사망 이벤트 구독
            player.OnPlayerDied += PlayerDied;
            

            //3. 씬 설정
            scene = new Dictionary<string, SceneManager>();

            //씬들 추가 될 때마다 딕셔너리에 추가 선언 ex) scene.Add(string, new SceneManger());
            scene.Add("Battle", new BattleScene()); //전투씬
            scene.Add("Field", new FieldSceneBase()); //투기장
            scene.Add("Main", new MainScene()); //메인
            scene.Add("Store", new StoreScene()); //상점
            scene.Add("Title", new TitleScene()); //타이틀
            scene.Add("Inven", new InventoryScene()); //인벤토리
            scene.Add("Equip", new EquipInvenScene()); //장비창

            //초기 씬 세팅
            currentScene = scene["Title"];   
            //플레이어 맵 저장 스택
            player.mapStack.Push(currentScene.sceneName);
        }

        private static void PlayerDied()
        {
            Console.Clear();
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("\t\t-----------사망하셨습니다.--------\n\n");
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("아무 키나 누르면 게임을 메인 마을로 이동합니다.");
            Console.ReadLine();
            player.mapStack =null;
            player.mapStack.Push("Title");
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
                Console.WriteLine();
                currentScene.Update();
                currentScene.Result();
            }
        }
        

        ////3. 게임 종료
        public static void GameOver(string str)
        {
           Console.Clear();
           Console.WriteLine(str);//사망 사유
           Console.WriteLine("\t\t---------------------------------\n\n");
           Console.WriteLine("\t\t-----------게임을 종료합니다.--------\n\n");
           Console.WriteLine("\t\t---------------------------------\n\n");

           UtilManager.ReadAnyKey("아무 키나 누르면 게임을 종료합니다.");
           isGameOver = true;
        }

        //4. 씬 전환
        public static void ChangeScene(string str)
        {
            currentScene = scene[str];
            player.mapStack.Push(currentScene.sceneName); //맵 스택에 방문했던 씬 추가.
        }
    }
}
