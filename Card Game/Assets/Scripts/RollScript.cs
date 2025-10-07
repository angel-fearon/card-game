using TMPro;
using UnityEngine;

public class RollPhase : MonoBehaviour
{
    public DiceScript dice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rollDice()
    {
        dice.roll();//what?
    }
    public void continueClicked(){

        Debug.Log("continue clicked");
        TurnSystem.currentPhase = GamePhase.ActionPhase;  
    }
}
