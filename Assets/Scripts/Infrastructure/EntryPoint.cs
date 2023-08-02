using UnityEngine;

namespace Infrastructure
{
    public class EntryPoint : MonoBehaviour,ICoroutineRunner
    {
        private void Awake()
        {
            GameStateMachine gameStateMachine =new GameStateMachine(new AllServices(),this);  
            gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(gameObject);
        }
    }
}