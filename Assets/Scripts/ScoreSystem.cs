using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour {

    private float timeLeft = 100;
    public int score = 0;
    public int highScore;
    public static bool won = false;
    public GameObject timeUI;
    public GameObject scoreUI;
    public GameObject highScoreUI;
    public GameObject WinMenuUI;
    public GameObject finalTimeUI;
    public GameObject finalScoreUI;


    void Start () {
        highScore = PlayerPrefs.GetInt("HiScore", 0);
        won = false;
        Time.timeScale = 1f;
    }

	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text = "Time: " + (int) timeLeft;
        scoreUI.gameObject.GetComponent<Text>().text = "Score: " + score;
        highScoreUI.gameObject.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HiScore", 0); 
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (won) {
			SetWinActive();
		}

	}

    // IF PLAYER COLLIDES WITH DELOREAN OR MAGAZINE
    void OnTriggerEnter2D (Collider2D trig) {
        Debug.Log("Trigger");
        if (trig.gameObject.tag == "Delorean") {
            CountScore();
            
        }
        if (trig.gameObject.tag == "Magazine") {
            score += 50;
            Destroy (trig.gameObject);
        }
    }

    void CountScore() {
        score = score + (int)(timeLeft * 10);
        PlayerPrefs.SetInt("HiScore", score);
        won = true;
    }

    public void SetWinActive() {
        WinMenuUI.SetActive(won);
        Time.timeScale = 0f;
        finalTimeUI.gameObject.GetComponent<Text>().text = "Time: " + (int) timeLeft;
        finalScoreUI.gameObject.GetComponent<Text>().text = "Score: " + score;
        highScoreUI.gameObject.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HiScore", 0); 
    }

    // Win Screen Here
    public void Continue() {
		won = false;
        WinMenuUI.SetActive(won);
		SceneManager.LoadScene("Level2");
	}

    public void Retry() {
		won = false;
        WinMenuUI.SetActive(won);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit() {
		won = false;
        WinMenuUI.SetActive(false);
		SceneManager.LoadScene("MainMenu");
	}
}
