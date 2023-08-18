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
                    Debug.Log("EndGameUIPanel is not active");
                    EndGameUIPanel.SetActive(false);
                    break;
                case GameState.GameStarted:
                    Debug.Log("EndGameUIPanel is active");
                    break;
                case GameState.Failed:
                    Debug.Log("EndGameUIPanel is not active");
                    EndGameUIPanel.SetActive(true);
                    break;
            }
        }
    }
}

