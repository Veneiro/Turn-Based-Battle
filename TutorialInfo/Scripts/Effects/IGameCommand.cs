namespace TutorialInfo.Scripts
{
    public interface IGameCommand
    {
        void Execute();
        int getExecutionTime();
    }
}