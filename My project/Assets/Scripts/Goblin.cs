using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] private int agressionGain = 5;

    public override int Attack()
    {
        agression += agressionGain;
        Player player = FindObjectOfType<Player>();

        if (player.IsShieldActive) // Если щит включен и не сломан
        {
            return (agression / 10) / 2; // Урон по щиту вдвое меньше
        }
        else
        {
            return agression / 10; // Обычный урон по игроку
        }
    }
}