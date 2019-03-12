using UnityEngine;
using System.Collections;

public class RightMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0) {
			transform.Translate(0.2f, 0f, 0f);
		}

		if (Input.GetMouseButtonDown(1))
			transform.Translate (0.2f, 0f, 0f);
	}
}
