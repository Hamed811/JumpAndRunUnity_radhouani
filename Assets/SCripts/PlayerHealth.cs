using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameOverManager gameOverManager;
    [SerializeField] private ParticleSystem bloodEffect;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.kKey.wasPressedThisFrame)
        {
            TakeDamage(25);
        }
    }

    public void TakeDamage(int damage)
    {
        if (bloodEffect != null)
        {
            bloodEffect.Play();
        }
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("HP: " + currentHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Player dead - Game Over");
            gameOverManager.ShowGameOver();
        }
    }

   

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void SetHealthToZero()
    {
        currentHealth = 0;

        UpdateHealthUI();

        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
    }



    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
        {
            healthText.text = currentHealth + " / " + maxHealth;
        }
    }
}