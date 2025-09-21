using UnityEngine;

public class TransitionController : MonoBehaviour
{   
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void KapatAMK()
    {
		//GetComponent<Animator>().Rebind();
		gameObject.SetActive(false);
	}
    
}
