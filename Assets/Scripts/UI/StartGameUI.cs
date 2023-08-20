using UnityEngine;
using Script.Core;
namespace Script.UI
{
    public class StartGameUI : MonoBehaviour
    {
        GameStateController gameStateController;
        [SerializeField] GameObject StartGameUIPanel;
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
                    StartGameUIPanel.SetActive(true);
                   
                    break;
                case GameState.GameStarted:
               
                    StartGameUIPanel.SetActive(false);
                    gameStateController.OnGameStateChanged -= OnGameStageChange;
                    break;
                case GameState.Failed:
                  
                    break;
            }
        }
        
    }
}
