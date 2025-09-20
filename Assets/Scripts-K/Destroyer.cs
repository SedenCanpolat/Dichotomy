using UnityEngine;

public class Destroyer : MonoBehaviour
{
    float timer = 2f;
	private void Start()
	{
		Destroy(gameObject, timer);
	}
}
