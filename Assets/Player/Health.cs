using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Health : MonoBehaviour {

	public Slider display;
	public ParticleSystem bloodParticles;

	public float maxHealth = 100f;
	public float currentHealth;

	void Start() {
		Heal(maxHealth);
	}

	void LateUpdate() {
		if (GameManager.mode != GameMode.Play) { return; }

		if (currentHealth == 0) {
			SendMessage("OnDeath");
		}

		if (display) {
			display.normalizedValue = currentHealth / maxHealth;
		}
	}

	void Heal(float amount = 0f) {
		currentHealth = Mathf.Clamp(currentHealth + amount, 0f, maxHealth);

	}

	void Damage(float amount = 0f) {
		currentHealth = Mathf.Clamp(currentHealth - amount, 0f, maxHealth);
	}

	void OnCollisionEnter(Collision collision) {
		DamageCollision(collision, true);
	}

	void OnCollisionStay(Collision collision) {
		DamageCollision(collision);
	}

	void OnCollisionExit(Collision collision) {
		bloodParticles.Stop();
	}

	void DamageCollision(Collision collision, bool onEnter = false) {
		if (GameManager.mode != GameMode.Play) { return; }

		Damage damage = collision.gameObject.GetComponent<Damage>();
		if (!damage) { return; }

		ContactPoint contact = collision.contacts[0];
		bloodParticles.transform.position = contact.point;

		if (onEnter) {
			bloodParticles.Play();
		}

		Damage(damage.GetAmount() * Time.deltaTime);
	}

	void HealthCollision(Collision collision) {

	}

}
