using System.Collections.Generic;
using AbilityConstructor;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public static DisplayCharacter attackCard;
    public static DisplayCharacter defenseCard;
    public static Ability attackAbility;

    public static AttackScript Instance { get; private set; }

    //ensures AttackScript is a singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);//optional clause
        }
    }

    //assigns an attack or defence card with checks that the card selected corresponds to the player whose turn it is
    public void setCurrentCharacter(DisplayCharacter d)
    {
        bool isYourTurn = TurnSystem.isYourTurn;
        GameObject parent = d.transform.parent.gameObject;
        if (attackCard == null)
        {
            if (isYourTurn == true && parent.name == "PlayerCharacters")
            {
                attackCard = d;
                Debug.Log("Attack card assigned as " + attackCard.name);
            }else if(isYourTurn == false && parent.name == "OpponentCharacters")
            {
                attackCard = d;
                Debug.Log("Attack card assigned as " + attackCard.name);
            }       
        }
        else if(defenseCard == null) 
        {
            if (isYourTurn == true && parent.name == "OpponentCharacters")
            {
                defenseCard = d;
                Debug.Log("defense card assigned as " + defenseCard.name);
                attack(d);
            }
            else if (isYourTurn == false && parent.name == "PlayerCharacters")
            {
                defenseCard = d;
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
        var ability = AbilityFactory.createAbility(attackAbility, d);
        //int damage = attackCard.character.getAbilities()[0].getDamage();    
        //d.damage(damage);
        //Debug.Log(damage + " damage dealt");
        TurnSystem.Instance.switchActivePlayer();
        attackCard = null;
        defenseCard = null;
    }
}

