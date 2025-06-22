using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacter : MonoBehaviour
{
    public GameObject cardBack;
    public int displayId;
    public Text health;
    public Image image;
    public CharacterCard c;

    public int currentHealth;

    public bool isFaceDown;

    //scripts
    public AttackScript attack;

    void Start()
    {
        c = CardDatabase.characters[displayId];
        currentHealth = c.getHealth();
        
    }

    void Update()
    {
        cardBack.SetActive(isFaceDown);
        show();
    }
    public void show()
    {
        //name.text = c.getName();
        health.text = currentHealth.ToString();
        image.sprite = c.getSprite();
    }
    public void cardClicked()
    {
        //Debug.Log(c.getName() + " card selected ID: " + displayId);
        GameObject parent = transform.parent.gameObject;
        attack.setCurrentCharacter(c,parent,this);
    }

    public void damageCharacter(int damage)
    {
        currentHealth -= damage;
    }

}
