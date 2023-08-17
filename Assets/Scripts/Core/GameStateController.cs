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
        public GameState CurrentGameState { get; private set; }
        public event Action<GameState> OnGameStateChanged;
        
        void Awake()
        {
            SetGameState(GameState.GameNotstarted);
        }

        public void SetGameState(GameState gameState)
        {
            CurrentGameState = gameState;
            OnGameStateChanged?.Invoke(gameState);
        }

       
    }
}
