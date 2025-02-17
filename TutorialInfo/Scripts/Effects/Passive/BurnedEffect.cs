using TutorialInfo.Scripts.Monsters;
using TutorialInfo.Scripts.Visitor;
using UnityEngine;

namespace TutorialInfo.Scripts.Effects.Passive
{
    public class BurnedEffect : PassiveEffect
    {
            private readonly Monster target;

            public BurnedEffect(Monster target)
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