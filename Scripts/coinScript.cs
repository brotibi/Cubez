using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {

	private float rotationSpeed;


	// Use this for initialization
	void Start () {
		rotationSpeed = Random.Range (180f, 220f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (rotationSpeed, 0f, 0f) * Time.deltaTime);
	//	speed += 0.02f;
		if(GameControlScript.getScore() == 0){

			rotationSpeed = Random.Range (180f, 220f);
		}
		if(GameControlScript.isGameOver()==true){

			rotationSpeed = 0f;
		}

	}

}
