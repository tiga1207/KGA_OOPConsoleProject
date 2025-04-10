using OOPConsoleGame.Management;
using OOPConsoleGame.PlayerManager.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleGame.Scenes
{
    public class InventoryScene : SceneManager
    {
        private ConsoleKey input;

        public InventoryScene()
        {
            sceneName = "Inven";
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("---------------------------------------");

            var slots = GameManager.Player1.inventory.GetSlots();

            if (slots.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
                return;
            }

            Console.WriteLine("번호 / 아이템 이름 / 수량 / 설명");
            Console.WriteLine("---------------------------------------");
            for (int i = 0; i < slots.Count; i++)
            {
                var slot = slots[i];
                Console.WriteLine($"{i + 1,3} | {slot.Item.Name,-10} | {slot.Count,3}개 | {slot.Item.Desc}");
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("사용할 아이템 번호를 입력하세요. (0: 나가기)");
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            var slots = GameManager.Player1.inventory.GetSlots();
            if (slots.Count == 0) return;

            Console.Write("입력 → ");
            string str = Console.ReadLine();

            if (!int.TryParse(str, out int index) || index < 0 || index > slots.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            if (index == 0)
            {
                // 나가기
                return;
            }

            var selectedSlot = slots[index - 1];
            var item = selectedSlot.Item;

            if (item.Type == ItemType.UsingItem)
            {
                GameManager.Player1.inventory.UsingItemUsed(index - 1, GameManager.Player1);
            }
            else if (item.Type == ItemType.EquipItem)
            {
                GameManager.Player1.inventory.EquipItemUsed(index - 1, GameManager.Player1);
            }
            else
            {
                Console.WriteLine("이 아이템은 사용할 수 없습니다.");
            }
        }

        public override void Result()
        {
            UtilManager.ReadAnyKey("아무 키나 눌러 계속하세요..");

            // 맵 복귀
            if (GameManager.Player1.mapStack.Count > 1)
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
}

