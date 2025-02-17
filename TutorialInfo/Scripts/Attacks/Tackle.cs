using TutorialInfo.Scripts.Monsters;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.Attacks
{
    public class Tackle : Attack
    {
        public void use()
        {
            Random prob = new Random();
            if(prob.Next(100) > 80){
                Debug.Log("Critical Hit!");
                BattleSystem.getInstance().attackTarget(20);
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle, CRITICAL HIT!";
            }
            else if(prob.Next(100) > 95){
                Debug.Log("Attack Missed!");
                BattleSystem.getInstance().attackTarget(0);
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle, MISSED!";
            } else{
                BattleSystem.getInstance().attackTarget(10);
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle";
            }
        }

        public string getName()
        {
            return "Tackle";
        }
    }
}