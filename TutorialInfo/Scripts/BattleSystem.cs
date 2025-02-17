using System.Collections.Generic;
using TMPro;
using TutorialInfo.Scripts;
using TutorialInfo.Scripts.Attacks;
using TutorialInfo.Scripts.BattleStates;
using TutorialInfo.Scripts.Monsters;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    
    private static BattleSystem battleSystem;

    public List<Transform> spawnPoints;

    public TMP_Text dialogueText;

    public List<GameObject> alliesGO = new List<GameObject>();
    public List<Monster> allies = new List<Monster>();
    public List<BattleHUD> PlayerHUDs = new List<BattleHUD>();
    public List<Monster> alliesStatus = new List<Monster>();

    public List<GameObject> enemiesGO = new List<GameObject>();
    public List<Monster> enemies = new List<Monster>();
    public List<BattleHUD> EnemyHUDs = new List<BattleHUD>();
    public List<Monster> enemiesStatus = new List<Monster>();
    
    public Monster target;
    public int monsterAttacking;
    private bool won = false;
    private bool lose = false;

    public void incAttackerOnTurn()
    {
        monsterAttacking++;
    }

    public int getCurrentMonsterAttacking()
    {
        return monsterAttacking;
    }

    public void resetMonsterAttacking()
    {
        monsterAttacking = 0;
    }
    
    public static BattleSystem getInstance()
    {
        return battleSystem;
    }

    public void Awake()
    {
        battleSystem = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = new StartState();
        state.execute(this);
        
    }

    void Update()
    {
        checkResult();
        state.execute(this);
    }

    private void checkResult()
    {
        if (won == false && lose == false)
        {
            won = true;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].gameObject.activeSelf == true)
                {
                    won = false;
                }
            }

            if (won == true)
            {
                BattleSystem.getInstance().changeState(new WonState());
            }
            else
            {
                won = false;
            }

            lose = true;
            for (int i = 0; i < allies.Count; i++)
            {
                if (allies[i].gameObject.activeSelf == true)
                {
                    lose = false;
                }
            }

            if (lose == true)
            {
                BattleSystem.getInstance().changeState(new LoseState());
            }
            else
            {
                lose = false;
            }
        }
    }

    public Monster InitialiceMonster(GameObject monster, Transform battleStation, List<Attack> attacks, int level)
    {
        Monster newMonster = Instantiate(monster, battleStation).GetComponent<Monster>();
        newMonster.Init(level, attacks);
        return newMonster;
    }

    public void setTarget(Monster newTarget)
    {
        target = newTarget;
    }

    public void attackTarget(int damage)
    {
        target.takeDamage(damage);
        foreach (BattleHUD hud in PlayerHUDs)
        {
            hud.updateHP();
        }

        foreach (BattleHUD hud in EnemyHUDs)
        {
            hud.updateHP();
        }
    }

    public void changeState(BattleState newState)
    {
        state.OnExit();
        state = newState;
        state.OnEnter();
    }
}
