using TutorialInfo.Scripts.Attacks;
using TutorialInfo.Scripts.Monsters;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialInfo.Scripts.BattleStates
{
    public class PlayerTurnState : BattleState
    {

        public void OnEnter()
        {
            foreach (Monster monster in BattleSystem.getInstance().allies)
            {
                if (monster.getCurrentHP() <= 0)
                {
                    BattleSystem.getInstance().alliesStatus.Remove(monster);
                    monster.gameObject.SetActive(false);
                    for (int i = 0;
                         i < BattleSystem.getInstance().PlayerHUDs.Count; i++)
                    {
                        if (monster.Equals(BattleSystem.getInstance().PlayerHUDs[i].getHUDTarget()))
                        {
                            BattleSystem.getInstance().PlayerHUDs[i].gameObject.SetActive(false);
                        }
                    }
                }   
            }
            if (BattleSystem.getInstance().getCurrentMonsterAttacking() >= BattleSystem.getInstance().alliesStatus.Count)
            {
                Debug.Log("Cambio a enemigo");
                BattleSystem.getInstance().resetMonsterAttacking();
                BattleSystem.getInstance().changeState(new EnemyTurnState());
                return;
            }
            int current = BattleSystem.getInstance().getCurrentMonsterAttacking();
            Debug.Log("TURNO JUGADOR, ATACANDO EL INDEX: "+BattleSystem.getInstance().getCurrentMonsterAttacking());
            HUDManager.getInstance().dialogBoxAttacks.SetDialogAttacksForCharacter(BattleSystem.getInstance().allies[current].GetAttacks());
        }
        
        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}