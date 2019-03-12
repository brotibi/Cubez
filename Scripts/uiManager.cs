using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public static uiManager Instance { get; private set; }

    public Canvas panel;

    public Button[] buttons;
    public Button newBest;
    public Button right;
    public Button left;
    
	private bool gameOver = false;
    private int score;
    public int highScore;

    //public Unlocks unlocker;
    //	public GameObject greenQuad;
    //	public GameObject greenCube;
    //	public GameObject pinkCube;

    public GameObject closeButton;
    public GameObject whiteCube;
    
    public uiSelect uiSelect;

	public Text endScore;
	public Text endHighScore;
	public Text unlockText;
    public Text dead;

    public Text rText;
    public Text lText;

    [SerializeField]
    public Text scoreText;

    public Text healthText;
    public Text coinsText;

    public GameObject cubeSelect;
    //	public GameObject cubo;
    //	public GameObject defaultCube;

    // Use this for initialization
    void Start()
    {
        score = 0;
        Instance = this;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        gameOver = false;

        whiteCube.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;

        /*
		if (uiSelect.greenSelected == true) {
			whiteCube.gameObject.SetActive (false);
			pinkCube.gameObject.SetActive (false);
			greenCube.SetActive (true);
			curvyCube.SetActive (false);
		} else if (uiSelect.greenSelected == false && uiSelect.pinkSelected == false && uiSelect.curvySelected == false) {
			whiteCube.gameObject.SetActive (true);
		} else if (uiSelect.pinkSelected == true && uiSelect.greenSelected == false && uiSelect.curvySelected == false) {
			whiteCube.gameObject.SetActive (false);
			greenCube.SetActive (false);
			pinkCube.SetActive (true);
			curvyCube.SetActive (false);
		} else if (uiSelect.pinkSelected == false && uiSelect.greenSelected == false && uiSelect.curvySelected == true) {
			whiteCube.gameObject.SetActive (false);
			pinkCube.gameObject.SetActive (false);
			greenCube.gameObject.SetActive(false);
			curvyCube.gameObject.SetActive(true);
		}
	*/
        /*if (highScore > 200 && unlocker.greenUnlocked == false && gameOver == true) {
			unlocker.greenUnlocked = true;
			greenQuad.SetActive (true);
			unlockText.gameObject.SetActive(true);
			endScore.gameObject.SetActive (false);
			endHighScore.gameObject.SetActive (false);
			closeButton.SetActive (true);
			greenCube.SetActive (true);
			panel.enabled = false;
			foreach (Button button in buttons) {
				button.gameObject.SetActive (false);
			}
			PlayerPrefsX.SetBool ("greenUnlocked", true);
		}*/
    }

    /*
        public void CloseUnlockScreen()
        {
            greenQuad.SetActive (false);
            greenCube.SetActive (false);
            unlockText.enabled = false;
            closeButton.SetActive (false);
            panel.enabled = true;
            endScore.gameObject.SetActive (true);
            endHighScore.gameObject.SetActive (true);
            foreach (Button button in buttons) {
                button.gameObject.SetActive (true);
            }
        }
    */
    public void OpenCubeSelect()
    {
        panel.gameObject.SetActive(true);
        cubeSelect.SetActive(true);
    }

	public void setScore(int sc){
		score = sc;
	}

    public void CloseCubeSelect()
    {
        panel.gameObject.SetActive(false);
        cubeSelect.SetActive(false);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highScore", highScore);
    }

    IEnumerator PlayLevel()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("testscene");
    }

    IEnumerator MenuLevel()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("menuScene");
    }

    public void gameOverOn()
    {
        StartCoroutine(gameOverActivated());
    }

    private IEnumerator gameOverActivated()
    {
        gameOver = true;
        endScore.text = "Score: " + score;
        yield return new WaitForSeconds(0.01f);

        dead.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
		
		dead.gameObject.SetActive(false);
		Destroy(dead.gameObject);

        

        removeGameText();

        if(score > 100)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_100_points);
        if(score > 200)
            PlayGamesScript.UnlockAchievement(GPGSIds.achievement_200_points);

        if (score > highScore)
        {
            highScore = score;
            endHighScore.text = "High Score: " + highScore;
            newBest.gameObject.SetActive(true);
        }
        else
        {
            highScore = score;
            newBest.gameObject.SetActive(false);
        }

        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboard, score);

        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        panel.gameObject.SetActive(true);
        endScore.gameObject.SetActive(true);
        endHighScore.gameObject.SetActive(true);
    }

    public void Play()
    {
        StartCoroutine(PlayLevel());
    }

    public void Pause()
    {

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }


    public void Menu()
    {
        StartCoroutine(MenuLevel());
    }

    public void removeGameText()
    {
        coinsText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        rText.gameObject.SetActive(false);
        lText.gameObject.SetActive(false);
    }

    
}
