using TutorialInfo.Scripts.Effects;
using TutorialInfo.Scripts.Effects.Passive;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.Attacks
{
    public class Ember : Attack
    {
        private int baseDamage = 15;
        public void use()
        {
            Random prob = new Random();
            if (prob.Next(100) > 80)
            {
                if (BattleSystem.getInstance().target.IsBurned() == false)
                {
                    BattleSystem.getInstance().target.SetBurning();
                    BattleSystem.getInstance().target
                        .AddPassiveEffect(new BurnedEffect(BattleSystem.getInstance().target));
                }
            }
            getDamage();
        }
        
        public void getDamage()
        {
            Random prob = new Random();
            if (prob.Next(100) > 80)
            {
                Debug.Log("Critical Hit!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealCritictDamage((int)(baseDamage*1.7), getName()));
            }
            else if (prob.Next(100) > 95)
            {
                Debug.Log("Attack Missed!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectMissAttack(getName()));
            }
            else
            {
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealDamage(baseDamage, getName()));
            }
        }

        public string getName()
        {
            return "Ember";
        }

        public bool needTarget()
        {
            return true;
        }
    }
}