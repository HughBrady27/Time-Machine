using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {
    bool sound = true;

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToggleMusic() {
        if (sound){
            AudioListener.pause = !AudioListener.pause;
        }
    }

    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

}
