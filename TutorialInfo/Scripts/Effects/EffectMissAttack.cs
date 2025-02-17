namespace TutorialInfo.Scripts.Effects
{
    public class EffectMissAttack : Effect
    {
        private string atkName;
        private int executionTime = 1;
        public EffectMissAttack(string atkName)
        {
         this.atkName = atkName;   
        }
        public void Execute()
        {
            BattleSystem.getInstance().dialogueText.text = "Used " + atkName + ", MISSED!";
        }

        public int getExecutionTime()
        {
            return executionTime;
        }
    }
}