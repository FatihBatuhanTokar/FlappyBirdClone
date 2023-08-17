using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Core;
namespace Script.UI
{
    public class InGameUI : MonoBehaviour
    {
        GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
            gameStateController.OnGameStateChanged += OnPipePass;
        }

        void OnPipePass(GameState gameState)
        {
            Debug.Log("Puan yazildi UI");
        }
    }
}
