using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;
    private bool isShieldActive = false;
    private int shieldStrength = 20;
    private bool isShieldBroken = false;

    public string CharName => charName;
    public bool IsShieldActive => isShieldActive && !isShieldBroken; // Щит работает, если не сломан
    public bool IsShieldBroken => isShieldBroken; // Новый геттер для проверки сломан ли щит
    public int ShieldStrength => shieldStrength;

    public void ToggleShield()
    {
        isShieldActive = !isShieldActive;
        Debug.Log(isShieldActive ? "Shield Activated: " + shieldStrength : "Shield Deactivated");
    }

    public override void GetHit(int damage)
    {
        if (isShieldActive && !isShieldBroken)
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