using UnityEngine;

namespace backupData
{
    public class PlayState : IMinigameState
    {
        private MinigameStateManager minigameManager;
        private bool isGamePaused = false;

        public PlayState(MinigameStateManager manager)
        {
            minigameManager = manager;
            
        }

        public void EnterState()
        {
            Debug.Log("Game started.");
        }

        public void UpdateState()
        {
            minigameManager.DecreaseLoadingBackup();
            // check win condition
            if (minigameManager.loadingBackupBar.fillAmount >= 0.98)
            {
                 minigameManager.SetState(new WinState(minigameManager));
            }

            // Check lose condition
            else if (Timer.instance.currentTimer <= 0)
            {
                minigameManager.SetState(new LoseState(minigameManager));
            }

            // Play State
            if (Input.GetKeyDown(KeyCode.Space))
            {
                minigameManager.PressedLoadingBackup();
            }
        }

        public void ExitState() { }
    }
}