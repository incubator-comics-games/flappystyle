using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePool : MonoBehaviour {

	private GameObject[] slides;
	public int slidePoolSize = 2;
	public GameObject slidePrefab;
	public float spawnRate = 3f;
	public float slideMin = -2f;
	public float slideMax = 4.5f;

	private float spawnXPos = 10f;
	private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
	private int currentSlide = 0;
	private Quaternion spawnRotation = Quaternion.Euler(0,0,270);

	private float timeSinceLastSpawned;

	//Use this for initialization
	void Start () {
		timeSinceLastSpawned = spawnRate;
		slides = new GameObject[slidePoolSize];
		for (int i = 0; i < slidePoolSize; i++) {
			slides[i] = (GameObject) Instantiate(slidePrefab, objectPoolPosition, spawnRotation);
		}
	}

	// Update is called once per frame
	void Update () {
		timeSinceLastSpawned += Time.deltaTime;

		if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
			timeSinceLastSpawned = 0;
			float spawnYPos = Random.Range(slideMin, slideMax);
			slides[currentSlide].transform.position = new Vector2(spawnXPos, spawnYPos);
			currentSlide = (currentSlide + 1) % slidePoolSize;
		}
	}
}
