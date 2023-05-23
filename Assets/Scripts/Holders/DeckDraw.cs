using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckDraw : CardHolder
{
    [SerializeField] private float animationTime;

    protected override bool CanPlaceCard(Card card)
    {
        if (card.cardHandler.holder == this) return true;
        return false;
    }

    public virtual void ChangeDraw(CardHolder holder, List<Card> cards)
    {
        for (int i = 0; i < this.cards.Count; i++)
        {
            this.cards[i].ChangeInteractability(false);
            holder.AddCard(this.cards[i], true);
        }
        this.cards.Clear();

        List<Card> newCards = new List<Card>();

        for (int i = 0; i < 3; i++)
        {
            if (cards.Count - i - 1 >= 0) newCards.Add(cards[cards.Count - i - 1]);
        }

        for (int i = 0; i < newCards.Count; i++)
        {
            cards.Remove(newCards[i]);
            newCards[i].SetCanvasAsParent();
        }

        StartCoroutine(MoveToDraw(newCards));
    }

    private IEnumerator MoveToDraw(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].rect.DOMove(NewCardTarget(), animationTime);
            cards[i].Draw(true);
            if (i == cards.Count - 1) cards[i].ChangeInteractability(true);
            AddCard(cards[i]);
            yield return new WaitForSeconds(animationTime);
        }
    }
}