using UnityEngine;

public class Bullet : MonoBehaviour
{     
    public GameObject impactEffect; 

	private void OnCollisionEnter2D(Collision2D collision)
	{		      
        Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}

