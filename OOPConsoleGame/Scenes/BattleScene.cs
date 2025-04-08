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

        //-> 이전 씬으로 복귀.(만약 몬스터가 죽지 않는다면 몬스터 심볼은 파괴되지 않는다.)
        public override void Render()
        {
            Console.WriteLine("\t\t---------------------------------\n\n");
            Console.WriteLine("\t\t------------전투 진행 중----------\n\n");
            Console.WriteLine("\t\t---------------------------------\n\n");
        }
        public override void Choice()
        {
            Console.WriteLine("1. 공격하기"); // 특정 스탯 이상 -> 공격 성공, 아니면 실패
            Console.WriteLine("2. 방어하기"); // 특정 스탯 이상일 경우 방어 성공. 아니면 체력 감소
            Console.WriteLine("3. 도망가기");

        }

        public override void NextStep()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    if (GameManager.Player1.AllStatus >= 10)
                    {
                        Console.WriteLine($" 공격 성공. . . 상대에게 {GameManager.Player1.AllStatus}만큼 데미지를 줬습니다.");
                        //적에게 데미지 주는 로직
                        GameManager.Player1.Score += 10;
                    }
                    else
                    {
                        Console.WriteLine("공격 실패. . .");
                        GameManager.Player1.Score += 1;
                    }
                    break;
                case ConsoleKey.D2:
                    if (GameManager.Player1.AllStatus >= 20)
                    {
                        Console.WriteLine(" 방어 성공. . . ");
                        GameManager.Player1.Score += 10;
                    }
                    else
                    {
                        //추후에 적 공격력 - 플레이어 스탯/2 만큼 데미지 들어가도록
                        //(단, 공격력 <플레이어 스탯/2 일 경우 데미지 5만큼 감소하도록)
                        Console.WriteLine($"방어 실패. . . 체력이 20 감소합니다.");
                        GameManager.Player1.HP -= 20;
                        Console.WriteLine($"플레이어 현재 체력은 {GameManager.Player1.HP} 입니다.");
                        GameManager.Player1.Score += 1;
                    }
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("투기장으로 들어갑니다. . .");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. . .");
                    break;
            }
        }


        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D2:
                    if (GameManager.Player1.HP <= 0)
                    {
                        GameManager.GameOver("적에게 완패했습니다...");
                    }
                    break;
                case ConsoleKey.D3:
                    GameManager.ChangeScene("Field");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. . .");
                    break;
            }
        }
    }
}
