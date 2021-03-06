﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private bool isAdvancing = true;
	[SerializeField] private float playSpeed = 0.01f;
	[SerializeField] private float jumpImpulse = 10f;
	[HideInInspector] [SerializeField] private bool isJumping = false;
	[HideInInspector] [SerializeField] private float jumpScale = 0;


	new private Rigidbody rigidbody;
	private Animator animator;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.mode != GameMode.Play) { return; }

		if (Input.GetButtonDown("Jump")) { 
			Jump();
		}
		float x = isAdvancing ? playSpeed : 0;
		float y = isJumping ? jumpImpulse*jumpScale : 0;
		y += Time.deltaTime * -9.81f;
		rigidbody.velocity = new Vector3(x, y, 0);
	}

	public void Jump() {
		if (GameManager.mode != GameMode.Play) { return; }
		animator.SetTrigger("jump");
	}

	void OnSuffocation() {
		OnDeath();
	}

	void OnDeath() {
		animator.SetTrigger("die");
		GameManager.mode = GameMode.End;
		rigidbody.useGravity = true;
		rigidbody.constraints = RigidbodyConstraints.None;
	}
}
