using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour {
	//public GameObject cube;
	public float maxPos = 3.0f;
	float timer;
	public float delayTimer = 0.01f;
	public GameObject[] myClouds;
	int cloudNo;


	// Use this for initialization
	void Start () {
		timer = delayTimer;
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) {
			Vector3 cubePos = new Vector3 (Random.Range (-3f, 3f), transform.position.y, transform.position.z);
			Quaternion cloudRotation = new Quaternion (90f,0f,0f,0f);
			cloudNo = Random.Range (0,4);


			Instantiate (myClouds[cloudNo], cubePos, cloudRotation);
			timer = delayTimer;
		}


	}
}
