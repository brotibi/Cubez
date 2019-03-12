using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {

	private float speed = 0.02f;
	public Renderer render;
	public GameObject player;
	private Vector3 CameraOffset;

	// Use this for initialization
	void Start () {
		render = GetComponent<Renderer> ();
		CameraOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//	Vector2 offset = new Vector2 (0f, Time.time * player.transform.position.x * speed);
	//	render.material.mainTextureOffset = offset;

		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector2 offsetNew = new Vector2(0f, player.transform.position.x * -speed);
			render.material.mainTextureOffset = offsetNew;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector2 offsetNew = new Vector2(0f, player.transform.position.x * -speed);
			render.material.mainTextureOffset = offsetNew;
		}
	}
}
