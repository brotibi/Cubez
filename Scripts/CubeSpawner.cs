using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {
    
	private GameObject myCube;

    private GameObject player;
	private Quaternion cubeRotation;

    private float timer = 0f;
	private float delayTimer = 0.5f;
	private float delayLowCap = 0.01f;

    private float playerX;

	private float cubeRange = 16f;
	private float zPos;
	private float zPosRange = 5f;

	public static bool globalSpawning;
	private bool spawning;

	// Use this for initialization
	public void onStart () 
	{
		spawning = false;
		globalSpawning = true;

		timer = 0f;
		delayTimer = 0.5f;
		delayLowCap = 0.01f;

        player = GameObject.FindGameObjectWithTag("Player");
        zPos = player.transform.position.z + 105f;
		cubeRotation = new Quaternion(90f, 0f, 0f, 0f);
    }
	
	// Update is called once per frame
	public void onUpdate () 
	{
		//playerX = player.transform.position.x;
		if (spawning && globalSpawning && myCube != null) 
		{
			timer += Time.deltaTime;
		if (timer > delayTimer && player != null && myCube != null && GameControlScript.isGameOver() != true) 
			{
				spawnNewCube ();
				timer = 0;
			}
		}
	}

	public void spawnNewCube()
	{
		//25% of the time it will spawn three cubes at once
		int percentChance = Random.Range(0, 100);

		if (percentChance < 25) {
			Vector3 cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
			cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
			cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
		} else if (percentChance < 50) {
			Vector3 cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
			cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
		} else {
			Vector3 cubePos = randomCubePos ();
			Instantiate (myCube, cubePos, cubeRotation);
		}
	}

	public Vector3 randomCubePos()
	{
		return new Vector3(Random.Range(player.transform.position.x - cubeRange, player.transform.position.x + cubeRange),
							myCube.transform.localScale.y / 2, 
							Random.Range(-zPosRange, zPosRange) + zPos);
	}

	//Gets the delayTimer which is the delay between each instantiation of new cubes
	public float getDelayTimer(){
		return delayTimer;
	}

	public void setDelayTimer(float time) {
		delayTimer = time;
	}

	//gets the delayTimer's minimum delay to prevent ridiculous spawning rates
	public float getDelayLowCap(){
		return delayLowCap;
	}

	public void setDelayLowCap(float time) {
		delayLowCap = time;
	}

	//gets the range/variability of the z position of spawned cubes
	public float getZposRange(){
		return zPosRange;
	}

	public void setZposRange(float pos){
		zPosRange = pos;
	}

	//gets the range (x values) of spawned cubes
	public float getCubeRange(){
		return cubeRange;
	}

	public void setCubeRange(float pos){
		cubeRange = pos;
	}

	public void setCubeRotation(Quaternion rot) {
		cubeRotation = rot;
	}

	public void startSpawning(){
		spawning = true;
	}

	public bool isSpawning(){
		return spawning;
	}

	public void setMyCube(GameObject cube){
		myCube = cube;
	}
}