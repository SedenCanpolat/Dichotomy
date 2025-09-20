using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class ArmAimRobust : MonoBehaviour
{
	public Camera cam;
	public float kP = 6f;               // oransal kazanç: hýzý açý farkýna göre belirler
	public float maxMotorSpeed = 360f;  // motorun maksimum dönüþ hýzý (degree/s)
	public float maxMotorTorque = 1000f;// motorun tork limiti
	public bool useLimitsClamp = false; // hinge limitleri kullanýlýyorsa hedefi limitlere sýkýþtýr

	HingeJoint2D hinge;
	JointMotor2D motor;

	void Awake()
	{
		hinge = GetComponent<HingeJoint2D>();
		if (cam == null) cam = Camera.main;
		motor = hinge.motor;
		hinge.useMotor = true;
		hinge.useLimits = hinge.useLimits; // olduðu gibi býrak
	}

	void FixedUpdate()
	{
		if (cam == null) return;

		// Hinge pozisyonu dünya koordinatýnda
		Vector3 hingeWorldPos3 = transform.TransformPoint(hinge.anchor);
		Vector2 hingeWorldPos = new Vector2(hingeWorldPos3.x, hingeWorldPos3.y);

		// Fare konumu dünya
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouseWorld3 = cam.ScreenToWorldPoint(mouseScreen);
		Vector2 mouseWorld = new Vector2(mouseWorld3.x, mouseWorld3.y);

		// Hinge'den fareye olan yön ve hedef açý (world space)
		Vector2 dir = mouseWorld - hingeWorldPos;
		if (dir.sqrMagnitude < 0.0001f) return;
		float targetWorldAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		// Þu anki kol dünya açýsý (kol sprite'ýnýzýn 0° yönünü kontrol edin)
		float currentWorldAngle = transform.eulerAngles.z;

		// Eðer sprite baþlangýç yönünüz farklýysa buraya offset ekleyin
		float spriteZeroOffset = 0f;

		// Hinge joint limitleri aktifse hedef açýyý hinge limitlerine sýkýþtýr
		if (useLimitsClamp && hinge.useLimits)
		{
			JointAngleLimits2D L = hinge.limits;
			// hinge.jointAngle, joint referansýndaki mevcut açýdýr
			// hedefi joint referansýna çevir
			float connectedRotation = 0f;
			if (hinge.connectedBody != null) connectedRotation = hinge.connectedBody.rotation;
			float targetJointAngle = Mathf.DeltaAngle(connectedRotation + spriteZeroOffset, targetWorldAngle);
			targetJointAngle = Mathf.Clamp(targetJointAngle, L.min, L.max);
			targetWorldAngle = connectedRotation + spriteZeroOffset + targetJointAngle;
		}

		// Açý farký (-180..180)
		float angleError = Mathf.DeltaAngle(currentWorldAngle - 90 + spriteZeroOffset, targetWorldAngle);

		// Motor hýzý oransal kontrol
		float desiredSpeed = kP * angleError;

		// Hýzý maksima clamping
		float speedClamped = Mathf.Clamp(desiredSpeed, -maxMotorSpeed, maxMotorSpeed);

		// Motor ayarý
		motor.motorSpeed = -speedClamped; // HingeJoint2D.motorSpeed pozitif olduðunda saat yönünün tersine döner, iþaret terslenebilir
		motor.maxMotorTorque = maxMotorTorque;
		hinge.motor = motor;


	}
}