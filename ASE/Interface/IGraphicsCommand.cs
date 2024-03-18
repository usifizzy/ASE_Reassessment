using System.Drawing;

namespace ASE.Interface
{
    public interface IGraphicsCommand
    {
        void Execute(Graphics shape, string[] arguments, ICanvas canvas);
    }
}
