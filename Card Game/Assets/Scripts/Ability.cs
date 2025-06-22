using UnityEngine;

public class Ability
{
    private string name;
    private int damage;
    private string description;
    //add name attribute

    public Ability(string name, int damage, string description)
    {
        this.name = name;
        this.damage = damage;
        this.description = description;
    }

    public int getDamage()
    {
        return damage;
    }
}
