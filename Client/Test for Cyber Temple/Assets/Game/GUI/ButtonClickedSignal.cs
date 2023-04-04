using Game.GUI.Game;

namespace Game.GUI
{
    public class ButtonClickedSignal
    {
        public ButtonClickedSignal(ViewType view)
        {
            View = view;
        }

        public ViewType View { get; }
    }
}