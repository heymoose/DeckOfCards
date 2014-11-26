﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour 
{


    [SerializeField]
    private Card cardPrefab;

    private List<Card> _cards;


    private void Awake()
    {
        _cards = new List<Card>();

        Initialize();
        Shuffle();
    }


    /// <summary>
    /// Create cards and initialize everything
    /// </summary>
    private void Initialize()
    {
        foreach (Value value in System.Enum.GetValues(typeof(Value)))
        {
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                Card card = Instantiate(cardPrefab) as Card;
                card.Initialize(suit, value);

                _cards.Add(card);

                card.transform.parent = this.transform;
                card.gameObject.name = card.Name;
            }
        }
    }


    /// <summary>
    /// Shuffle the deck
    /// </summary>
    public void Shuffle()
    {
        if (_cards != null && _cards.Count > 1)
        {
            // Unparent all cards so we can parent them back to the deck how we want
            foreach (Card card in _cards)
                card.transform.parent = null;

            System.Random random = new System.Random();

            // Swap cards around randomly
            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                int randIndex = random.Next(i + 1);

                Card tmp = _cards[i];
                _cards[i] = _cards[randIndex];
                _cards[randIndex] = tmp;
                _cards[randIndex].transform.parent = this.transform;
            }
        }
    }


    /// <summary>
    /// Print the list of cards
    /// </summary>
    public void PrintDeck()
    {
        foreach (Card card in _cards)
            Debug.Log(card.Name);
    }


}
