using TutorialInfo.Scripts.Monsters;

namespace TutorialInfo.Scripts.Attacks
{
    public interface Attack
    {
        public void use();
        public string getName();
        public bool needTarget();
    }
}