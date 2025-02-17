namespace TutorialInfo.Scripts.Effects
{
    public class EffectDealDamage : Effect
    {
        private readonly int damage;
        public int ExecutionTime = 1;
        private readonly string atkName;

        public EffectDealDamage(int damage, string atkName)
        {
            this.damage = damage;
            this.atkName = atkName;
        }
        
        public void Execute()
        {
            BattleSystem.getInstance().dialogueText.text = "Used " + atkName;
            BattleSystem.getInstance().attackTarget(damage);
        }

        public int getExecutionTime()
        {
            return ExecutionTime;
        }
    }
}