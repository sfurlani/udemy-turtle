using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Animator) )]
public class MenuInterface : MonoBehaviour {

	private Animator animator;

	void OnEnable() {
		GameManager.OnGameModeDidChange += OnGameModeDidChange;
	}

	void OnDisable() {
		GameManager.OnGameModeDidChange -= OnGameModeDidChange;
	}

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGameModeDidChange(GameMode newMode) {
		if (newMode == GameMode.Menu) {
			ShowInterface();
		} else {
			HideInterface();
		}
	}

	void ShowInterface(bool animate = true) {
		animator.SetBool("animate", animate);
		animator.SetTrigger("show");
	}

	void HideInterface(bool animate = true) {
		animator.SetBool("animate", animate);
		animator.SetTrigger("hide");
	}

	public void PlayGame() {
		GameManager.mode = GameMode.Play;
	}
}
