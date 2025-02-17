using TutorialInfo.Scripts.Monsters;
using TutorialInfo.Scripts.Visitor;

namespace TutorialInfo.Scripts.Effects.Passive
{
    public interface PassiveEffect
    {
        public void accept(AbstractVisitor visitor);
    }
}