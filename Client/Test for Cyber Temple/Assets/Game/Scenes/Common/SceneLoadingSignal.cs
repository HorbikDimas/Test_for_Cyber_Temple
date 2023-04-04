namespace Game.Scenes.Common
{
    public class SceneLoadingSignal
    {
        public SceneLoadingSignal(GameScene scene)
        {
            Scene = scene;
        }

        public GameScene Scene { get; }
    }
}
