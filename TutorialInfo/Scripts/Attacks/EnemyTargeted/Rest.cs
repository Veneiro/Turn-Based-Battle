using TutorialInfo.Scripts.Monsters;

namespace TutorialInfo.Scripts.Attacks
{
    public class Rest : Attack
    {
        public void use()
        {
            BattleSystem.getInstance().target.Heal(30);
        }

        public string getName()
        {
            return "Rest";
        }

        public bool needTarget()
        {
            return false;
        }
    }
}