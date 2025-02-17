using System.Collections.Generic;
using TutorialInfo.Scripts.Attacks;
using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Visitor;
using UnityEngine;

namespace TutorialInfo.Scripts.Monsters
{
    public abstract class Monster : MonoBehaviour
    {
        public abstract void Init(int level, List<Attack> attacks);
        public abstract string getName();

        public abstract int getLevel();

        public abstract int getMaxHP();

        public abstract int getCurrentHP();

        public abstract List<Attack> GetAttacks();
        
        public abstract void takeDamage(int damage);

        public abstract void addAttack(Attack attack);
        
        public abstract List<PassiveEffect> GetPassiveEffects();
        
        public abstract void AddPassiveEffect(PassiveEffect passiveEffect);

        public abstract void Heal(int amount);

        public abstract bool IsBurned();

        public abstract void SetBurning();
    }
}