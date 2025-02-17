using System.Collections;
using System.Linq;
using TutorialInfo.Scripts.Effects;
using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Monsters;
using TutorialInfo.Scripts.Visitor;
using UnityEngine;

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
                OnTurnStartVisitor visitor = new OnTurnStartVisitor(monster.GetPassiveEffects());
            }
            HUDManager.getInstance().dialogBoxAttacks.gameObject.SetActive(false);
            BattleSystem.getInstance().StartCoroutine(EnemyAttackingCorroutine());
        }

        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            HUDManager.getInstance().dialogBoxAttacks.gameObject.SetActive(true);
            BattleSystem.getInstance().dialogueText.text = "Your Turn! What do you want to do now?";
        }

        private IEnumerator EnemyAttackingCorroutine()
        {
            for (int i = 0; i < BattleSystem.getInstance().enemiesStatus.Count; i++)
            {
                int attackTo = Random.Range(0,BattleSystem.getInstance().alliesStatus.Count);
                BattleSystem.getInstance().setTarget(BattleSystem.getInstance().alliesStatus[attackTo]);
                BattleSystem.getInstance().enemies[i].GetAttacks()[Random.Range(0,2)].use();
                yield return null;
            }
            BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EndTurnCommand(new PlayerTurnState()));
        }
    }
}