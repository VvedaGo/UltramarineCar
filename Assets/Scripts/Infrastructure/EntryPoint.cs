using Infrastructure.GameStateMachine;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure
{
    public class EntryPoint : MonoBehaviour,ICoroutineRunner
    {
        private void Awake()
        {
            GameStateMachine.GameStateMachine gameStateMachine =new GameStateMachine.GameStateMachine(new AllServices(),this);  
            gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(gameObject);
        }
    }
}