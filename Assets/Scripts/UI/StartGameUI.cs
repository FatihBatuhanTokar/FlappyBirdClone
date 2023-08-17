using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Core;
namespace Script.UI
{
    public class StartGameUI : MonoBehaviour
    {
        GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
            gameStateController.OnGameStateChanged += OnStartGame;
        }

        // Update is called once per frame
        void OnStartGame(GameState gameState)
        {
            if (gameStateController.CurrentGameState==GameState.GameNotstarted)
            {
                Debug.Log("Oyun Basladi UI");
            }
            
        }
    }
}
