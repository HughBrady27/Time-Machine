using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_Behaviour : MonoBehaviour {

	public int GoonSpeed = 3;
	public int xMoveDirection;
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection, 0) * GoonSpeed;
		if (hit.distance < 0.7f)
		{
			FlipGoon();

			// Kill Player if he touches side of goon
			if (hit.collider.tag == "Player") {
				Destroy (hit.collider.gameObject);
			}
		}
	}

	void FlipGoon() {
		xMoveDirection *= -1;
	}
}
