using UnityEngine;

public class Ability
{
    public string name;
    public int baseDamage;
    public Effect[] effects;
    //add name attribute

    public Ability(string name, int baseDamage, Effect[] effects)
    {
        this.name = name;
        this.baseDamage = baseDamage;
        this.effects = effects;
    }

    public string getName()
    {
        return name;
    }
    public int getDamage()
    {
        return baseDamage;
    }
}
