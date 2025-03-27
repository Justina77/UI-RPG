using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;
    [SerializeField] private int shieldStrength = 20;
    private bool isShieldActive = false;
    private bool isShieldBroken = false;

    public string CharName => charName;
    public bool IsShieldActive => isShieldActive;
    public bool IsShieldBroken => isShieldBroken;
    public int ShieldStrength => shieldStrength;

    public void ToggleShield()
    {
        if (!isShieldBroken)
        {
            isShieldActive = !isShieldActive;
        }
    }

    public override void GetHit(int damage)
    {
        if (isShieldActive && !isShieldBroken)
        {
            shieldStrength -= damage / 2;

            if (shieldStrength <= 0)
            {
                shieldStrength = 0;
                isShieldBroken = true;
                isShieldActive = false;
            }
        }
        else
        {
            health -= damage;
        }
    }
}