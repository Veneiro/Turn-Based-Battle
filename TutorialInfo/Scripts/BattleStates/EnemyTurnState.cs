using System.Collections;
using System.Linq;
using TutorialInfo.Scripts.Effects;
using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Monsters;
using TutorialInfo.Scripts.Visitor;
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
                OnTurnStartVisitor visitor = new OnTurnStartVisitor(monster.GetPassiveEffects());
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
            BattleSystem.getInstance().dialogueText.text = "Your Turn! What do you want to do now?";
        }

        private IEnumerator EnemyAttackingCorroutine()
        {
            for (int i = 0; i < BattleSystem.getInstance().enemiesStatus.Count; i++)
            {
                int attackTo = new Random().Next(BattleSystem.getInstance().alliesStatus.Count);
                BattleSystem.getInstance().setTarget(BattleSystem.getInstance().alliesStatus[attackTo]);
                BattleSystem.getInstance().enemies[i].GetAttacks()[0].use();
                BattleSystem.getInstance().dialogueText.text = "Enemy " + 
                                                               BattleSystem.getInstance().enemies[i].getName() + " " + 
                                                               i + ": Uses " + 
                                                               BattleSystem.getInstance().enemies[i].GetAttacks()[0].getName();
                yield return new WaitForSeconds(1);
            }
            BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EndTurnCommand(new PlayerTurnState()));
        }
    }
}