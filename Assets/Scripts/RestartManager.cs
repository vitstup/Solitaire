using UnityEngine;

public class RestartManager : MonoBehaviour
{
    public void Restart()
    {
        var deck = FindObjectOfType<Deck>();

        if (deck.CanChangeDraw)
        {
            var holders = FindObjectsOfType<CardHolder>();

            foreach (var holder in holders)
            {
                holder.ClearCards();
            }

            var cards = FindObjectsOfType<Card>();

            foreach (var card in cards)
            {
                Destroy(card.gameObject);
            }

            deck.StartSolitaire();
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}