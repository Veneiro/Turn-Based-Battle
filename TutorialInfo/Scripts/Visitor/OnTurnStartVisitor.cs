using TutorialInfo.Scripts.Monsters;
using UnityEngine;

namespace TutorialInfo.Scripts.Visitor
{
    public class OnTurnStartVisitor : AbstractVisitor
    {
        public override void visitBurned(Monster monster)
        {
            if (monster.isBurned())
            {
                monster.takeDamage(Random.Range(1, 3));
            }
        }
    }
}