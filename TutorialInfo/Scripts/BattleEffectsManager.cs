using System.Collections;
using System.Collections.Generic;
using TutorialInfo.Scripts.Effects;
using UnityEngine;

namespace TutorialInfo.Scripts
{
    public class BattleEffectsManager : MonoBehaviour
    {
        private Queue<IGameCommand> _effects = new Queue<IGameCommand>();
        private int _effectIndex;

        public void Awake()
        {
            StartCoroutine(BattleEffectLoop());
        }
        
        private IEnumerator BattleEffectLoop()
        {
            while (this != null)
            {
                if (_effects.Count > 0)
                {
                    IGameCommand e = _effects.Dequeue();
                    e.Execute();
                    yield return new WaitForSeconds(e.getExecutionTime());
                }
                yield return null;
            }
        }

        public void AddEffectToList(IGameCommand effect)
        {
            _effects.Enqueue(effect);
        }
    }
}