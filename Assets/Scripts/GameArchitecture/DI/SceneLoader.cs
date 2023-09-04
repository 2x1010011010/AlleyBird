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

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
      AsyncOperation waitNexScene = SceneManager.LoadSceneAsync(sceneName);

      while (!waitNexScene.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}