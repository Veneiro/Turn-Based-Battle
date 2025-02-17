using TutorialInfo.Scripts.Effects;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.Attacks
{
    public class Ember : Attack
    {
        public static readonly Effect[] Effects = new Effect[]
        {
            new EffectDealDamage(getDamage())
        };
        public void use()
        {
            foreach (Effect effect in Effects)
            {
                effect.Execute();
            }
        }
        
        public static int getDamage()
        {
            Random prob = new Random();
            if(prob.Next(100) > 80){
                Debug.Log("Critical Hit!");
                return 25;
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle, CRITICAL HIT!";
            }
            else if(prob.Next(100) > 95){
                Debug.Log("Attack Missed!");
                return 0;
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle, MISSED!";
            } else
            {
                return 15;
                //BattleSystem.getInstance().dialogueText.text = "Used Tackle";
            }
        }

        public string getName()
        {
            return "Ember";
        }
    }
}