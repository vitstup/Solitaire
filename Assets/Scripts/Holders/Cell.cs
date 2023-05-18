using System.Linq;

public class Cell : CardHolder
{
    protected override bool CanPlaceCard(Card card)
    {
        if (cards.Count == 0 && card.cardValue.rank == 12) return true; 
        else if (cards.Count > 0 && cards.Last().cardValue.CanAddLower(card.cardValue)) return true;
        else return false;
    }
}