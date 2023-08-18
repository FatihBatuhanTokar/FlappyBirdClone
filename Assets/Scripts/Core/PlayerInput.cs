using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnClicked;
        GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
        }
        void Update()
        {

            if (Input.GetMouseButtonDown(0)) // Kullan?c? ekrana tikladi?inda calisacak y?ntemi cagirir
            {
                if (gameStateController.CurrentGameState==GameState.GameNotstarted)
                {
                    gameStateController.SetGameState(GameState.GameStarted);
                    
                }
                OnClick();
            }
        }
        void OnClick() // Kullan?c? ekrana tikladi?inda abonelere haber veren  y?ntem
        {
            OnClicked?.Invoke();
        }
       
    }
}
