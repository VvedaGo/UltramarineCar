using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Awake()
    {
      GameStateMachine gameStateMachine =new GameStateMachine(new AllServices());  
      gameStateMachine.Enter<BootstrapState>();
    }
}