using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameArchitecture.DI
{
  public class SceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) => 
      _coroutineRunner = coroutineRunner;

    public void Load(string sceneName, Action onLoaded = null) =>
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

    private IEnumerator LoadScene(string nextSceneName, Action onLoaded = null)
    {
      if (SceneManager.GetActiveScene().name == nextSceneName)
      {
        onLoaded?.Invoke();
        yield break;
      }

      AsyncOperation waitNexScene = SceneManager.LoadSceneAsync(nextSceneName);

      while (!waitNexScene.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}