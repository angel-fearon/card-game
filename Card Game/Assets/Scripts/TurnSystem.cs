using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
    ActionPhase,
    RollPhase,
    GameOver
}
public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public CanvasGroup playerPanel;
    public CanvasGroup opponentPanel;
    //public GameObject actionPhase;
    public Image playerBackground;
    public Image opponentBackground;
    public DisplayCharacter playerCard;
    public DisplayCharacter opponentCard;
    //public GameObject gameOver;
    //scripts
    public RollPhase rollPhase;
    public GameObject rollPanel;
    public GameObject actionPanel;
    public GameObject gameOverPanel;


    public static GamePhase currentPhase;
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
        currentPhase = GamePhase.RollPhase;
        isYourTurn = true;
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
    void Update()
    {
        updateUI();
        //if (continueGame)
        //{
        //    if (isActionPhase)
        //    {
        //        actionPhase.SetActive(true); Debug.Log("action phase initiated");
        //        isRollPhase = false;
        //    }
        //    if (isRollPhase)
        //    {
        //        actionPhase.SetActive(false);
        //        continueGame = false;
        //        rollPhase.rollDice();
        //    }
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
        //}
        //else
        //{
        //    if (isActionPhase)
        //    {
        //        if (playerCard.checkAlliesAlive() == false || opponentCard.checkAlliesAlive() == false)
        //        {
        //            continueGame = false;
        //            Debug.Log("game ended");
        //            gameOver.SetActive(true);
        //        }
        //    }
        //}

    }

    public void updateUI()
    {
        rollPanel.SetActive(false);
        actionPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        switch (currentPhase)
        {
            case GamePhase.RollPhase:
                rollPanel.SetActive(true);
                break;
            case GamePhase.ActionPhase:
                rollPanel.SetActive(false);
                actionPanel.SetActive(true);
                break;
            case GamePhase.GameOver:
                gameOverPanel.SetActive(true);
                break;

        }
    }
    public void switchActivePlayer()
    {
        if (isYourTurn == false)
        {
            currentPhase = GamePhase.RollPhase;
            isYourTurn = !isYourTurn;
        }
        else
        {
            isYourTurn = !isYourTurn;
            Debug.Log("player switched");
        }
        
    }



    

    
}
