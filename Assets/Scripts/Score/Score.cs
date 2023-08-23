using Script.Core;
using UnityEngine;
using System;
namespace Script.Scores
{
    public class Score : MonoBehaviour
    {
        public int ScoreCounter { get; private set; }

        public BirdCollisionDetection birdCollisionDetection;

        public event Action OnScored;
        private void Awake()
        {
            //birdCollisionDetection = FindObjectOfType<BirdCollisionDetection>();
            birdCollisionDetection.OnPipePassed += OnScore;

        }

        void OnScore()
        {
            ScoreCounter += 1;
            OnScored?.Invoke();
            Debug.Log(ScoreCounter);
        }
    }
}
