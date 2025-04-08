using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPConsoleGame.PlayerManager.Player;

namespace OOPConsoleGame.PlayerManager
{
    public class Player
    {
        //플레이어 현재 위치
        public struct Position
        {
            public int x;
            public int y;
        }
        //플레이어 맵 위치 저장 stack

        public delegate void PlayerDied();
        public event PlayerDied OnPlayerDied;
        //플레이어 최대 체력, 최대 마나, 현재 체력, 현재 마나
        private int hp;
        public int MaxHP { get; set; }
        public int HP
        {
            get => hp;
            set
            {
                hp = Math.Clamp(value, 0, MaxHP); //Math.Clamp함수로 최대 최솟값 제한. -> Unity에서는 Mathf임.
                if(hp <= 0)
                {
                    PlayerDie();
                }
            }
        }

        private int mp;
        public int MaxMP { get; set; }
        public int MP
        {
            get => mp;
            set => mp = Math.Clamp(value, 0, MaxMP);
        }

        //플레이어 공격력
        public int ATK{ get; set; }

        //플레이어 보유 골드
        public int Gold { get; set;}
        public Player(int maxHP, int maxMP, int atk, int gold )
        {
            this.MaxHP = maxHP;
            this.MaxMP = maxMP;
            this.ATK = atk;
            this.Gold = gold;
        }
        public void Move() //플레이어 좌표 움직임
        {

        }


        //플레이어 사망 시
        //-> 최대체력의 10%를 회복하며 메인 씬으로 이동
        public void PlayerDie()
        {

            OnPlayerDied?.Invoke();//플레이어 사망 이벤트 발생
        }
    }
}
