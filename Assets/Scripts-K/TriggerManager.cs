using UnityEngine;
using System;


public class TriggerManager : MonoBehaviour
{
	public enum TriggerType
	{
		PopUpScreen,
		biseyler
	};
	public TriggerType triggerType;

	public GameObject popUpScreenElement;

	private void Start()
	{
		popUpScreenElement.SetActive(false); // Baþlangýçta pop-up ekranýný gizle
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if(triggerType == TriggerType.PopUpScreen)
		{
			if(collision.CompareTag("Player"))
			{
				popUpScreenElement.SetActive(true); 
				popUpScreenElement.GetComponent<Animator>().SetBool("isOpen", true);
			}
		}
		else if(triggerType == TriggerType.biseyler)
		{
			// Baþka bir tetikleyici türü için iþlemler
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		if (triggerType == TriggerType.PopUpScreen)
		{
			if (collision.CompareTag("Player"))
			{
				Invoke("Closer", 2f);
				popUpScreenElement.GetComponent<Animator>().SetBool("isOpen", false);
			}
		}
		else if (triggerType == TriggerType.biseyler)
		{
		
		}
	}

	private void Closer()
	{
		popUpScreenElement.SetActive(false);
	}
}
