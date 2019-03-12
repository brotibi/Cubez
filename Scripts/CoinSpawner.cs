using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	private GameObject player;
	public float maxPos = 3.0f;
	float timer;
	private float delayTimer = 0.9f;

	public GameObject[] myCubes;
	int cubeNo;
	private float zPos;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		timer = 0;
		zPos = player.transform.position.z + 60 + 3.0f;
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer > delayTimer)
		{
			//cubePos is where the next Cube will spawn
			Quaternion cloudRotation = new Quaternion(90f, 0f, 0f, 0f);
			Vector3 cubePos = new Vector3(Random.Range(player.transform.position.x - 12f, player.transform.position.x + 12f), transform.position.y, transform.position.z + zPos);

			cubeNo = Random.Range(0, 1);

			//20% of the time it will spawn two cubes at once
			int random = Random.Range(0, 100);
			if (random < 1)
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
			else if (random < 2)
			{
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
				cubePos = cubePos + new Vector3((int)Random.Range(-12, -1), 0f, 0);
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
			}
			else
			{
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
				cubePos = cubePos + new Vector3((int)Random.Range(-12, -1), 0f, 0);
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
				cubePos = cubePos + new Vector3((int)Random.Range(14, 22), 0f, 0);
				Instantiate(myCubes[cubeNo], cubePos, cloudRotation);
			}
			timer = Random.Range(0.0f, delayTimer);
		}


	}
}
