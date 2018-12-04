using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private float timeLeft = 50;
    public int score = 0;
    public GameObject timeUI;
    public GameObject scoreUI;
 
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text = "Time: " + (int) timeLeft;
        scoreUI.gameObject.GetComponent<Text>().text = "Score: " + score;
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("GameOver");
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
    }


}
