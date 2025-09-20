using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] private CanvasGroup LoadCanvas;
    [SerializeField] private GameObject _cutsceneCanvas;
    [SerializeField] private float SFXTimeForCutscene;
    [SerializeField] private AudioClip sfxForCutscene;
    [SerializeField] private AudioSource audioSource;

    private float _fadeDuration = 0.5f;
    private Action _afterCutsceneAction;
    private bool op = false;

    public void MakeTransition(Action afterCutsceneAction)
    {
        _afterCutsceneAction = afterCutsceneAction;

        LoadCanvas.alpha = 0f;
        StartCoroutine(FadeCanvas(0f, 1f, _fadeDuration, ShowCutscene));
        Invoke("_playSFX", SFXTimeForCutscene);
    }

    public void SceneChangend()
    {
        LoadCanvas.alpha = 1f;
        StartCoroutine(FadeCanvas(1f, 0f, 3f, null));
    }

    private void ShowCutscene()
    {
        if (_cutsceneCanvas != null)
        {
            op = true;
            _cutsceneCanvas.SetActive(true);
            
        }
    }

    private void _playSFX()
    {
        if (sfxForCutscene != null && audioSource != null)
        {
            audioSource.PlayOneShot(sfxForCutscene);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (op)
            {   
                print("op");
                CloseCutscene();
            }
        }
    }

    public void CloseCutscene() // button must call
    {
        LoadCanvas.alpha = 1f;
        StartCoroutine(FadeCanvas(1f, 0f, _fadeDuration, _afterCutsceneAction));
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
