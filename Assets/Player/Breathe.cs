using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Breathe : MonoBehaviour {
	public Slider display;
	public float decay = 0.1f;
	public float current = 1f;
	public bool isBreathing = true;

	void Start() {
		Breath();
	}

	void LateUpdate () {
		if (!isBreathing) { return; }
		current = Mathf.Clamp(current - Time.deltaTime * decay, 0, 1f);

		if (current <= 0) {
			isBreathing = false;
			SendMessage("OnSuffocation");
		}

		if (display) {
			display.normalizedValue = current;
		}

	}

	void Breath(float air = 1f) {
		current = Mathf.Clamp((current + air)/2f, 0f, 1f);
		isBreathing = true;
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.tag != "Water") { return; }

		Breath();
	}

	void OnDeath() {
		isBreathing = false;
	}

}
