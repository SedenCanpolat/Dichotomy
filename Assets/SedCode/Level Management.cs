using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    
    private int _sceneIndex;
    public Animator _animator;

    public Image cutScene;
	public GameObject passButton;

    public float appearSpeed;

    private bool isCutsceneApearad = false;
	private bool kararsinmi = false;

	public int nextLevelIndex;

	public GameObject canvas;

	private void Start()
	{
		isCutsceneApearad = false;
		passButton.SetActive(false);
		_animator.Play("geçiþ 0", -1, 0f);
	}

	private void Update()
	{
		if(isCutsceneApearad == true && cutScene.color.a < 0.99f && kararsinmi == false)
        {   
            Color c = cutScene.color;
			c.a += appearSpeed * Time.deltaTime;
            cutScene.color = c;
		}
		else if(cutScene.color.a >= 0.99f)
		{
			passButton.SetActive(true);
		}

		if (isCutsceneApearad == true && cutScene.color.a > 0.01f && kararsinmi)
		{
			Color c = cutScene.color;
			Debug.Log(c.a);
			c.a -= appearSpeed * Time.deltaTime;
			cutScene.color = c;
		}
		else if (cutScene.color.a <= 0.01f && kararsinmi)
		{
			LevelChanged();
		}
	}

	public void ChangeLevelWithTransition()
    {
		canvas.SetActive(true);
		_animator.SetTrigger("geçiþ");
        StartCoroutine(ChangeLevel());

        
		
	}

	public void PassButtonClicked()
	{
		kararsinmi = true;
	}


	IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1f);
        isCutsceneApearad = true;		
	}

	public void LevelChanged()
    {
		SceneManager.LoadScene(nextLevelIndex);
	}   

	public void Restarter()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
