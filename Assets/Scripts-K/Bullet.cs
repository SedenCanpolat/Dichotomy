using UnityEngine;

public class Bullet : MonoBehaviour
{     
    public GameObject impactEffect; 

	private void OnCollisionEnter2D(Collision2D collision)
	{		      
        Instantiate(impactEffect, transform.position, transform.rotation);


		if(collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.GetComponent<Refer>().playerController.Damage(15);
		}

		if (collision.gameObject.CompareTag("bossPart") )
		{
			collision.gameObject.transform.root.GetComponent<Boss>().TakeDamage(20);
			if(collision.gameObject.transform.root.GetComponent<Boss>().health <= 0)
			{
				collision.gameObject.SetActive(false);
			}
		}

		Destroy(gameObject);
	}
}

