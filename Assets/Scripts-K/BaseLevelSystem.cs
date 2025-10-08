using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLevelSystem : MonoBehaviour
{
#nullable enable

    [Header("Level Transition Elements")]
	[SerializeField] private Animator levelAnim;
	[SerializeField] private GameObject transitionScreen;
    
    [Space]
    [SerializeField] private int nextLevelIndex;
	[Space]
	[SerializeField] private bool isCutsceneAppear = false;
	[SerializeField] private GameObject? cutsceneOfThisLevel;

	private bool isLevelCompleted = false;

	void Start()
    {
        LevelStarted();
    }

    private void LevelStarted()
    {
        Debug.Log("Level Started");
		cutsceneOfThisLevel?.SetActive(false);
	}

    public void LevelCompleted()
    {
        SetActiveTransitionPanel(true);
		// Cutscene varsa oradaki buton ile level geçilecek yoksa transition ile geçilecek
		

		if(isLevelCompleted == false)
		{
			isLevelCompleted = true;
			if (isCutsceneAppear == true)
			{
				StartCoroutine(PassLevelWithCutscene());
			}
			else
			{
				StartCoroutine(PassLevelNormally());
			}
		}	
	}

    private IEnumerator PassLevelNormally()
    {
		levelAnim.SetTrigger("LevelEnd");
		yield return new WaitForSeconds(2f);
		Debug.Log("Level passed without cutscene");
		PassLevel();
	}

	private IEnumerator PassLevelWithCutscene()
	{
		levelAnim.SetTrigger("LevelEnd");
        yield return new WaitForSeconds(1f);
		cutsceneOfThisLevel?.SetActive(true);
		cutsceneOfThisLevel?.GetComponent<Animator>().Rebind();
		
	}

    public void PassLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
	}

    public void SetActiveTransitionPanel(bool isActive)
    {
        transitionScreen.SetActive(isActive);
	}

	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}