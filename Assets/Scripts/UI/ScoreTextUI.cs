using UnityEngine;
using TMPro;
using Script.Scores;

namespace Script.UI
{
    public class ScoreTextUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI ScoreText, HighScoreText;
        Score score;
        private void Awake()
        {
            score = FindObjectOfType<Score>();
            score.OnScored += SetScoreText;
        }


        void SetScoreText()
        {
            ScoreText.text = score.ScoreCounter.ToString();
            HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

    }
}
