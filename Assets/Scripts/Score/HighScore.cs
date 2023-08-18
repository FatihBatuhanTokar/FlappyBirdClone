using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Score
{
    public class HighScore : MonoBehaviour
    {

        void Start()
        {
            SetHighScore(0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetHighScore(int Score)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.Max(0,PlayerPrefs.GetInt("HighScore"), Score));
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
        }
    }
}
