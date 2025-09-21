using JetBrains.Annotations;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	public static bool canControl = true;

#nullable enable
	public GameObject bodySprite;
	Rigidbody2D rb;
	HingeJoint2D hj;
	private JointMotor2D motor;

	[SerializeField] private float health = 100f;

	public bool isGunActive = false;
	public bool isPickActive = false;

	[Header("Burayý görme ölü leþi gibi atama var")]
	public GameObject ArmedArm;
	public GameObject UnarmedArm;
	public GameObject GunArm;
	[Space]
	public GameObject PickedArm;
	public GameObject UnpickedArm;
	public GameObject PickArm;
	[Space]
	public GameObject? DeadScreen;
	

	void Start()
	{
		canControl = true;
		if (PlayerController.canControl == false)
			return;
		rb = GetComponent<Rigidbody2D>();
		motor = new JointMotor2D();
		hj = GetComponent<HingeJoint2D>();
		hj.enabled = true;

		MenuController.Kronos(1);
		DeadScreen.SetActive(false);

		CheckActiveArms();
		
	}

	public void CheckActiveArms()
	{
		if (PlayerController.canControl == false)
			return;
		if (isGunActive == true)
		{
			ArmedArm.SetActive(true);
			UnarmedArm.SetActive(false);
			
			GunArm.GetComponent<ArmAimRobust>().enabled = true;
			GunArm.GetComponent<ArmShootter>().enabled = true;
			
			// Bahnschrift

			GunArm.GetComponent<HingeJoint2D>().useMotor = true;

		}
		else
		{
			ArmedArm.SetActive(false);
			UnarmedArm.SetActive(true);

			GunArm.GetComponent<ArmAimRobust>().enabled = false;
			GunArm.GetComponent<ArmShootter>().enabled = false;

			GunArm.GetComponent<HingeJoint2D>().useMotor = false;

		}

		if (isPickActive == true)
		{
			PickedArm.SetActive(true);
			UnpickedArm.SetActive(false);

			PickArm.GetComponent<ArmAimRobust>().enabled = true;
			PickArm.GetComponent<PolygonCollider2D>().enabled = true;

			PickArm.GetComponent<HingeJoint2D>().useMotor = true;

		}
		else
		{
			PickedArm.SetActive(false);
			UnpickedArm.SetActive(true);

			PickArm.GetComponent<ArmAimRobust>().enabled = false;
			PickArm.GetComponent<PolygonCollider2D>().enabled = false;

			PickArm.GetComponent<HingeJoint2D>().useMotor = false;
		}


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
		if (health <= 0)
		{
			Death();
		}
	}

	public void Death()
	{
		DeadScreen.SetActive(true);
		
		isGunActive = false;
		isPickActive = false;
		hj.enabled = false;
		CheckActiveArms();
		canControl = false;
	}
}









