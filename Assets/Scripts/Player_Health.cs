using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

	void Start () {
        isDead = false;
	}

    void Update() {
        if (gameObject.transform.position.y < -7) {
            Die();
        }
	}

    IEnumerator Die ()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOver");
    }
}
