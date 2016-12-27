using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Breathe : MonoBehaviour {
	public Slider display;
	public float decay = 0.1f;
	public float current = 1f;

	void Start() {
		Breath();
	}

	void LateUpdate () {
		if (GameManager.mode != GameMode.Play) { return; }

		current = Mathf.Clamp(current - Time.deltaTime * decay, 0, 1f);

		if (current <= 0) {
			SendMessage("OnSuffocation");
		}

		if (display) {
			display.normalizedValue = current;
		}

	}

	void Breath(float air = 1f) {
		if (GameManager.mode != GameMode.Play) { return; }
		current = Mathf.Clamp((current + air)/2f, 0f, 1f);
	}

	void OnCollisionStay(Collision collision) {
		if (GameManager.mode != GameMode.Play) { return; }
		if (collision.gameObject.tag != "Water") { return; }

		Breath();
	}

}
