using System;
using UnityEngine;

[Serializable]
public struct CardValue 
{
    [field: SerializeField] public Suit suit { get; private set; }
    [field: SerializeField] public byte rank { get; private set; }

    public CardValue(Suit suit, byte rank)
    {
        this.suit = suit;
        this.rank = rank;
    }
    

    public bool CanAddLower(CardValue value)
    {
        return rank - value.rank == 1 && NotSameColor(value);
    }

    private bool NotSameColor(CardValue value)
    {
        if ((suit == Suit.Hearts || suit == Suit.Diamonds) && (value.suit == Suit.Spades || value.suit == Suit.Clubs)) return true;
        else if ((suit == Suit.Spades || suit == Suit.Clubs) && (value.suit == Suit.Hearts || value.suit == Suit.Diamonds)) return true;
        else return false;
    }
}