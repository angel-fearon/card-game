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
    public static bool continueGame;
    public GameObject gameOver;

    //Make Turnsystem a singleton (need to understand)
    public static TurnSystem Instance {  get; private set; }

    //ensures turnsystem is a singleton
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
        continueGame = true;
    }

    void Update()
    {
        if (continueGame)
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
        else
        {
            Debug.Log("game ended");
            gameOver.SetActive(true);
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
