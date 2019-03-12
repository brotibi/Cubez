using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
	public float speed = 5f;
	public Transform cloudTransform;

	// Use this for initialization
	void Start () {
		cloudTransform = GetComponent<Transform> ();
		cloudTransform.Rotate (new Vector3 (90f, 0f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(0,1,0) * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Powerup(Clone)" || other.gameObject.name == "AntiPowerUp(Clone)") {
			Destroy (other.gameObject);
		}
	}
}

