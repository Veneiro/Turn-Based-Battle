using System.Collections.Generic;
using TutorialInfo.Scripts.Attacks;
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

        public abstract bool isBurned();
    }
}