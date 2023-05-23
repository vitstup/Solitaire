using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Deck : CardHolder, IPointerClickHandler
{
    [Inject] AudioManager audioManager;

    [SerializeField] private Card cardPrefab;
    [Inject] DiContainer container;
    [Inject] CellsManager cellsManager;
    [Inject] DeckDraw deckDraw;

    [HideInInspector] public bool CanChangeDraw;

    private void Start()
    {
        StartSolitaire();
    }

    public void StartSolitaire()
    {
        InitializeDeck();
        cellsManager.StartCoroutine(cellsManager.InitializeCells(this, cards));
        audioManager.PlayShuffle();
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (CanChangeDraw)
        { 
            deckDraw.ChangeDraw(this, cards);
            audioManager.PlayDraw();
        }
    }
}