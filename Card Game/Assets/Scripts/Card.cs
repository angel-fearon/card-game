using UnityEngine;
[System.Serializable] 
public class Card
{
    private int id; 
    private string name;
    private int cost;
    private string description;
    private Sprite sprite;

    public Card()
    {

    }
    public Card(int id, string name, int cost, string description, Sprite sprite)
    {
        this.id = id;
        this.name = name;
        this.cost = cost;
        this.description = description;
        this.sprite = sprite;
    }

    public int getId()
    {
        return id;
    }
    public string getName()
    {
        return name;
    }
    public int getCost()
    {
        return cost;
    }
    public string getDescription()
    {
        return description;
    }
    public Sprite getSprite()
    {
        return sprite;
    }


}
