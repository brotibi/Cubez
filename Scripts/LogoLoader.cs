using UnityEngine;
using System.Collections;

public class LogoLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Countdown");

	}
	
	// Update is called once per frame
	private IEnumerator Countdown(){
		yield return new WaitForSeconds (6f);
		Application.LoadLevel (1);
	}
}
