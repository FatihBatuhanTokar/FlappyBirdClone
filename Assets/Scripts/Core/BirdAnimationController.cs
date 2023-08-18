using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class BirdAnimationController : MonoBehaviour
    {
        Animator anim;
        GameStateController gameStateController;
        void Awake()
        {
            anim = GetComponent<Animator>();
            gameStateController = FindObjectOfType<GameStateController>();
            gameStateController.OnGameStateChanged += OnGameStateChange;
        }
        void OnGameStateChange(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.GameStarted:
                    anim.SetTrigger("Fly");
                    break;
                case GameState.Failed:
                    anim.speed = 0;
                    break;
            }
        }
    }
}
