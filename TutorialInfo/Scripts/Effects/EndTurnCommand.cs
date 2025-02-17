using TutorialInfo.Scripts.BattleStates;

namespace TutorialInfo.Scripts.Effects
{
    public class EndTurnCommand : IGameCommand
    {
        private readonly BattleState battleState;

        public EndTurnCommand(BattleState battleState)
        {
            this.battleState = battleState;
        }
        public void Execute()
        {
            BattleSystem.getInstance().changeState(battleState);
        }

        public int getExecutionTime()
        {
            return 0;
        }
    }
}