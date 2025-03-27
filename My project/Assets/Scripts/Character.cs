using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected string charName; // Это оставляем
    public string CharName => charName;
    public int health;
    [SerializeField] private Weapon activeWeapon;

    public Weapon ActiveWeapon => activeWeapon;

    public virtual int Attack()
    {
        Debug.Log(name + " attacking!");
        return activeWeapon.GetDamage();
    }

    public virtual void GetHit(int damage)
    {
        health -= damage;
        Debug.Log(name + " current health: " + health);
    }

    public void GetHit(Weapon weapon)
    {
        health -= weapon.GetDamage();
        Debug.Log("Got hit by: " + weapon.name);
        Debug.Log(name + " current health: " + health);
    }
}