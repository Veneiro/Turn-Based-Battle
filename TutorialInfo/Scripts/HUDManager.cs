using System.Collections.Generic;
using TutorialInfo.Scripts.Attacks;
using UnityEngine;

namespace TutorialInfo.Scripts
{
    public class HUDManager : MonoBehaviour
    {
        BattleHUD hud;
        public DialogBoxAttacks dialogBoxAttacks;
        static HUDManager hudManager;

        public void Awake()
        {
            hudManager = this;
        }
        
        public static HUDManager getInstance()
        {
            return hudManager;
        }

        public void createHpHUD()
        {
            hud = new BattleHUD();
        }
    }
}