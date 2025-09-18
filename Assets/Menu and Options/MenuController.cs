using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public bool isMainMenu = true;

	[Header("Assignables")]
    public GameObject OptionsPanel;
    
    [Header("Variables")]
    public int gameSceneIndex;
    public int mainMenuIndex;

	


	public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
	}
   
    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);
    }
    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
	}




}
