using UnityEngine;

public class MoverSimple : MonoBehaviour
{
    public Vector2 pose1;
    public Vector2 pose2;

    public float speed = 1f;
	private Vector2 destination;


	void Start()
    {
       destination = pose2;
	}

	void Update()
    {
		if(Vector2.Distance(transform.position, pose1) < 0.1f)
		{
			destination = pose2;
		}
		if (Vector2.Distance(transform.position, pose2) < 0.1f)
		{
			destination = pose1;
		}
		SetDestination();
	}

    void SetDestination()
    {
        transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
	}

}
