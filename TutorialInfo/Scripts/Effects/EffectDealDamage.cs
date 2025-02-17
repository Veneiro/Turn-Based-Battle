namespace TutorialInfo.Scripts.Effects
{
    public class EffectDealDamage : Effect
    {
        private readonly int damage;
        public int ExecutionTime = 2;
        public EffectDealDamage(int damage)
        {
            this.damage = damage;
        }
        
        public void Execute()
        {
            BattleSystem.getInstance().attackTarget(damage);
        }

        public int getExecutionTime()
        {
            return ExecutionTime;
        }
    }
}