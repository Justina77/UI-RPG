using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] private int agressionGain = 5;

    public override int Attack()
    {
        agression += agressionGain;
        Player player = FindObjectOfType<Player>();

        if (player.IsShieldActive) 
        {
            return (agression / 10) / 2; 
        }
        else
        {
            return agression / 10; 
        }
    }
}