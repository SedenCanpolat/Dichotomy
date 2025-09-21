using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public float speed;
    public Transform target;
    public Transform bossTarget;    

    public bool isBossLevel = false;

	// Update is called once per frame
	void Update()
    {
        if (isBossLevel == false)
        {
            var targetdest = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetdest, speed * Time.deltaTime);
		}
        else
        {
			var targetdest = new Vector3((bossTarget.position.x + target.position.x) / 2 + offset.y, (bossTarget.position.y + target.position.y) / 2 + offset.y, transform.position.z);
			transform.position = Vector3.Lerp(transform.position, targetdest, speed * Time.deltaTime);
		}
	}
}
