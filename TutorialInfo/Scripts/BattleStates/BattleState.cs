namespace TutorialInfo.Scripts.BattleStates
{
    public interface BattleState
    {
        public void OnEnter();
        public void execute(BattleSystem bm);
        public void OnExit();
    }
}