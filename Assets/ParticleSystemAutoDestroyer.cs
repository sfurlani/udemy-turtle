using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ParticleSystem))]
public class ParticleSystemAutoDestroyer : MonoBehaviour {

	private ParticleSystem system;

	// Use this for initialization
	void Start () {
		system = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!system.IsAlive()) { Destroy(gameObject); }
	}
}
