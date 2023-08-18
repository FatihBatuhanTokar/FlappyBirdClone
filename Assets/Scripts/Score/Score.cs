using Script.Core;
using UnityEngine;

namespace Script.Score
{
    public class Score : MonoBehaviour
    {
        public int ScoreCounter { get; private set; }

        BirdCollisionDetection birdCollisionDetection;
        private void Awake()
        {
            birdCollisionDetection = FindObjectOfType<BirdCollisionDetection>();
            birdCollisionDetection.OnPipePassed += OnScore;

        }

        void OnScore()
        {
            ScoreCounter += 1;
            Debug.Log(ScoreCounter);
        }
    }
}
