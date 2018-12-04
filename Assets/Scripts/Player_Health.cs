using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

//    public int playerHP = 3;

    void Update() {
        if (gameObject.transform.position.y < -15) {
            SceneManager.LoadScene("GameOver");
        }
	}
}
