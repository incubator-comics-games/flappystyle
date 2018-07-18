using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {
	
	private Bird bird;

	private void OnTriggerEnter2D(Collider2D other) {
		bird = other.GetComponent<Bird>();
		if (bird != null) {
			GameController.instance.BirdScored();
			bird.setOnWaterfall(true);
		}
	}
}
