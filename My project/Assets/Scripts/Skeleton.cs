using UnityEngine;

public class Skeleton : Enemy
{
    public override int Attack()
    {
        return 5; // Урон фиксированный, без роста агрессии
    }
}