using UnityEngine;
using UnityEngine.UI;      // untuk Slider
using TMPro;              // optional jika pakai TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI (optional)")]
    public Slider healthSlider;            // drag Slider here (UI > Slider)
    public Image healthFillImage;          // optional: image fill untuk warna
    public TextMeshProUGUI healthText;     // optional: numeric text

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        Debug.Log($"Player took {amount} damage. HP = {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (healthFillImage != null)
        {
            // contoh: ubah warna berdasarkan persentase
            float pct = (float)currentHealth / maxHealth;
            healthFillImage.fillAmount = pct;
        }

        if (healthText != null)
        {
            healthText.text = $"{currentHealth} / {maxHealth}";
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Tambah logic respawn atau game over di sini.
    }
}
