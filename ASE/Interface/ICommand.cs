
using ASE_Programming_Lang;

namespace ASE_Programming_Lang.Interface
{
    public interface ICommand
    {
        void Execute(Canvas canvas, string[] arguments);
    }
}
