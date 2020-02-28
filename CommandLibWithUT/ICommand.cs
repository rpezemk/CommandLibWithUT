namespace CommandLibWithUT
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
