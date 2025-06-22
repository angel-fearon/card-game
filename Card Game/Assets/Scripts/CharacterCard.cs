using Unity.VisualScripting;
using UnityEngine;

public class CharacterCard
{
    public int id;
    public string name;
    public int health;
    public Ability[] abilities;
    public Sprite sprite;

    public CharacterCard(int id, string name, int health, Sprite sprite, Ability[] abilities)
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
    public Sprite getSprite()
    {
        return sprite;
    }
}
