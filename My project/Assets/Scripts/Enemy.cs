using UnityEngine;

public class Enemy : Character
{
    [SerializeField] internal int agression = 10;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Attack()
    {
        if (gameManager != null && gameManager.player != null)
        {
            int damage = Random.Range(3, 6); 
            gameManager.player.GetHit(damage);
            Debug.Log($"{this.name} атакует на {damage}");
        }
        else
        {
            Debug.LogError("GameManager или Player не найден!");
        }
    }
}