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
        //-> 플레이어 사망 혹은 몬스터 사망 전까지는 계속 해당 선택지 선택할 수 있도록

        //1. 전투 시
        // 전투시 몬스터는 플레이어 도망 여부 컨트롤(isPlayerRun -> false)

        //1) 플레이어 공격턴
        // 확률에 따라 1) 공격 성공 2) 크리티컬 공격 성공 3) 공격 실패 4) 공격 실패 + 데미지

        //2) 몬스터 공격턴
        //플레이어가 공격턴을 쓴 후에는 무조건 몬스터가 공격하는 턴.
        // 확률에 따라 1) 공격 성공 2) 크리티컬 공격 성공 3) 공격 실패
        // 위 3패턴 중 하나를 골라 플레이어에게 데미지를 입힌다.

        //2. 플레이어 도망 시 (isPlayerRun -> true)
        //-> 이전 씬으로 복귀하며, 몬스터는 최대체력으로 다시 회복하고 플레이어 도망갔음을 알리기.

        //3. 전투 종료시
        //1. 몬스터 사망 시
        // 몬스터 사망 로직 발동(보상부여, 필드 몬스터 객체 파괴)

        //2. 플레이어 사망 시

        //-> 이전 씬으로 복귀.
        private ConsoleKey input;
        private Monster.Monster monster;

        public BattleScene()
        {
            sceneName = "Battle";
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("전투가 시작됩니다");

            Console.WriteLine($"[플레이어] HP: {GameManager.Player1.HP}/{GameManager.Player1.MaxHP}");
            Console.WriteLine($"[{monster.name}] HP: {monster.hp}/{monster.maxHp}");

            Console.WriteLine("\n[1] 싸우기");
            Console.WriteLine("[2] 도망가기");
        }

        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    // 플레이어 공격
                    monster.TakeDamage(GameManager.Player1);
                    Console.WriteLine($"\n 플레이어의 공격! {GameManager.Player1.ATK} 데미지를 입혔습니다!");

                    if (monster.isDead)
                    {
                        Console.WriteLine($"\n {monster.name}을(를) 처치했습니다!");
                        Console.WriteLine($" {monster.gold} G를 획득했습니다!");
                        GameManager.ChangeScene(GameManager.Player1.mapStack.Peek());
                        return;
                    }

                    // 몬스터 반격
                    int beforeHp = GameManager.Player1.HP;
                    monster.AttackPlayer(GameManager.Player1);
                    int takenDmg = beforeHp - GameManager.Player1.HP;

                    if (takenDmg <= 0)
                    {
                        Console.WriteLine($"{monster.name}의 공격이 빗나갔습니다!");
                    }
                    else if (takenDmg > monster.damage)
                    {
                        Console.WriteLine($"{monster.name}의 크리티컬 공격! {takenDmg} 데미지!");
                    }
                    else
                    {
                        Console.WriteLine($"{monster.name}의 공격! {takenDmg} 데미지!");
                    }

                    if (GameManager.Player1.HP <= 0)
                    {
                        Console.WriteLine("\n당신은 쓰러졌습니다...");
                        GameManager.ChangeScene(GameManager.Player1.mapStack.Pop());
                    }
                    break;

                case ConsoleKey.D2:
                    // 도망 처리
                    Console.WriteLine("\n도망쳤습니다.");
                    GameManager.ChangeScene(GameManager.Player1.mapStack.Pop());
                    break;

                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        public override void Result()
        {
            Console.WriteLine("\n 아무 키나 누르면 다음 턴으로 진행됩니다...");
            Console.ReadKey(true);
        }

        public void SetMonster(Monster.Monster m)
        {
            monster = m;
        }
    }
}
