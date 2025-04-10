using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPConsoleGame.PlayerManager;

namespace OOPConsoleGame.Monster
{
    public class Monster
    {
        public string name;
        //최대 체력, 현재 체력
        public int hp;
        public int maxHp;
        public int damage;
        public int gold;

        public bool isDead = false;
        
        //몬스터 공격 로직
        public void AttackPlayer(Player player)
        {
            Random rand = new Random();
            int attckPercent = rand.Next(0, 100);


            //공격 실패
            if (attckPercent < 20)
            {
            }
            //크리 데미지
            else if (attckPercent < 25)
            {
                int crit = damage * 2;
                player.HP -= crit;
            }
            //평타 공격
            else
            {
                player.HP -= damage;
            }
        }
        //몬스터 피격 로직
        public void TakeDamage(Player player)
        {
            this.hp -= player.ATK;
            if(hp <=0)
            {
                MonsterDie(player);
            }
        }
        //몬스터 사망 로직
        public void MonsterDie(Player player)
        {
            isDead = true;
            RewardToPlayer(player);
            //플레이어 현재 Position의 몬스터 심볼 파괴(제거)

        }
        //보상 부여
        public void RewardToPlayer(Player player)
        {
            player.Gold += this.gold;
        }

        public void Reset()
        {
            hp = maxHp;
        }



    }
}
