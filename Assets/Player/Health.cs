using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Health : MonoBehaviour {

	public Slider display;
	public ParticleSystem bloodParticles;

	public float maxHealth = 100f;
	public float currentHealth;
	public bool isLiving = true;

	void Start() {
		Heal(maxHealth);
	}

	void LateUpdate() {
		if (!isLiving) { return; } 

		if (currentHealth == 0) {
			isLiving = false;
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
		Damage damage = collision.gameObject.GetComponent<Damage>();
		if (!damage || !isLiving) { return; }

		ContactPoint contact = collision.contacts[0];
		bloodParticles.transform.position = contact.point;

		if (onEnter) {
			bloodParticles.Play();
		}

		Damage(damage.GetAmount() * Time.deltaTime);
	}

	void HealthCollision(Collision collision) {

	}

	void OnSuffocation() {
		isLiving = false;
	}
}
