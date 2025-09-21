using UnityEngine;

public class Boss : MonoBehaviour
{
    private float health = 100f;

    public GameObject siringa;
    public Transform firePoint;

    private Transform playerPos;


    public float passiveForce = 2;

    private float shootTimer;
    public float shootInterval = 0.5f;

	//Faz1
	public float faz1_durationChange = 5f;
    private float faz1_timer;
    private bool faz1_attack_checker = true;

	private void Start()
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}


    private void Update()
    {
        if (faz1_timer <= faz1_durationChange + 2)
        {
            faz1_timer += Time.deltaTime;
        }

        if (faz1_timer >= faz1_durationChange)
        {
            Switch();
		}

		if (shootTimer <= shootInterval + 2)
		{
			shootTimer += Time.deltaTime;
		}


        if(faz1_attack_checker)
        {
            PassiveAttack();
		}
        else
        {
            SummonEnemies();
		}

	}

    private void Switch()
    {
               faz1_attack_checker = !faz1_attack_checker;
        faz1_timer = 0;
	}

	private void PassiveAttack()
    {
		Vector2 direction = playerPos.position - firePoint.transform.position;

        if(shootTimer >= shootInterval)
        {
			GameObject newSiringa = Instantiate(siringa, firePoint.position, Quaternion.FromToRotation(Vector2.right, direction));
			newSiringa.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 20f * passiveForce, ForceMode2D.Impulse);
			Debug.Log("Passive Attack");
			shootTimer = 0;          
		}	
	}

    private void SummonEnemies()
    {
        Debug.Log("Summon Enemies");
	}

	public void Die()
    {
        Destroy(gameObject);
	}

}
