using System.Collections.Generic;
using TutorialInfo.Scripts.Attacks;

namespace TutorialInfo.Scripts.Monsters
{
    public class Slimer : Monster
    {
        private string name = "Slimer";
        public int level;
    
        private int maxHP;
        private int currentHP;

        public bool isProtected = false;
    
        public List<Attack> attacks = new List<Attack>();

        public override void Init(int level, List<Attack> attacks) {
            setLevel(level);
            this.attacks = attacks;
        }

        public override string getName(){
            return name;
        }

        public override int getLevel(){
            return level;
        }

        public void setLevel(int level) {
            this.level = level;
            this.maxHP = 50 + (level * 10);
            this.currentHP = this.maxHP;
        }

        public override int getMaxHP(){
            return maxHP;
        }

        public override int getCurrentHP(){
            return currentHP;
        }

        public override List<Attack> GetAttacks()
        {
            return attacks;
        }

        public override void takeDamage(int damage)
        {
            currentHP -= damage;
        }

        public override void addAttack(Attack attack){
            attacks.Add(attack);
        }
    }
}