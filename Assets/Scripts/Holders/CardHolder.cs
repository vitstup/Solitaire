using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CardHolder : MonoBehaviour, IDropHandler
{
    [SerializeField] private Vector2 spacing = new Vector2(-2, -2);

    [SerializeField] protected RectTransform holderRect;

    protected List<Card> cards = new List<Card>();

    public void ForceLayout()
    {
        for (int i = 0; i < holderRect.childCount; i++)
        {
            holderRect.GetChild(i).GetComponent<RectTransform>().anchoredPosition = spacing * i;
        }
    }
    
    public Vector3 NewCardTarget()
    {
        Vector2 rectPos = holderRect.anchoredPosition + new Vector2(spacing.x * holderRect.childCount, spacing.y * holderRect.childCount);
        return holderRect.transform.TransformPoint(rectPos);
    }

    public void AddCard(Card card, bool addToDown = false)
    {
        card.rect.SetParent(holderRect);

        if (!addToDown) cards.Add(card);
        else
        {
            cards.Insert(0, card);
            card.transform.SetAsFirstSibling();
        }

        ForceLayout();
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        card.SetCanvasAsParent();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var card = eventData.pointerDrag.GetComponent<Card>();
            if (CanPlaceCard(card))
            {
                for (int i = 0; i < card.cardHandler.draggingCards.Length; i++)
                {
                    AddCard(card.cardHandler.draggingCards[i]);
                }
                if (card.cardHandler.holder != this) card.cardHandler.holder.OpenLastCard();
                card.cardHandler.holder = null;
            }
        }
    }

    protected abstract bool CanPlaceCard(Card card);

    public void OpenLastCard()
    {
        if (cards.Count > 0) cards.Last().ChangeInteractability(true);
    }

    private int GetCardIndex(Card card)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (card == cards[i]) return i;
        }
        throw new System.NotImplementedException("There is no such card in this holder");
    }

    public Card[] GetNextCards(Card card)
    {
        int cardIndex = GetCardIndex(card);
        Card[] nextCards = new Card[cards.Count - cardIndex];
        for (int i = 0; i < nextCards.Length; i++)
        {
            nextCards[i] = cards[i + cardIndex];
        }
        return nextCards;
    }

    public void ClearCards()
    {
        cards.Clear();
    }
}