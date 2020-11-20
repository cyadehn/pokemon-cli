using BasicGUI;

namespace PokemonCLI
{
    public class LoadingLine : ISceneAction
    {
        public void Run(IWindow window)
        {
            window.Writer.PrintPause(6);
        }
    }
}
