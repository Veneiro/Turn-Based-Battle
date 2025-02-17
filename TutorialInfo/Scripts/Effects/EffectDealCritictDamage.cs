namespace TutorialInfo.Scripts.Effects
{
    public class EffectDealCritictDamage : Effect
    {
        private readonly string atkName;
        private readonly int damage;
        private int executionTime = 1;

        public EffectDealCritictDamage(int damage, string atkName)
        {
            this.damage = damage;
            this.atkName = atkName;
        }
        public void Execute()
        {
            BattleSystem.getInstance().dialogueText.text = "Used " + atkName +", CRITICAL HIT!";
            BattleSystem.getInstance().attackTarget(damage);
        }

        public int getExecutionTime()
        {
            return executionTime;
        }
    }
}