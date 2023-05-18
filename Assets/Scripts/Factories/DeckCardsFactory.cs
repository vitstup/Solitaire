using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DeckCardsFactory : GenericFactory<Card>
{
    private RectTransform rect;

    public DeckCardsFactory(DiContainer container, Card prefab, RectTransform rect) : base(container, prefab)
    {
        this.rect = rect;
    }

    public List<Card> InstantiateDeck()
    {
        List<Card> cards = new List<Card>();
        for (int s = 0; s < 4; s++)
        {
            for (int r = 0; r < 13; r++)
            {
                var card = GetNewInstance();
                card.Initialize((Suit)s, (byte)r);
                cards.Add(card);
            }
        }

        ShuffleCards shuffle = new ShuffleCards();
        shuffle.Shuffle(cards);

        foreach (Card card in cards)
        {
            card.GetComponent<RectTransform>().SetParent(rect, false);
        }

        return cards;
    }
}