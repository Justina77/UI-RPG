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

    private bool isGoblinDefeated = false;

    void Start()
    {
        SpawnGoblin();
        UpdateUI();
    }

    public void DoRound()
    {
        if (enemy == null)
        {
            Debug.LogError("Враг не задан!");
            return;
        }

        int playerDamage = player.Attack();
        enemy.GetHit(playerDamage);

        if (enemy.health <= 0)
        {
            if (!isGoblinDefeated)
            {
                isGoblinDefeated = true;
                SpawnSkeleton();
            }
            else
            {
                Debug.Log("Все враги повержены!");
                return;
            }
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
        enemyImage.enabled = false;
        Destroy(enemy.gameObject);

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

        enemyImage.enabled = true;
        UpdateUI();
    }

    private void SpawnGoblin()
    {
        enemy = gameObject.AddComponent<Goblin>();
        enemy.health = 50;
        enemyImage.sprite = goblinSprite;

        enemy.CharName = "Goblin"; // Используем CharName вместо charName

        enemyImage.enabled = true;
        enemyNameText.text = enemy.CharName;
    }

    private void SpawnSkeleton()
    {
        enemy = gameObject.AddComponent<Skeleton>();
        enemy.health = 30;
        enemyImage.sprite = skeletonSprite;

        enemy.CharName = "Skeleton"; // Используем CharName вместо charName

        enemyImage.enabled = true;
        enemyNameText.text = enemy.CharName;
    }

    private void UpdateUI()
    {
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = enemy.health.ToString();
        enemyNameText.text = enemy.CharName;

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