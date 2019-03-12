using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour {

    public static UIMenu Instance { get; private set; }

    public GameObject errorMessage;
    public static bool errorOnScreen = false;

    public float timer = 0;

    // Use this for initialization
    void Start () {
        Instance = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (errorOnScreen)
            ShowError();
        if (errorOnScreen && timer > 1)
            RemoveError();

    }

    public void startGame()
	{
		SceneManager.LoadScene ("testscene");
	}

	public void Menu(){
		SceneManager.LoadScene ("CubeSelect");
	}
    public void ShowAchievements()
    {
        PlayGamesScript.ShowAchievementsUI();
    }

    public void ShowLeaderboards()
    {
        PlayGamesScript.ShowLeaderboardUI();
    }
    public void ShowError()
    {
        errorMessage.SetActive(true);
        errorOnScreen = true;
        timer = 0;
    }

    public void RemoveError()
    {
        errorMessage.SetActive(false);
        errorOnScreen = false;
    }
}
