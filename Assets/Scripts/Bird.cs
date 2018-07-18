using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float upForce = 200f;
	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool onWaterfall = false;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (isDead == false) {
			rb2d.velocity = new Vector2(-GameController.instance.scrollSpeed, rb2d.velocity.y);
			if (onWaterfall) {
				rb2d.velocity = new Vector2(0, rb2d.velocity.y);
			}
			if (GameController.instance.GetInput()) {
				setOnWaterfall(false);
				rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
				rb2d.AddForce(new Vector2(0, upForce));
				anim.SetTrigger("Flap");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Slide") {
			isDead = false;
		} else {
			rb2d.velocity = Vector2.zero;
			isDead = true;
			anim.SetTrigger("Die");
			GameController.instance.BirdDied();
		}
	}

	public void setOnWaterfall(bool val){
		onWaterfall = val;
	}
}
