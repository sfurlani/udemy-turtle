using UnityEngine;
using System.Collections;

public class DebugPlayer : MonoBehaviour {

	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal") * speed;
		float y = Input.GetAxis("Vertical") * speed;
		transform.Translate(x, y, 0, Space.World);
			
	}
}
