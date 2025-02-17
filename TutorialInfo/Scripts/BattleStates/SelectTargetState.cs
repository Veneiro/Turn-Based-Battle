using TutorialInfo.Scripts.Attacks;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialInfo.Scripts.BattleStates
{
    public class SelectTargetState : BattleState
    {
        private Attack attack;
        public SelectTargetState(Attack a)
        {
            this.attack = a;
        }

        public void OnEnter()
        {
            if (attack.needTarget() == true)
            {
                for (int i = 0; i < BattleSystem.getInstance().enemies.Count; i++)
                {
                    var i1 = i;
                    BattleSystem.getInstance().EnemyHUDs[i].selectButton.gameObject.SetActive(true);
                    BattleSystem.getInstance().EnemyHUDs[i].selectButton.onClick.RemoveAllListeners();
                    BattleSystem.getInstance().EnemyHUDs[i].selectButton.onClick.AddListener(() =>
                    {
                        Debug.Log("Current enemies: " + BattleSystem.getInstance().enemiesStatus.Count);
                        Debug.Log("Target is: " + i1);
                        BattleSystem.getInstance().setTarget(BattleSystem.getInstance().enemies[i1]);
                        attack.use();
                        BattleSystem.getInstance().dialogueText.text = "Used " + attack.getName();
                        BattleSystem.getInstance().changeState(new PlayerTurnState());
                    });
                }
            }
            else
            {
                BattleSystem.getInstance().setTarget(BattleSystem.getInstance().allies[BattleSystem.getInstance().getCurrentMonsterAttacking()]);
                attack.use();
                BattleSystem.getInstance().dialogueText.text = "Used " + attack.getName();
                BattleSystem.getInstance().changeState(new PlayerTurnState());
            }
        }

        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            BattleSystem.getInstance().incAttackerOnTurn();
        }
    }
}