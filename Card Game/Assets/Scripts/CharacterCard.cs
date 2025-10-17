using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CharacterCard
{
    public int id;
    public string name;
    public int health;
    public Ability[] abilities;
    public string sprite;//changes made sprite type to string

    public CharacterCard(int id, string name, int health, string sprite, Ability[] abilities)
    {
        this.id = id;
        this.name = name;
        this.health = health;
        this.sprite = sprite;
        this.abilities = abilities;
    }
    
    public int getId()
    {
        return id;
    }
    public string getName()
    {
        return name;
    }
    public int getHealth()
    {
        return health;
    }
    public string getSprite()
    {
        return sprite;
    }
    public Ability[] getAbilities()
    {
        return abilities;
    }
}
