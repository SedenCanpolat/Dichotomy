using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{	
	public int health = 100;

	public enum BossState
    {
        Faz1,
		Faz2,
		Dead

	};
    public BossState currentState;


    public GameObject siringa;
    public Transform firePoint;

    private Transform playerPos;
	
	public GameObject lazer;

	public float passiveForce = 2;

    private float shootTimer;
    public float shootInterval = 0.5f;

	//Faz1
	public float faz1_durationChange = 5f;
    private float faz1_timer;
    private bool faz1_attack_checker = true;

	public float range = 10f;
	public Animator animator;


	RaycastHit2D hit;

	private void Start()
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		if(health <= 0) { 			Die();
		}
	}

    private void Update()
    {
        if (currentState == BossState.Faz1)
        {
			lazer.SetActive(false);

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


			if (faz1_attack_checker)
			{
				PassiveAttack();
				animator.SetBool("summon", false);
			}
			else
			{
				SummonEnemies();
			}
		}

		else if (currentState == BossState.Faz2)
		{
			LazerAttack();
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
			animator.SetTrigger("Attack");
			shootTimer = 0;          
		}	
	}

    private void SummonEnemies()
    {
        Debug.Log("Summon Enemies");
		animator.SetBool("summon", true);
	}

    private void LazerAttack()
    {     
		hit = Physics2D.Raycast(firePoint.position, -firePoint.transform.right, 100);
		if(hit.collider != null)
		{		
			float distance = Vector2.Distance(firePoint.position, hit.point);
			lazer.transform.localScale = Vector3.Lerp(lazer.transform.localScale, new Vector3(distance / 1.7f, 0.5f, 1), Time.deltaTime * 20);

			Debug.Log("Hit: " + hit.collider.name +  " Distance: " + distance);
		}
		else
		{
			lazer.transform.localScale = Vector3.Lerp(lazer.transform.localScale, new Vector3(100, 0.5f, 1), Time.deltaTime * 20);
		}
	}

	public void Die()
    {
        animator.SetTrigger("Die");
		currentState = BossState.Dead;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Die();
		}

		if (health <= 50 && currentState == BossState.Faz1)
		{
			currentState = BossState.Faz2;
			Debug.Log("Boss changed to Faz2");
		}
	}
}
