namespace ASE.Interface
{
    public interface ICommand
    {
        void Execute(Canvas canvas, string[] arguments);
    }
}
