using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiSelect : MonoBehaviour {

	public bool greenSelected;
	public bool pinkSelected;
	public bool curvySelected;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		greenSelected = false;
		pinkSelected = false;
		curvySelected = false;
		greenSelected = PlayerPrefsX.GetBool ("greenSelected", greenSelected);
		pinkSelected = PlayerPrefsX.GetBool ("pinkSelected", pinkSelected);
		curvySelected = PlayerPrefsX.GetBool ("curvySelected", curvySelected);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play()
	{
		greenSelected = false;
		pinkSelected = false;
		curvySelected = false;
		PlayerPrefsX.SetBool ("greenSelected", false);
		PlayerPrefsX.SetBool ("pinkSelected", false);
		PlayerPrefsX.SetBool ("curvySelected", false);
		SceneManager.LoadScene ("testscene");
	}

	public void Back()
	{
		SceneManager.LoadScene ("MenuScene");
	}

	public void GreenCube()
	{	greenSelected = true;
		pinkSelected = false;
		curvySelected = false;
		SceneManager.LoadScene ("testscene");
		PlayerPrefsX.SetBool ("greenSelected", true);
		PlayerPrefsX.SetBool ("pinkSelected", false);
		PlayerPrefsX.SetBool ("curvySelected", false);
	}

	public void PinkCube()
	{
		greenSelected = false;
		pinkSelected = true;
		curvySelected = false;
		SceneManager.LoadScene ("testscene");
		PlayerPrefsX.SetBool ("greenSelected", false);
		PlayerPrefsX.SetBool ("pinkSelected", true);
		PlayerPrefsX.SetBool ("curvySelected", false);
	}

	public void CurvyCube()
	{
		greenSelected = false;
		pinkSelected = false;
		curvySelected = true;
		SceneManager.LoadScene ("testscene");
		PlayerPrefsX.SetBool ("greenSelected", false);
		PlayerPrefsX.SetBool ("pinkSelected", false);
		PlayerPrefsX.SetBool ("curvySelecteed", true);
	}

	void OnDestroy(){
		PlayerPrefsX.SetBool ("greenSelected", greenSelected);
		PlayerPrefsX.SetBool ("pinkSelected", pinkSelected);
		PlayerPrefsX.SetBool ("curvySelected", curvySelected);
	}
}
