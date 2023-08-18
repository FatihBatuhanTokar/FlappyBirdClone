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
                    Debug.Log("Oyun Baslamadi UI");
                    break;
                case GameState.GameStarted:
                    Debug.Log("Oyun Basladi UI");
                    StartGameUIPanel.SetActive(false);
                    gameStateController.OnGameStateChanged -= OnGameStageChange;
                    break;
                case GameState.Failed:
                    Debug.Log("Oyun Bitti UI");
                    break;
            }
        }
        
    }
}
