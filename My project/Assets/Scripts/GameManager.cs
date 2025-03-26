using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText, shieldText;

    void Start()
    {
        playerNameText.text = player.CharName;
        enemyNameText.text = enemy.name;
        UpdateUI();
    }

    public void DoRound()
    {
        int playerDamage = player.Attack();
        enemy.GetHit(playerDamage);
        int enemyDamage = enemy.Attack();
        player.GetHit(enemyDamage);
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

        if (player.IsShieldActive) // ўит включЄн и работает
        {
            shieldText.text = "Shield: " + Mathf.Max(player.ShieldStrength, 0);
        }
        else if (player.IsShieldBroken) // ўит сломан, но всЄ равно показываем "Shield: 0"
        {
            shieldText.text = "Shield: 0";
        }
        else // ўит выключен и Ќ≈ сломан ? скрываем надпись
        {
            shieldText.text = "";
        }
    }
}