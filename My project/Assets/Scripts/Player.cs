using UnityEngine;

public class Player : Character
{
    private bool isShieldActive = false;
    private int shieldStrength = 20;
    private bool isShieldBroken = false;

    public bool IsShieldActive => isShieldActive && !isShieldBroken;
    public bool IsShieldBroken => isShieldBroken;
    public int ShieldStrength => shieldStrength;

    public void ToggleShield()
    {
        isShieldActive = !isShieldActive;
        Debug.Log(isShieldActive ? "Shield Activated: " + shieldStrength : "Shield Deactivated");
    }

    public override void GetHit(int damage)
    {
        if (damage == 100) // Если урон 100, значит атакует Giant
        {
            health -= damage;
            Debug.Log(name + " was killed instantly by Giant!");
        }
        else if (isShieldActive && !isShieldBroken)
        {
            shieldStrength -= damage / 2;
            Debug.Log(name + " blocked damage! Shield left: " + Mathf.Max(shieldStrength, 0));

            if (shieldStrength <= 0)
            {
                isShieldBroken = true;
                isShieldActive = false;
                Debug.Log(name + "'s shield broke!");
            }
        }
        else
        {
            base.GetHit(damage);
        }
    }
}