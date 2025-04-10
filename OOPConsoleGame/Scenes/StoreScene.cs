using OOPConsoleGame.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.PlayerManager;
using OOPConsoleGame.PlayerManager.Item;

namespace OOPConsoleGame.Scenes
{
    public class StoreScene : SceneManager
    {
        private ConsoleKey input;

        public StoreScene()
        {
            sceneName = "Store";
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("상점에 오신 걸 환영합니다!");
            Console.WriteLine($"보유 골드: {GameManager.Player1.Gold} G\n");

            UtilManager.DelayedPrint("1. 사용 아이템 구매", ConsoleColor.Yellow);
            UtilManager.DelayedPrint("2. 장착 아이템 구매", ConsoleColor.Yellow);
            UtilManager.DelayedPrint("3. 아이템 판매", ConsoleColor.Yellow);
            UtilManager.DelayedPrint("4. 돌아가기", ConsoleColor.Gray);
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

       
        // 1. 사용아이템 구매
        // -> 체력 포션, 마나 포션을 판매하며 개수를 입력하면 해당 개수만큼 구매 가능.
        //    보유 골드에 따른 구매 가능 최대 개수 보여줌, 골드로 구매 가능.
        //    돈이 있을 경우 구매 알림 출력 후 인벤토리에 아이템 추가.
        //    돈이 없으면 알림 출력.
        private void BuyUseItem()
        {
            Console.Clear();
            Console.WriteLine("1. HP 포션 (30G)");
            Console.WriteLine("2. MP 포션 (30G)");
            Console.WriteLine("3. 돌아가기");

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D3) return;

            string itemName = key == ConsoleKey.D1 ? "HP 포션" : "MP 포션";
            EffectTarget effect = key == ConsoleKey.D1 ? EffectTarget.Hp : EffectTarget.Mp;
            int price = 30;

            int maxBuy = GameManager.Player1.Gold / price;
            Console.WriteLine($"구매 가능 최대 개수: {maxBuy}");
            Console.Write("몇 개를 구매하시겠습니까? ");
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                if (count <= 0 || count > maxBuy)
                {
                    Console.WriteLine("잘못된 수량입니다.");
                    return;
                }

                GameManager.Player1.Gold -= price * count;
                var item = new UsingItem(itemName, price, $"플레이어의 {(itemName == "HP 포션" ? "체력을" : "마나를")} 30만큼 회복합니다.", true,effect, 30);
                GameManager.Player1.inventory.AddItem(item, count);
                Console.WriteLine($"{itemName} {count}개를 구매했습니다.");
            }
            else
            {
                Console.WriteLine("숫자만 입력하세요.");
            }
        }

        //2. 장착아이템 구매
        // 부위별(우선은 무기만. 추후 업데이트)로 판매하며, 희귀도(Common, Rare, Legendary)가 나뉘어져 있음. 
        // 장착 시 무기 공격력을 플레이어는 획득하며, 희귀도에 따라 추가 데미지(추가 공격력)을 획득
        private void BuyEquipItem()
        {
            Console.Clear();
            Console.WriteLine("1. 나무검 (Common, 100G)");
            Console.WriteLine("2. 철검 (Rare, 200G)");
            Console.WriteLine("3. 전설의 검 (Legendary, 400G)");
            Console.WriteLine("4. 돌아가기");

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.D4) return;

            EquipItem item = null;

            switch (key)
            {
                case ConsoleKey.D1:
                    item = new EquipItem("나무검", 100, "기본 무기", 5, Rarity.Common);
                    break;
                case ConsoleKey.D2:
                    item = new EquipItem("철검", 200, "좋은 무기", 10, Rarity.Rare);
                    break;
                case ConsoleKey.D3:
                    item = new EquipItem("전설의 검", 400, "엄청난 무기", 20, Rarity.Legendary);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
            }

            if (item == null) return;

            if (GameManager.Player1.Gold < item.Price)
            {
                Console.WriteLine("골드가 부족합니다!");
                return;
            }

            GameManager.Player1.Gold -= item.Price;
            GameManager.Player1.inventory.AddItem(item);
            Console.WriteLine($"{item.Name}을(를) 구매했습니다.");
        }

        //3. 아이템 판매
        //구매(혹은 획득) 했던 골드의 70%가격으로 상점에 판매 가능.(아이템 가치의 70%로 판매 가능.)
        //개수를 입력하여 판매 가능하며, 판매시 플레이어 인벤토리에서 해당 개수만큼 제거
        //최대 판매 개수를 보여주며, 이상한 입력을 받으면 오류 메세지 보여주기.
        //판매시 골드 획득.
       private void SellItem()
        {
            Console.Clear();
            Console.WriteLine("판매할 아이템을 선택하세요:");
            
            var inventory = GameManager.Player1.inventory;
            var slots = inventory.GetSlots();

            if (slots.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
                return;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("번호 / 아이템 이름 / 수량 / 판매 가격");
            Console.WriteLine("---------------------------------------");

            for (int i = 0; i < slots.Count; i++)
            {
                var slot = slots[i];
                int price = (int)(slot.Item.Price * 0.7f);
                //서식 지정자로 공간 맞추기
                Console.WriteLine($"{i + 1,3} | {slot.Item.Name,-10} | {slot.Count,3}개 | {price,5} G");
            }

            Console.WriteLine("---------------------------------------");
            Console.Write("판매할 아이템 번호 -> ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > slots.Count)
            {
                Console.WriteLine("잘못된 번호입니다.");
                return;
            }

            var selectedSlot = slots[index - 1];
            Console.Write($"몇 개를 판매할까요? (최대 {selectedSlot.Count}개) -> ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0 || count > selectedSlot.Count)
            {
                Console.WriteLine("잘못된 수량입니다.");
                return;
            }

            int unitPrice = (int)(selectedSlot.Item.Price * 0.7f);
            int totalGold = unitPrice * count;

            selectedSlot.Count -= count;
            GameManager.Player1.Gold += totalGold;

            Console.WriteLine($"{selectedSlot.Item.Name} {count}개를 판매하고 {totalGold} G를 획득했습니다!");

            // 수량 0이면 제거
            if (selectedSlot.Count <= 0)
            {
                inventory.RemoveItem(selectedSlot.Item);
            }
        }


         public override void Update() { }

        public override void Result()
        {
            switch (input)
            {
                //1. 사용아이템 구매
                case ConsoleKey.D1:
                    BuyUseItem();
                    break;

                // 2. 장착아이템 구매
                case ConsoleKey.D2:
                    BuyEquipItem();
                    break;

                // 3. 아이템 판매
                case ConsoleKey.D3:
                    SellItem();
                    break;

                // 4. 되돌아가기
                // -> 이전 맵으로 복귀
                case ConsoleKey.D4:
                    UtilManager.ReadAnyKey("상점을 나갑니다...");
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

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }
    }
}
