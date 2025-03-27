using UnityEngine;

public class Skeleton : Enemy
{
    void Start()
    {
        health = 30;
    }

    public override int Attack()
    {
        return Random.Range(5, 10);
    }
}