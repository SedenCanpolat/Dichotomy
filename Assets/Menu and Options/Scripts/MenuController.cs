using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public enum MenuType
    {
        MainMenu, PauseMenu
    };
    public MenuType menuType = MenuType.MainMenu;

    public GameObject menuContent;

    [Header("Assignables")]
    public GameObject[] Panels; 

    [Header("Variables")]
    public int gameSceneIndex;
    public int mainMenuIndex;

    private void Start()
    {
        if (menuType == MenuType.PauseMenu)
        {
            menuContent.SetActive(false);
        }
    }

    public void Update()
    {
        if (menuType == MenuType.PauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuContent.SetActive(!menuContent.activeSelf);
            }

            Time.timeScale = menuContent.activeSelf == true ? 0f : 1f;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        menuContent.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void PanelOpen(GameObject panel)
    {
        PanelClose();
        panel.SetActive(true);
    }

    public void PanelClose()
    {
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }

}
