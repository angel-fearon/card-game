using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private static CharacterCard currentCharacter;//might need to make public?
    public static CharacterCard attackCard;
    public static CharacterCard defenseCard;
    private bool isYourTurn;

    private List<string> buffs = new List<string>();
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //assigns an attack or defence card with checks that the card selected corresponds to the player whose turn it is
    public void setCurrentCharacter(CharacterCard c,GameObject parent, DisplayCharacter d)
    {
        isYourTurn = TurnSystem.isYourTurn;
        currentCharacter = c;
        if (attackCard == null)
        {
            if (isYourTurn == true && parent.name == "PlayerCharacters")
            {
                attackCard = currentCharacter;
                Debug.Log("Attack card assigned as " + attackCard.name);
            }else if(isYourTurn == false && parent.name == "OpponentCharacters")
            {
                attackCard = currentCharacter;
                Debug.Log("Attack card assigned as " + attackCard.name);
            }       
        }
        else if(defenseCard == null) 
        {
            if (isYourTurn == true && parent.name == "OpponentCharacters")
            {
                defenseCard = currentCharacter;
                Debug.Log("defense card assigned as " + defenseCard.name);
                attack(d);
            }
            else if (isYourTurn == false && parent.name == "PlayerCharacters")
            {
                defenseCard = currentCharacter;
                Debug.Log("defense card assigned as " + defenseCard.name);
                attack(d);
            }
        }
        else
        {
            Debug.Log("No card assigned");
        }
    }
    //deals damage to the defense card and ends the turn
    public void attack(DisplayCharacter d)
    {
        int damage = attackCard.abilities[0].getDamage();    
        d.damageCharacter(damage);
        Debug.Log(damage + " damage dealt");
        TurnSystem.Instance.switchActivePlayer();
        attackCard = null;
        defenseCard = null;
    }
    public void setBuff(Card c)
    {

    }
}

