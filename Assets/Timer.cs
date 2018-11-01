using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft = 300;
    public GameObject timeUI;
    	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text = "Time: " + (int) timeLeft;

        if (timeLeft < 0.1f)
        {
            // Lose condition
        }
	}
}
