using UnityEngine;
using System.Collections;

public class EnemyCarMove : MonoBehaviour {
	public static bool stopCubes = false;
	private static float speed = 20f;
    private float lifetimeLimit = 10.0f;
    private float lifetime = 0.0f;

	private bool shrinking = false;
	private float shrinkSpeed = 10f;

	private CubeSpawner spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag("CubeSpawner").GetComponent<CubeSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (stopCubes == true) {
			speed = 0f;
		}

		transform.Translate (new Vector3(0,0,1) * speed * Time.deltaTime);

		if (shrinking) {
				this.transform.localScale -= Vector3.one * Time.deltaTime * shrinkSpeed;
		}
		if (this.transform.localScale.x < 0) {
            Destroy(this.gameObject);
        }

		//deletes at position -30 on z-axis.
		if (transform.position.z < -40f) {
			Destroy (this.gameObject);
		}
            
    }

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.tag == "Player" && !GameControlScript.isGameOver())
		{
			scaling();
		}
		else if (other.gameObject.tag == "Enemy" || other.gameObject.name == "EnemyCube(Clone)")
		{
			Destroy (other.gameObject);
			//spawner.spawnNewCube ();
		}
		else if (other.gameObject.name == "Powerup(Clone)" || other.gameObject.name == "AntiPowerUp(Clone)") 
		{
			Destroy (other.gameObject);
		}

	} 


	private void scaling()
	{
		shrinking = true;
	}

    public static void setSpeed(float spd)
    {
        speed = spd;
    }

    public static float getSpeed()
    {

        return speed;
    }
}
