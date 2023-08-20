using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Script.Core
{
    public class BirdCollisionDetection : MonoBehaviour
    {
        public event Action OnPipePassed;
       
        bool isPass = true;

        GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Point") && isPass)
            {
                isPass = false;
                OnPipePassed?.Invoke();
              
                Invoke("TriggerSet", .5f);
            }
        }
       
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Obstacle"))
            {
                gameStateController.SetGameState(GameState.Failed);
              
            }
        }
        void TriggerSet()
        {
            isPass = true;
        }
    }
}
