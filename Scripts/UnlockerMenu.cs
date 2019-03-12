using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockerMenu : MonoBehaviour {

	public GameObject GreenCube;
	public GameObject BlackCube;
	public GameObject PinkLockedCube;
	public GameObject PinkCube;
	public GameObject curvyCube;
	public uiManager ui;
	public Button selectGreen;
	public Button selectPink;
	public bool greenUnlocked;
	public bool pinkUnlocked;
	public bool curvyUnlocked;

	// Use this for initialization
	void Start () {
		greenUnlocked = PlayerPrefsX.GetBool ("greenUnlocked", greenUnlocked);
		pinkUnlocked = PlayerPrefsX.GetBool ("pinkUnlocked", pinkUnlocked);
		curvyUnlocked = PlayerPrefsX.GetBool ("curvyUnlocked", curvyUnlocked);
	}

	// Update is called once per frame
	void Update () {
		if (greenUnlocked == true) {
			BlackCube.gameObject.SetActive (false);
			GreenCube.gameObject.SetActive (true);
			selectGreen.gameObject.SetActive (true);
		}
		if(pinkUnlocked == true){
			PinkLockedCube.gameObject.SetActive (false);
			PinkCube.gameObject.SetActive (true);
			selectPink.gameObject.SetActive (true);
		}
		if (curvyUnlocked == true) {
			curvyCube.gameObject.SetActive (true);
		}

	}
}
