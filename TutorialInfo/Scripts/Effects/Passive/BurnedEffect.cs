using TutorialInfo.Scripts.Monsters;
using UnityEngine;

namespace TutorialInfo.Scripts.Effects.Passive
{
    public class BurnedEffect : PassiveEffect
    {
            private int duracion;
            private int damagePerTurn;

            public BurnedEffect(int duracion, int daño)
            {
                this.duracion = duracion;
                this.damagePerTurn = daño;
            }

            public void ApplyEffect(Monster monster)
            {
                monster.takeDamage(damagePerTurn);
                duracion--;
                BattleSystem.getInstance().dialogueText.text =
                    $"{monster.getName()} sufre {damagePerTurn} de daño por quemadura. Duración restante: {duracion}";
            }

            public bool IsExpired()
            {
                return duracion <= 0;
            }
        }
}