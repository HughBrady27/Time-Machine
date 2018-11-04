using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    public bool isDead;

	void Start () {
        isDead = false;
	}

    void Update() {
        if (gameObject.transform.position.y < -10) {
            isDead = true;
        }
        if (isDead == true) {
            StartCoroutine("Die");
        }
	}

    IEnumerator Die ()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}
