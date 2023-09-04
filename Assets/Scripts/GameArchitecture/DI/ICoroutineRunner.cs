using System.Collections;
using UnityEngine;

namespace GameArchitecture.DI
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}