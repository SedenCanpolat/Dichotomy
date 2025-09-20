using System;
using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour
{
    [SerializeField] private CanvasGroup LoadCanvas;
    private float _fadeDuration = 0.7f;

    public void MakeTransition(Action afterTransitionFunc)
    {
        LoadCanvas.alpha = 0f;
        StartCoroutine(FadeCanvas(0f, 1f, _fadeDuration, afterTransitionFunc));
    }

    public void SceneChangend()
    {
        LoadCanvas.alpha = 1f;
        StartCoroutine(FadeCanvas(1f, 0f, 3f, null));
    }

    private IEnumerator FadeCanvas(float start, float end, float duration, Action onComplete)
    {
        float elapsed = 0f;
        LoadCanvas.alpha = start;

        while (elapsed < duration)
        {
            elapsed += Time.unscaledDeltaTime;
            LoadCanvas.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }

        LoadCanvas.alpha = end;
        onComplete?.Invoke();
    }
}
