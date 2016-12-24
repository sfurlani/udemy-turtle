using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public Vector2 damageRange = Vector2.up;


	public float GetAmount() {
		return Random.Range(damageRange.x, damageRange.y);
	}

}
