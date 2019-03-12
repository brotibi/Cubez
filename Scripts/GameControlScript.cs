using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{

	private static int score = 0;
    private static bool gameOver = false;

	public static bool scoreIncreasing = true;
	private float scoreIncInterval = 0.4f;

    private uiManager ui;

    public void Start()
    {
		gameOver = false;
		EnemyCarMove.stopCubes = false;
		score = 0;
		ui = GameObject.FindGameObjectWithTag("uiManager").GetComponent<uiManager>();

		InvokeRepeating("scoreUpdate", scoreIncInterval, scoreIncInterval);
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	void scoreUpdate()
	{
		if (!gameOver && scoreIncreasing)
		{
			score++; //*(int)(EnemyCarMove.getSpeed()/20 + .5);
			ui.setScore (score);
		}
	}

	public static int getScore() {
		return score;
	}

	public void endCurrentSession() {
		gameOver = true;
		CubeSpawner.globalSpawning = false;
		EnemyCarMove.stopCubes = true;
		ui.gameOverOn();
	}

	public static bool isGameOver(){
		return gameOver;
	}

	public static void setGameOver(bool state) {
		gameOver = state;
	}

    public void PowerupCollected()
    {
        
    }

    public void AntiPowerUpCollected()
    {
		
    }
}
