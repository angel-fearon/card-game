using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public int deckSize = 30;

    //topcards which are shown
    public DisplayCard card1;
    public DisplayCard card2;
    public DisplayCard card3;
    public DisplayCard card4;

    void Start()
    {
        populate();
        assignTopCards();
        //shuffle();
        
    }
    public void populate()
    {
        int x;
        for (int i = 0; i < deckSize; i++)
        {
            x = UnityEngine.Random.Range(1, 5);
            deck.Add(CardDatabase.cards[x]);
            Console.WriteLine("Card populated");
        }

    }

    public void assignTopCards()
    {
        card1.setDisplayId(deck[0].getId());
        card1.flip();
        card2.setDisplayId(deck[1].getId());
        card2.flip();
        card3.setDisplayId(deck[2].getId());
        card3.flip();
        card4.setDisplayId(deck[3].getId());
        card4.flip();
    }
    
    public void shuffle()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card c = deck[i];
            int random = UnityEngine.Random.Range(i, deck.Count);
            deck[i] = deck[random];
            deck[random] = c;
        }
    }
    public void Update()
    {
        
    }
    
}
