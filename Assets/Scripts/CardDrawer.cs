using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardDrawer : MonoBehaviour
{
    [Inject] private CardsSpritesManager spritesManager;

    [SerializeField] private Image image;

    public void DrawCard(CardValue card)
    {
        image.sprite = spritesManager.cardSprites[(int)card.suit, card.rank];
    }

    public void DrawBg()
    {
        image.sprite = spritesManager.cardBg;
    }
}
