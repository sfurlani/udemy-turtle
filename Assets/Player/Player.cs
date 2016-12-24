using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool isAdvancing = true;
	public float playSpeed = 0.01f;
	public float jumpImpulse = 10f;
	private bool canJump = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isAdvancing) {
			Advance();
		}

		if (Input.GetButtonDown("Jump")) {
			Jump();
		}
			

	}

	void Advance() {
		float dx = Time.deltaTime * playSpeed;
		transform.Translate(dx, 0, 0, Space.World);
	}

	void Jump() {
		if (!canJump) { return; }
		canJump = false;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(0, jumpImpulse, 0,ForceMode.Impulse);

		Animator an = GetComponent<Animator>();
		an.SetTrigger("jump");
	}

	void JumpEnd() {
		canJump = true;
	}

	void JumpRotate() {
		Rigidbody rb = GetComponent<Rigidbody>();
		Vector3 v = rb.velocity;
		Vector3 euler = transform.eulerAngles;
		float z = (euler.z + v.y) / 2f;
		euler.z = Mathf.Clamp(z, 0f, 90f);
		transform.rotation = Quaternion.Euler(euler);
	}
}
