using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOverCanvas;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private MageController mageController;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private CoinPickup[] coins;
    [SerializeField] private Enemy[] enemies;

    private bool isGameOver = false;

    public void ShowGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        gameOverCanvas.alpha = 1f;
        gameOverCanvas.interactable = true;
        gameOverCanvas.blocksRaycasts = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (mageController != null)
        {
            mageController.enabled = false;
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn button clicked");

        isGameOver = false;

        gameOverCanvas.alpha = 0f;
        gameOverCanvas.interactable = false;
        gameOverCanvas.blocksRaycasts = false;

        CharacterController controller = player.GetComponent<CharacterController>();

        if (controller != null)
        {
            controller.enabled = false;
        }

        player.position = respawnPoint.position;

        if (controller != null)
        {
            controller.enabled = true;
        }

        if (mageController != null)
        {
            mageController.enabled = true;
        }
        PlayerHealth health = player.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.RestoreHealth();
        }
        if (coinManager != null)
        {
            coinManager.ResetCoins();
        }
        foreach (CoinPickup coin in coins)
        {
            if (coin != null)
            {
                coin.ResetCoin();
            }
        }

        foreach (Enemy enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.ResetEnemy();
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Game closed");
    }
}