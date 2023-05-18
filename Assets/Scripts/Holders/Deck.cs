using UnityEngine;
using Zenject;

public class Deck : CardHolder
{
    [SerializeField] private Card cardPrefab;
    [Inject] DiContainer container;
    [Inject] CellsManager cellsManager;

    private void Start()
    {
        InitializeDeck();
        cellsManager.StartCoroutine(cellsManager.InitializeCells(cards));
    }

    private void InitializeDeck()
    {
        DeckCardsFactory factory = new DeckCardsFactory(container, cardPrefab, holderRect);
        cards = factory.InstantiateDeck();
        ForceLayout();
    }

    protected override bool CanPlaceCard(Card card)
    {
        if (card.cardHandler.holder == this) return true;
        return false;
    }
}