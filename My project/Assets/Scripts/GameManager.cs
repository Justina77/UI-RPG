using UnityEngine;
using TMPro;
using UnityEngine.UI; // Для работы с изображениями

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerHealthText, enemyHealthText, enemyNameText, shieldText;
    [SerializeField] private Image enemyImage; // UI-элемент для изображения
    [SerializeField] private Sprite goblinSprite;
    [SerializeField] private Sprite skeletonSprite;

    private bool isGoblinDefeated = false; // Флаг для смены врага

    void Start()
    {
        SpawnGoblin();
        UpdateUI();
    }

    public void DoRound()
    {
        int playerDamage = player.Attack();
        enemy.GetHit(playerDamage);

        if (enemy.health <= 0)
        {
            SpawnNextEnemy();
        }
        else
        {
            int enemyDamage = enemy.Attack();
            player.GetHit(enemyDamage);
        }

        UpdateUI();
    }

    private void SpawnNextEnemy()
    {
        enemyImage.enabled = false; // Скрываем изображение перед заменой
        Destroy(enemy.gameObject); // Удаляем старого врага

        if (!isGoblinDefeated)
        {
            isGoblinDefeated = true;
            SpawnSkeleton();
        }
        else
        {
            isGoblinDefeated = false;
            SpawnGoblin();
        }

        enemyImage.enabled = true; // Показываем изображение нового врага
        UpdateUI();
    }

    private void SpawnGoblin()
    {
        enemy = gameObject.AddComponent<Goblin>();
        enemy.health = 50;
        enemy.name = "Goblin";
        enemyImage.sprite = goblinSprite;

        enemyImage.enabled = true; // Убедимся, что изображение включено
        enemyNameText.text = enemy.name;
    }

    private void SpawnSkeleton()
    {
        enemy = gameObject.AddComponent<Skeleton>();
        enemy.health = 30;
        enemy.name = "Skeleton";
        enemyImage.sprite = skeletonSprite;

        enemyImage.enabled = true;
        enemyNameText.text = enemy.name;
    }

    private void UpdateUI()
    {
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = enemy.health.ToString();
        enemyNameText.text = enemy.name;

        if (player.IsShieldActive)
        {
            shieldText.text = "Shield: " + Mathf.Max(player.ShieldStrength, 0);
        }
        else if (player.IsShieldBroken)
        {
            shieldText.text = "Shield: 0";
        }
        else
        {
            shieldText.text = "";
        }
    }

    public void ToggleShield()
    {
        player.ToggleShield();
        UpdateUI();
    }
}