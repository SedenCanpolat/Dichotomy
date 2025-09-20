using JetBrains.Annotations;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public GameObject bodySprite;
	Rigidbody2D rb;
	HingeJoint2D hj;
	private JointMotor2D motor;

	float health = 100f;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		motor = new JointMotor2D();
		hj = GetComponent<HingeJoint2D>();
	}

	private void Update()
	{
		if(Input.GetAxisRaw("Horizontal") != 0)
		{
			motor.motorSpeed = Input.GetAxis("Horizontal") * 100;
			motor.maxMotorTorque = 50f;
			hj.motor = motor;
		}
		else
		{
			float angle = transform.eulerAngles.z;
			float angleDiff = Mathf.DeltaAngle(angle,0);

			motor.motorSpeed = -1 * (angleDiff / Mathf.Abs(angleDiff)) * 100;
			motor.maxMotorTorque = 50f;
			hj.motor = motor;
		}
	}


	public void Damage(float damage)
	{
		//rb.AddForce(new Vector2(-transform.right.x, -transform.right.y) * damage, ForceMode2D.Impulse);
		health -= damage;
	}
}









