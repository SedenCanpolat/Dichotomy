using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	public float moveSpeed = 5f;   // saniyede kaç birim hýzla gitsin
	public float rotateSpeed = 200f; // saniyede kaç derece dönsün

	void Update()
	{
		// Mouse'un dünya koordinatý
		Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorld.z = 0f;

		// Pozisyonu mouse'a yaklaþtýr
		transform.position = Vector3.MoveTowards(transform.position, mouseWorld, moveSpeed * Time.deltaTime);

		// Mouse'a dön
		Vector2 dir = mouseWorld - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
	}
}
