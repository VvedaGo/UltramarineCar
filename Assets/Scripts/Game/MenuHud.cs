using Infrastructure;
using UnityEngine;

namespace Game
{
    public class MenuHud:MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        public void SetSceneLoader(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Play()
        {
            _sceneLoader.Load("GameScene");
        }
    }
}