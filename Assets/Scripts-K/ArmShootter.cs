using UnityEngine;

public class ArmShootter : MonoBehaviour
{   
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
	public ParticleSystem muzzleFlash;

	float timer = 0;
	public float shootInterval = 0.5f; // Yarý saniyede bir atýþ yap

	public Rigidbody2D body;

	void Shoot()
	{
		// 1. Mouse'un dünya koordinatý
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0f;

		// 2. Hedef yönü
		Vector2 direction = (mousePos - firePoint.position).normalized;

		// 3. Mermiyi üret
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

		// 4. Rigidbody2D ile hýz ver
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.linearVelocity = direction * bulletForce;

		// 5. Ýsteðe baðlý: Mermiyi hedefe bakacak þekilde döndür
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

		muzzleFlash.Play();
		body.AddForce(-direction * bulletForce * 0.1f, ForceMode2D.Impulse); // Geri tepme kuvveti
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {	
		if(timer < shootInterval*2) { timer += Time.deltaTime; }

		if (Input.GetKeyDown(KeyCode.Mouse0) && timer> shootInterval)
		{
			timer = 0;
			Shoot();
		}
	}
}
