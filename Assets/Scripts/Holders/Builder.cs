using System.Linq;

public class Builder : CardHolder
{
    protected override bool CanPlaceCard(Card card)
    {
        if (card.cardHandler.draggingCards.Length > 1) return false;
        if (cards.Count == 0 && card.cardValue.rank == 0) return true;

        var lastCard = cards.Count > 0? cards.Last() : null;
        if (lastCard != null)
        {
            if (lastCard.cardValue.suit == card.cardValue.suit && card.cardValue.rank - lastCard.cardValue.rank == 1) return true;
        } 
        return false;
    }
}