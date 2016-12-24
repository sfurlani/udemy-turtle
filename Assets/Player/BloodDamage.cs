using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class BloodDamage : MonoBehaviour {

	[SerializeField] private GameObject bloodParticles;

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Water") { return; }

		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		pos.z -= 0.1f;
		GameObject blood = Instantiate(bloodParticles, pos, rot) as GameObject;
		blood.transform.parent = transform;
	}
}
