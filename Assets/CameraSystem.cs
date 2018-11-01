using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    private GameObject player;

    // These vars define the boundaries that the camera can navigate to
    public float xMin = -2;
    public float xMax = 100;
    public float yMin;
    public float yMax;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // Attach our x and y vars to the player's position while remaining in the min max range
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);

        // Have the camera follow our x y co-ords, by extension following the player
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
