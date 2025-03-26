using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;
    private bool isShieldActive = false;
    private int shieldStrength = 20;

    public string CharName => charName;
    public bool IsShieldActive => isShieldActive;
    public int ShieldStrength => shieldStrength;

    public void ToggleShield()
    {
        isShieldActive = !isShieldActive;
        Debug.Log(isShieldActive ? "Shield Activated: " + shieldStrength : "Shield Deactivated");
    }

    public override void GetHit(int damage)  // ����������� (Override)
    {
        if (isShieldActive)
        {
            shieldStrength -= damage / 2;  // ��� ��������� ����
            Debug.Log(name + " blocked damage! Shield left: " + shieldStrength);
            if (shieldStrength <= 0)
            {
                isShieldActive = false;
                Debug.Log(name + "'s shield broke!");
            }
        }
        else
        {
            base.GetHit(damage);  // �������� ������������ ����� �� Character
        }
    }
}