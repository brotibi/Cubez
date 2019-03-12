using UnityEngine;

public class ManagerScript : MonoBehaviour {

    public static ManagerScript Instance { get; private set; }
    public static int Counter { get; private set; }

	// Use this for initialization
	void Start () {
        Instance = this;
	}

    public void RestartGame()
    {
        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboard, Counter);
        Counter = 0;
    }
}
