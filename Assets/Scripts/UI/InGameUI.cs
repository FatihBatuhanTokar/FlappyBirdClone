using UnityEngine;
using Script.Core;
namespace Script.UI
{
    public class InGameUI : MonoBehaviour
    {
        GameStateController gameStateController;
        [SerializeField] GameObject InGameUIPanel;
        
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
                    Debug.Log("InGameUIPanel is not active");
                    InGameUIPanel.SetActive(false);
                    break;
                case GameState.GameStarted:
                    Debug.Log("InGameUIPanel is active");
                    InGameUIPanel.SetActive(true);
                    break;
                case GameState.Failed:
                    gameStateController.OnGameStateChanged -= OnGameStageChange;
                    InGameUIPanel.SetActive(false);
                    Debug.Log("InGameUIPanel is not active");
                    break;
            }
        }
    }
}
