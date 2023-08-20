using Script.Core;
using UnityEngine;

namespace Script.UI
{
    public class EndGameUI : MonoBehaviour
    {
        GameStateController gameStateController;
        [SerializeField] GameObject EndGameUIPanel;

        private void Awake()
        {
            gameStateController = FindObjectOfType<GameStateController>();
            gameStateController.OnGameStateChanged += OnGameStageChange;
        }

        void OnGameStageChange(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.GameNotstarted:
                   
                    EndGameUIPanel.SetActive(false);
                    break;
                case GameState.GameStarted:
                   
                    break;
                case GameState.Failed:
                  
                    EndGameUIPanel.SetActive(true);
                    break;
            }
        }
    }
}

