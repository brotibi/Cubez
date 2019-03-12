using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour {

    private bool IsConnectedToGooglePlay = false;

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
	}

    public bool SignIn()
    {
        if (!IsConnectedToGooglePlay)
        { 
        Social.localUser.Authenticate((bool success) => {
            IsConnectedToGooglePlay = success;
            });
        }

        return IsConnectedToGooglePlay;
    }

    #region Achievements
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public static void ShowAchievementsUI()
    {
        if (Social.localUser.authenticated)
            Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { });
    }

    public static void ShowLeaderboardUI()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
            Debug.Log("Leaderboard Shown");
        } else
        {
            UIMenu.errorOnScreen = true;
        }
    }
    #endregion /Leaderboards
}
