using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnClicked;
        public event Action OnGameStarted;
        GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
        }
        void Update()
        {

            if (Input.GetMouseButtonDown(0)) // Kullanýcý ekrana tikladiðinda calisacak yöntemi cagirir
            {
                if (gameStateController.currentGameState==GameState.GameNotstarted)
                {
                    gameStateController.SetGameState(GameState.GameStarted);
                }
                OnClick();
            }
        }
        void OnClick() // Kullanýcý ekrana tikladiðinda abonelere haber veren  yöntem
        {
            OnClicked?.Invoke();
        }
       
    }
}
