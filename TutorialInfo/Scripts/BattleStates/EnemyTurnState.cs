using System.Collections;
using System.Linq;
using TutorialInfo.Scripts.Monsters;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.BattleStates
{
    public class EnemyTurnState : BattleState
    {
        public void OnEnter()
        {
            foreach (Monster monster in BattleSystem.getInstance().enemies)
            {
                if (monster.getCurrentHP() <= 0)
                {
                    BattleSystem.getInstance().enemiesStatus.Remove(monster);
                    monster.gameObject.SetActive(false);
                    for (int i = 0;
                         i < BattleSystem.getInstance().PlayerHUDs.Count; i++)
                    {
                        if (monster.Equals(BattleSystem.getInstance().EnemyHUDs[i].getHUDTarget()))
                        {
                            BattleSystem.getInstance().EnemyHUDs[i].gameObject.SetActive(false);
                        }
                    }
                }   
            }

            BattleSystem.getInstance().StartCoroutine(EnemyAttackingCorroutine());
        }

        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            
        }

        private IEnumerator EnemyAttackingCorroutine()
        {
            for (int i = 0; i < BattleSystem.getInstance().enemiesStatus.Count; i++)
            {
                BattleSystem.getInstance().dialogueText.text = "Attacking Enemy " + i;
                int attackTo = new Random().Next(BattleSystem.getInstance().alliesStatus.Count);
                BattleSystem.getInstance().setTarget(BattleSystem.getInstance().alliesStatus[attackTo]);
                BattleSystem.getInstance().enemies[i].GetAttacks()[0].use();
                yield return new WaitForSeconds(1);
            }
            BattleSystem.getInstance().changeState(new PlayerTurnState());
        }
    }
}