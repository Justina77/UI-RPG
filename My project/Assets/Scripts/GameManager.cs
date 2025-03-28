using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    [SerializeField] private TMP_Text playerHealthText, enemyHealthText, enemyNameText, shieldText;
    [SerializeField] private Image enemyImage; 
    [SerializeField] private Sprite goblinSprite;
    [SerializeField] private Sprite skeletonSprite;
    [SerializeField] private Sprite giantSprite;

    private bool isGoblinDefeated = false;

    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private Button attackButton, shieldButton; 

    private bool isGameOver = false; 

    void Start()
    {
        SpawnGoblin();
        UpdateUI();
        gameOverPanel.SetActive(false);
    }

    private void GameOver()
    {
        
        gameOverPanel.SetActive(true);

        
        attackButton.interactable = false;
        shieldButton.interactable = false;

       
        Debug.Log("Game Over! You lost.");
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
            else if (enemy is Skeleton) 
            {
                SpawnGiant();
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

        
        if (player.health <= 0)
        {
            GameOver();
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

        enemy.CharName = "Goblin"; 

        enemyImage.enabled = true;
        enemyNameText.text = enemy.CharName;
    }

    private void SpawnSkeleton()
    {
        enemy = gameObject.AddComponent<Skeleton>();
        enemy.health = 30;
        enemyImage.sprite = skeletonSprite;

        enemy.CharName = "Skeleton"; 

        enemyImage.enabled = true;
        enemyNameText.text = enemy.CharName;
    }

    private void SpawnGiant()
    {
        enemy = gameObject.AddComponent<Giant>(); 
        enemy.health = 100; 
        enemyImage.sprite = giantSprite; 

        enemy.CharName = "Giant"; 

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