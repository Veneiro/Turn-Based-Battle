using TutorialInfo.Scripts.Monsters;

namespace TutorialInfo.Scripts.Effects.Passive
{
    public interface PassiveEffect
    {
        public void ApplyEffect(Monster monster);
        public bool IsExpired();
    }
}