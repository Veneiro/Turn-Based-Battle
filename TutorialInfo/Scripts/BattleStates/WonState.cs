using UnityEngine;

namespace TutorialInfo.Scripts.BattleStates
{
    public class WonState : BattleState
    {
        public void OnEnter()
        {
            Debug.Log("You Won");
        }

        public void execute(BattleSystem bm)
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}