using UnityEngine;
using Script.Core;

namespace Script.Scores
{
    public class HighScore : MonoBehaviour
    {
        Score score;
        private void Awake()
        {
            if (!PlayerPrefs.HasKey("HighScore"))
            {
                print("sssss");
                PlayerPrefs.SetInt("HighScore", 0);
            }
            score = FindObjectOfType<Score>();
            score.OnScored += SetHighScore;
           
        }
        void SetHighScore()
        {
            PlayerPrefs.SetInt("HighScore", Mathf.Max(score.ScoreCounter, PlayerPrefs.GetInt("HighScore")));
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }
    }
}
