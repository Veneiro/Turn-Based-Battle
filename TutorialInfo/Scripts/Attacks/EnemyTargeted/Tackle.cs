using System.Linq;
using TutorialInfo.Scripts.Effects;
using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Monsters;
using UnityEngine;
using Random = System.Random;

namespace TutorialInfo.Scripts.Attacks
{
    public class Tackle : Attack
    {
        private int baseDamage;
        public Tackle(int baseDamage)
        {
            this.baseDamage = baseDamage;
        }
        public void use()
        {
            getDamage();
        }

        private void getDamage()
        {
            Random prob = new Random();
            if(prob.Next(100) > 80){
                Debug.Log("Critical Hit!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealCritictDamage(20, getName()));
            }
            else if(prob.Next(100) > 95){
                Debug.Log("Attack Missed!");
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectMissAttack(getName()));
            } else
            {
                BattleSystem.getInstance().battleEffectManager.AddEffectToList(new EffectDealDamage(10, getName()));
            }
        }

        public string getName()
        {
            return "Tackle";
        }

        public bool needTarget()
        {
            return true;
        }
    }
}