using System;
using System.Collections.Generic;
using TMPro;
using TutorialInfo.Scripts.BattleStates;
using TutorialInfo.Scripts.Monsters;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialInfo.Scripts.Attacks
{
    public class DialogBoxAttacks : MonoBehaviour
    {
        public List<Button> attackButtons = new List<Button>();
        
        public void SetDialogAttacksForCharacter(List<Attack> attacks)
        {
            refreshButtons();
            for (int i = 0; i < attacks.Count; i++)
            {
                attackButtons[i].GetComponentsInChildren<TMP_Text>()[0].text = attacks[i].getName();
                attackButtons[i].name = attacks[i].getName();
                var i1 = i;
                attackButtons[i].onClick.RemoveAllListeners();
                attackButtons[i].onClick.AddListener(() =>
                {
                    BattleState bs = BattleSystem.getInstance().state;
                    BattleSystem.getInstance().changeState(new SelectTargetState(attacks[i1]));
                });
                attackButtons[i].gameObject.SetActive(true);
            }
        }

        public void refreshButtons()
        {
            for (int i = 0; i < attackButtons.Count; i++)
            {
                attackButtons[i].gameObject.SetActive(false);
            }
        }
    }
}