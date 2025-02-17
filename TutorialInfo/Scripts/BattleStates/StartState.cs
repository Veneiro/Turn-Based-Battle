using System.Collections.Generic;
using TutorialInfo.Scripts.Attacks;
using TutorialInfo.Scripts.Monsters;
using UnityEngine;
using UnityEngine.UIElements;

namespace TutorialInfo.Scripts.BattleStates
{
    public class StartState : BattleState
    {
        public void OnEnter()
        {
            
        }

        public void execute(BattleSystem battleSystem)
        {
            battleSystem.dialogueText.text = "Crazy Trainer challenges you to a battle!";

            int i = 0;
            foreach (GameObject monster in battleSystem.alliesGO)
            {
                foreach (BattleHUD hud in battleSystem.PlayerHUDs)
                {
                    List<Attack> attacks = new List<Attack>();
                    switch (i)
                    {
                        case 0:
                            attacks.Add(new Tackle(20));
                            break;
                        case 1:
                            attacks.Add(new Tackle(20));
                            attacks.Add(new Ember());
                            attacks.Add(new IronDefense());
                            break;
                        case 2:
                            attacks.Add(new Tackle(20));
                            attacks.Add(new Ember());
                            
                            break;
                        default:
                            attacks.Add(new Tackle(20));
                            break;
                    }
                    Monster unit = battleSystem.InitialiceMonster(monster, battleSystem.spawnPoints[i], attacks, Random.Range(5, 10));
                    battleSystem.allies.Add(unit);
                    battleSystem.alliesStatus.Add(unit);
                    hud.setHUD(unit);
                    hud.setActive(true);
                    i++;
                }
            }
            foreach (GameObject monster in battleSystem.enemiesGO)
            {
                foreach (BattleHUD hud in battleSystem.EnemyHUDs)
                {
                    List<Attack> attacks = new List<Attack>();
                    attacks.Add(new Tackle(10));
                    Monster unit = battleSystem.InitialiceMonster(monster, battleSystem.spawnPoints[i], attacks, Random.Range(5, 10));
                    battleSystem.enemies.Add(unit);
                    battleSystem.enemiesStatus.Add(unit);
                    hud.setHUD(unit);
                    hud.setActive(true);
                    i++;
                }
            }
            battleSystem.changeState(new PlayerTurnState());
        }

        public void OnExit()
        {
            
        }
    }
}