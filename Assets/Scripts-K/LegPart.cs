using UnityEngine;
using UnityEngine.UI;

public class LegPart : MonoBehaviour
{   
    public KeyCode leftKey = KeyCode.RightArrow;
    public KeyCode rightKey = KeyCode.LeftArrow;

    public PlayerController playerController;

	private JointMotor2D motor;
    private HingeJoint2D hinge;

	public bool isCalf = false;

	public float torqueForce = 200f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
	}

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void Controls()
    {

		if (Input.GetKey(rightKey))
		{
			if (isCalf == false)
			{
				motor.motorSpeed = -500; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}
			else
			{
				motor.motorSpeed = 500; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}
		}
		else if (Input.GetKey(leftKey))
		{
			if(isCalf == false)
			{
				motor.motorSpeed = 500; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}
			else
			{
				motor.motorSpeed = -500; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}

				
		}
		else
		{
			float angle = hinge.connectedBody.transform.eulerAngles.z;
			float angleUpperLeg = hinge.gameObject.transform.eulerAngles.z;

			float angleDiff = Mathf.DeltaAngle(angleUpperLeg, angle);

			if (Mathf.Abs(angleDiff) > 5f)
			{
				motor.motorSpeed = -1 * (angleDiff / Mathf.Abs(angleDiff)) * 1000; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}
			else
			{
				motor.motorSpeed = -1 * (angleDiff / Mathf.Abs(angleDiff)) * 10; // + veya - deðer
				motor.maxMotorTorque = torqueForce;
				hinge.motor = motor;
			}

		}
	}
}
