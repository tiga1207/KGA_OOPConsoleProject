using OOPConsoleGame.Management;
using OOPConsoleGame.PlayerManager.Inven;
using OOPConsoleGame.PlayerManager.Item;
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
        
         private ConsoleKey input;

        public EquipInvenScene()
        {
            sceneName = "Equip";
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("장비 리스트\n\n");

            EquipInven equipInven = GameManager.Player1.equipInven;

            // 1. 장비가 없는 경우
            if (!equipInven.isEquip)
            {
                Console.WriteLine("장착한 무기가 없습니다.");
                Console.WriteLine("\n[1] 되돌아가기");
            }
            else
            {
                // 2. 장비가 있는 경우
                EquipItem item = equipInven.GetEquipItem();
                Console.WriteLine($"장착 중인 무기: {item.Name}");
                Console.WriteLine($"희귀도: {item.Rarity}");
                Console.WriteLine($"공격력: {item.WeaponAtk}");
                Console.WriteLine($"설명: {item.Desc}");

                Console.WriteLine("\n[1] 장착 해제");
                Console.WriteLine("[2] 되돌아가기");
            }
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            
        }

        public override void Result()
        {
            EquipInven equipInven = GameManager.Player1.equipInven;

            if (!equipInven.isEquip)
            {
                if (input == ConsoleKey.D1)
                {
                    UtilManager.ReadAnyKey("장비창을 나갑니다... 아무 키나 누르세요.");

                    if(GameManager.Player1.mapStack.Count >1)
                    {
                        GameManager.Player1.mapStack.Pop();
                        GameManager.ChangeScene(GameManager.Player1.mapStack.Peek());
                    }
                    else
                    {
                        GameManager.ChangeScene("Main");
                    }
                }
            }
            else
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        equipInven.UnEquip(GameManager.Player1, GameManager.Player1.inventory);
                        Console.WriteLine("장비를 해제했습니다.");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        UtilManager.ReadAnyKey("장비창을 나갑니다... 아무 키나 누르세요.");

                        if(GameManager.Player1.mapStack.Count >1)
                        {
                            GameManager.Player1.mapStack.Pop();
                            GameManager.ChangeScene(GameManager.Player1.mapStack.Peek());
                        }
                        else
                        {
                            GameManager.ChangeScene("Main");
                        }
                        break;


                }
            }
        }
    }
}
