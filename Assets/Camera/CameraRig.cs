using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour {

	[Tooltip ("GameObject for the Camera Rig to Follow")]
	public GameObject target;

	[Tooltip ("0 = no tracking, !0 = tracking")]
	public Vector3 tracking = Vector3.one;

	[Tooltip ("Amount of movement (in Game Units) to lag behind the player object")]
	public Vector3 negativeSpace = Vector3.zero;

	[Tooltip ("Relative Speed for the camera to rotate around")]
	public float rotationSpeed = 10f;

	[Tooltip ("Should the camera rotate to look at the target?")]
	public Vector3 lookAt = Vector3.zero;

	/// <summary>
	/// Private variable to store the offset distance between the player and camera
	/// </summary>
	private Vector3 offset = Vector3.zero;

	private Vector3 originalRotation;

	new private Camera camera;

	// Use this for initialization
	void Start () 
	{
		camera = GetComponentInChildren<Camera>();
		originalRotation = transform.eulerAngles;
		offset = transform.position - target.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		transform.position = _ComputeVectorPosition(transform.position, target.transform.position + offset, negativeSpace);
		_ComputeLookAtRotation(target.transform);

	}

	private Vector3 _ComputeVectorPosition(Vector3 current, Vector3 target, Vector3 negative) {
		float x = tracking.x == 0 ? current.x : _ComputeAxisPosition(current.x, target.x, negative.x);
		float y = tracking.y == 0 ? current.y :_ComputeAxisPosition(current.y, target.y, negative.y);
		float z = tracking.z == 0 ? current.z :_ComputeAxisPosition(current.z, target.z, negative.z);
		return new Vector3(x, y, z);
	}

	private float _ComputeAxisPosition(float current, float target, float negative) {
		float result = current;
		float delta = current - target;
		if (Mathf.Abs(delta) > negative) {
			result = target + Mathf.Clamp(delta, -negative, negative);
		}
		return result;
	}

	private void _ComputeLookAtRotation(Transform target) {
		if (lookAt == Vector3.zero) { return; }

		Vector3 original = camera.transform.eulerAngles;
		camera.transform.LookAt(target);
		Vector3 looked = camera.transform.eulerAngles;
		float x = original.x + (looked.x - original.x) * lookAt.x;
		float y = original.y + (looked.y - original.y) * lookAt.y;
		float z = original.z + (looked.z - original.z) * lookAt.z;
		camera.transform.rotation = Quaternion.Euler(x, y, z);
	}

}
