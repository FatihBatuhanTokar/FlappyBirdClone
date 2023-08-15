using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Script.Core
{
    public enum GameState
    {
        GameNotstarted,
        GameStarted,
        Failed
    }
    public class GameStateController : MonoBehaviour
    {
        public GameState currentGameState;
        public event Action<GameState> OnGameStateChanged;
        
        void Awake()
        {
            currentGameState = GameState.GameNotstarted;
        }

        public void SetGameState(GameState gameState)
        {
            currentGameState = gameState;
            OnGameStateChanged?.Invoke(gameState);
        }

       
    }
}
