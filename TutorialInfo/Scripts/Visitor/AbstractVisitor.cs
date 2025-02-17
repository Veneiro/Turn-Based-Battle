using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Monsters;

namespace TutorialInfo.Scripts.Visitor
{
    public abstract class AbstractVisitor
    {
        public virtual void visit(BurnedEffect be) {}

        public virtual void visit(DefenseUp du) {}

    }
}