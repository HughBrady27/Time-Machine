using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool paused = false;

	public GameObject PauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (paused) {
				Resume();
			} else {
				Pause();
			}
		}
	}

	public void Resume() {
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		paused = false;
	}

	public void Pause() {
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		paused = true;
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1f;
	}
}
