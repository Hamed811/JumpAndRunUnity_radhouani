using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private int coins = 0;

    private void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coins++;
        UpdateCoinText();
    }

    public void ResetCoins()
    {
        coins = 0;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins;
        }
    }
}