using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TaxiController : MonoBehaviour {

	private float speed = 10;
	public float cubeSpeed;
	Vector3 position;
	public GameObject taxi;
	public GameControlScript control;
	public int coins;
	public Text coinsText;
	private static int health = 100;
	public Text healthText;
	public Renderer rend;
	public BoxCollider box;
	public uiManager ui;
	public GameObject thisTaxi;

	// Use this for initialization
	void Start(){
		position = transform.position;
		rend = thisTaxi.GetComponent<Renderer> ();
		box = thisTaxi.GetComponent<BoxCollider> ();
	}

	void Update(){
		
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);

		position.x += Input.GetAxis ("Horizontal") * cubeSpeed * Time.deltaTime;

		Mathf.Clamp (position.x, -3.0f, 3.0f);
		/*
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (taxi.transform.rotation.y < 255f) {
				taxi.transform.Rotate (new Vector3 (0f, 0f, 0f));
			} else {
				taxi.transform.Rotate (new Vector3(0f,-15f,0f));
			}
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (taxi.transform.rotation.y > 285f) {
				taxi.transform.Rotate (new Vector3 (0f, 0f, 0f));
			} else {
				taxi.transform.Rotate (new Vector3(0f, 15f, 0f));
			}
		}*/

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "CoinPrefab(Clone)") {
			control.PowerupCollected ();
			coins++;
			coinsText.text = "Coins: " + coins;
			other.gameObject.SetActive (false);
		}  else {
			health -= 10;
			healthText.text = "Health: " + health;
			other.gameObject.SetActive (false);
			if (health <= 50) {
				healthText.color = Color.red;
				if (health == 0) {
					rend.enabled = false;
					ui.gameOverOn ();
					box.enabled = false;
				}
			}	

		}

	}

}
