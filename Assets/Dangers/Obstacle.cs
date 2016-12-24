using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	
	public Vector3 minPosition = Vector3.zero;
	public Vector3 maxPosition = Vector3.zero;
	public Vector3 minRotation = Vector3.zero;
	public Vector3 maxRotation = Vector3.one*360f;
	public float minScale = 1f;
	public float maxScale = 1f;
}
