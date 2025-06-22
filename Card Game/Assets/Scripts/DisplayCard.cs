using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DisplayCard : MonoBehaviour
{
    public GameObject cardBack;
    public int displayId;
    public Text cardName;
    public Text cost; 
    public Text description;
    public Image image;
    public Card c;

    //scripts
    public AttackScript attack;

    public bool isFaceDown;

    
    void Start()
    {
        isFaceDown = true;
        
    }
    private void Update()
    {
        cardBack.SetActive(isFaceDown);
        show(displayId);
    }
    public void flip()
    {
        isFaceDown = !isFaceDown;
        cardBack.SetActive(!isFaceDown);
    }

    public void show(int id)
    {
        c = CardDatabase.cards[id];
        cardName.text = c.getName();
        cost.text = c.getCost().ToString();
        description.text = c.getDescription();
        image.sprite = c.getSprite();
        cardBack.SetActive(isFaceDown);
    }


    public void cardClicked()
    {
        Debug.Log(c.getName() + " card selected ID: " + displayId);
        GameObject parent = transform.parent.gameObject;
        attack.setBuff(c/*, parent, this*/);
    }
    public void setDisplayId(int displayId)
    {
        this.displayId = displayId;
    }

}
