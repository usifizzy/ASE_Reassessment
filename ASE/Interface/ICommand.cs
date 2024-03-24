namespace ASE.Interface
{
    public interface ICommand
    {
        void Execute(DrawingCanvas canvas, string[] arguments);
    }
}
