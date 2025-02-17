using System.Collections.Generic;
using TutorialInfo.Scripts.Effects.Passive;
using TutorialInfo.Scripts.Monsters;
using UnityEngine;

namespace TutorialInfo.Scripts.Visitor
{
    public class OnTurnStartVisitor : AbstractVisitor
    {

        public OnTurnStartVisitor(List<PassiveEffect> passiveEffects)
        {
            for (int i = 0; i < passiveEffects.Count; i++)
            {
                passiveEffects[i].accept(this);
            }
        }
        public override void visit(BurnedEffect be)
        {
            int damagePerTurn = Random.Range(1, 8);
            be.getTarget().takeDamage(damagePerTurn);
            Debug.Log($"{be.getTarget().getName()} sufre {damagePerTurn} de daño por quemadura");
            BattleSystem.getInstance().dialogueText.text =
                $"{be.getTarget().getName()} sufre {damagePerTurn} de daño por quemadura";
        }
    }
}