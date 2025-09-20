using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public static LevelManagement instance;

    private int _sceneIndex;
    private Transition _transition;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        _transition = FindFirstObjectByType<Transition>();
        InitializeSceneTransition();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _transition = FindFirstObjectByType<Transition>();
        InitializeSceneTransition();
    }

    public void InitializeSceneTransition()
    {
        if (_transition != null)
            _transition.SceneChangend();
    }

    public void ChangeLevelWithTransition(int sceneIndex)
    {
        _sceneIndex = sceneIndex;
        _transition.MakeTransition(ChangeLevel);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
