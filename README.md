OOP Principles Application:
Inheritance:
The base class Character, from which Player, Enemy, Goblin, Skeleton, and Giant inherit.
public class Character : MonoBehaviour
{
    public int health;
    public virtual int Attack() { ... }
    public virtual void GetHit(int damage) { ... }
}

Encapsulation:
Usage of getter and setter for the CharName property in the Character class.
public string CharName
{
    get => charName;
    set => charName = value;
}
Internal data about the player's shield (e.g., ShieldStrength, IsShieldActive) is hidden.

Polymorphism:
Override: The Attack() method is overridden for different enemy types (e.g., Giant has fixed damage, Skeleton has random damage).
public override int Attack()
{
    return Random.Range(5, 10);  // Skeleton's attack
}
Overload: The GetHit() method is overloaded (with parameters damage and weapon).
public void GetHit(Weapon weapon)
{
    health -= weapon.GetDamage();
    ...
}

Abstraction:
The abstract Weapon class with an abstract ApplyEffect() method and a regular GetDamage() method, implemented in subclasses (e.g., Spear).
public abstract class Weapon : MonoBehaviour
{
    public int GetDamage() { return Random.Range(minDamage, maxDamage+1); }
    public abstract void ApplyEffect(Character character);  // абстрактный метод
}
public class Spear : Weapon
{
    public override void ApplyEffect(Character character)
    {
        // Реализация эффекта от копья
    }
}

Additional Task:
Principles: Inheritance and Polymorphism. Three different enemies with unique attacks are implemented:
Goblin: Attack depends on aggression.
Skeleton: Random damage.
Giant: Ignores the shield, fixed 100 damage.
public override int Attack()
{
    return 100;  // Giant attacks with fixed 100 damage, ignoring the shield
}
