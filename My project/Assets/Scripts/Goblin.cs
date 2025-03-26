using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] private int agressionGain = 5;

    public override int Attack()
    {
        agression += agressionGain;
        return agression / 10;
    }
}
