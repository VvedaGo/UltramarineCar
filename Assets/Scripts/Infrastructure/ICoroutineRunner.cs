using System.Collections;

public interface ICoroutineRunner
{
    void StartCoroutine(IEnumerator loadScene);
}