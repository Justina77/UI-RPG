using UnityEngine;

public class Giant : Enemy
{
    private void Start()
    {
        health = 100; // ������������� 100 HP
    }

    public override int Attack()
    {
        Debug.Log(name + " attacks and ignores the shield!");
        return 100; // ������ ������� 100 �����, ��������� ���
    }
}