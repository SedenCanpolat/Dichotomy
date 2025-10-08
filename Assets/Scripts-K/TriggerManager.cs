using UnityEngine;
using System;


public class TriggerManager : MonoBehaviour
{
#nullable enable
	public enum TriggerType
	{
		PopUpScreen,
		PassLevel
	};
	public TriggerType triggerType;

	[SerializeField] private GameObject? popUpScreenElement;
	[SerializeField] private BaseLevelSystem? levelSystem;

	private void Start()
	{
		if(triggerType == TriggerType.PopUpScreen)
			popUpScreenElement?.SetActive(false); 
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if(triggerType == TriggerType.PopUpScreen)
		{
			if(collision.CompareTag("Player"))
			{
				popUpScreenElement?.SetActive(true); 
				popUpScreenElement?.GetComponent<Animator>().SetBool("isOpen", true);
			}
		}
		else if(triggerType == TriggerType.PassLevel)
		{
			if(collision.CompareTag("Player"))
				levelSystem?.LevelCompleted();
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		if (triggerType == TriggerType.PopUpScreen)
		{
			if (collision.CompareTag("Player"))
			{
				Invoke("Closer", 2f);
				popUpScreenElement?.GetComponent<Animator>().SetBool("isOpen", false);
			}
		}
		
	}

	private void Closer()
	{
		popUpScreenElement?.SetActive(false);
	}
}
