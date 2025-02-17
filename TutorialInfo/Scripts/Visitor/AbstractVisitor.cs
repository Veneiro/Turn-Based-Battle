using TutorialInfo.Scripts.Monsters;

namespace TutorialInfo.Scripts.Visitor
{
    public abstract class AbstractVisitor
    {
        public virtual void visitBurned(Monster Target) {}

        public virtual void visitReducedDamage(Monster Target) {}
    }
}