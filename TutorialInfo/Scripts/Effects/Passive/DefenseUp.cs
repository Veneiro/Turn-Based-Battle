using TutorialInfo.Scripts.Monsters;
using TutorialInfo.Scripts.Visitor;

namespace TutorialInfo.Scripts.Effects.Passive
{
    public class DefenseUp : PassiveEffect
    {
        private readonly Monster target;

        public DefenseUp(Monster target)
        {
            this.target = target;
        }

        public void accept(AbstractVisitor visitor)
        {
            visitor.visit(this);
        }

        public Monster getTarget()
        {
            return target;
        }
    }
}