using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagement : MonoBehaviour 
{
    public static LevelManagement instance;
    private int _sceneIndex;
    
    private void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(gameObject);
            return;
        } 
        else
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }
    
    private void Start()
    {
        StartCoroutine(InitializeSceneTransition());
        
    }
    
    private IEnumerator InitializeSceneTransition()
    {
        yield return null;
        
        var transition = FindFirstObjectByType<Transition>();
        if (transition != null)
        {
            transition.SceneChangend();
        }
    }

    public void ChangeLevelWithTransition(int sceneIndex)
    { 
        _sceneIndex = sceneIndex;
        FindFirstObjectByType<Transition>().MakeTransition(ChangeLevel);
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}