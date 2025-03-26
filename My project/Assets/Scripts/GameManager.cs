using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText, shieldText;

    void Start()
    {
        UpdateUI();
    }

    public void DoRound()
    {
        int playerDamage = player.Attack();
        enemy.GetHit(playerDamage);

        if (enemy.health <= 0)
        {
            Debug.Log("Enemy Defeated! Spawning new enemy...");
            enemy = Instantiate(enemy); // Создаём нового врага
        }
        else
        {
            int enemyDamage = enemy.Attack();
            player.GetHit(enemyDamage);
            if (player.health <= 0)
            {
                Debug.Log("Game Over");
            }
        }

        UpdateUI();
    }

    public void ToggleShield()
    {
        player.ToggleShield();
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = enemy.health.ToString();
        shieldText.text = player.IsShieldActive ? "Shield: " + player.ShieldStrength : "";
    }
}