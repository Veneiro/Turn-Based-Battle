using UnityEngine;

namespace TutorialInfo.Scripts.BattleStates
{
    public class LoseState : BattleState
    {
        public void OnEnter()
        {
            Debug.Log("You Lose");
        }

        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}