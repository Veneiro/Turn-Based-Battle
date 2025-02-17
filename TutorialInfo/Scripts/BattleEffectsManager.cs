using System.Collections;
using System.Collections.Generic;
using TutorialInfo.Scripts.Effects;
using UnityEngine;

namespace TutorialInfo.Scripts
{
    public class BattleEffectsManager : MonoBehaviour
    {
        private List<Effect> _effects = new List<Effect>();
        private int _effectIndex;

        public void Awake()
        {
            StartCoroutine(BattleEffectLoop());
        }
        
        private IEnumerator BattleEffectLoop()
        {
            if (_effects.Count > _effectIndex)
            {
                _effectIndex++;
                _effects[_effectIndex].Execute();
                yield return new WaitForSeconds(_effects[_effectIndex].getExecutionTime());
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }

        public void AddEffectToList(Effect effect)
        {
            _effects.Add(effect);
        }
    }
}