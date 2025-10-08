using UnityEngine;


public class DroneBehaviour : MonoBehaviour
{
    private int Health = 100;
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float explosionDist;
    private GameObject player;

    private float health = 100f;
    private float distanceToPlayer;

	void Start()
    {
        player = GameObject.FindWithTag("Player");
	}

	private void Update()
	{
		float enemyDistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        distanceToPlayer = enemyDistanceToPlayer;
		Debug.Log(enemyDistanceToPlayer);
		if (enemyDistanceToPlayer <= explosionDist)
        {
            _explosionAnimation();
		}
	}

	private void _explosionAnimation()
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        if(distanceToPlayer <= explosionDist)
			player.GetComponent<PlayerController>().Damage(100f);
		Destroy(gameObject);
    }

    public void Interacted()
    {
        _explosionAnimation();
    }

    void OnDestroy()
    {
       
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("bullet"))
        {
            health -= 50f;
            if(health <= 0f)
            {
                _explosionAnimation();
			}
		}
	}
}
