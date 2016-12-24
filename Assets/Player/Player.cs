using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private bool isAdvancing = true;
	[SerializeField] private float playSpeed = 0.01f;
	[SerializeField] private float jumpImpulse = 10f;
	[HideInInspector] [SerializeField] private bool isJumping = false;
	[HideInInspector] [SerializeField] private float jumpScale = 0;

	new private Rigidbody rigidbody;
	private Animator animator;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump")) { 
			animator.SetTrigger("jump");
		}
		float x = isAdvancing ? playSpeed : 0;
		float y = isJumping ? jumpImpulse*jumpScale : 0;
		y += Time.deltaTime * -9.81f;
		rigidbody.velocity = new Vector3(x, y, 0);
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
