using System;
using UnityEngine;
using UnityEngine.UI;


public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public CanvasGroup playerPanel;
    public CanvasGroup opponentPanel;
    public Image playerBackground;
    public Image opponentBackground;
    public CharacterCard attackCard;
    public CharacterCard defenseCard;
    public bool isActionPhase;

    //Make Turnsystem a singleton (need to understand)
    public static TurnSystem Instance {  get; private set; }

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

    void Start()
    {
        isYourTurn = true;

    }

    void Update()
    {
        if (isYourTurn)
        {
            //playerPanel.blocksRaycasts = true;
            //opponentPanel.blocksRaycasts = false;
            playerBackground.color = Color.green;
            opponentBackground.color = Color.grey;
        }
        else
        {
            //playerPanel.blocksRaycasts = false;
            //opponentPanel.blocksRaycasts = true;
            playerBackground.color = Color.grey;
            opponentBackground.color = Color.green;
        }

    }
    public void switchActivePlayer()
    {
        isYourTurn = !isYourTurn;
        Debug.Log("player switched");
    }

    public int roll()
    {
        return UnityEngine.Random.Range(1, 7);
    }

    
}
