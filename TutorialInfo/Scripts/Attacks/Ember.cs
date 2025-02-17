using TutorialInfo.Scripts.Effects;
using TutorialInfo.Scripts.Effects.Passive;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.Attacks
{
    public class Ember : Attack
    {
        public void use()
        {
            Random prob = new Random();
            if (prob.Next(100) > 80)
            {
                BattleSystem.getInstance().target.AddPassiveEffect(new BurnedEffect(BattleSystem.getInstance().target));   
            }
            getDamage();
        }
        
        public void getDamage()
        {
            Random prob = new Random();
            if (prob.Next(100) > 80)
            {
                Debug.Log("Critical Hit!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealCritictDamage(25, getName()));
            }
            else if (prob.Next(100) > 95)
            {
                Debug.Log("Attack Missed!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectMissAttack(getName()));
            }
            else
            {
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealDamage(15, getName()));
            }
        }

        public string getName()
        {
            return "Ember";
        }
    }
}