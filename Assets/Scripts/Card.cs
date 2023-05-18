using UnityEngine;

public class Card : MonoBehaviour
{
    [field: SerializeField] public CardValue cardValue { get; private set; }

    public bool interactability { get; private set; } 

    private CardDrawer cardDrawer;
    public CardHandler cardHandler { get; private set; }

    public RectTransform rect { get; private set; }

    public void Initialize(Suit suit, byte rank)
    {
        cardValue = new CardValue(suit, rank);

        rect = GetComponent<RectTransform>();

        cardDrawer = GetComponent<CardDrawer>();
        cardHandler = GetComponent<CardHandler>();

        cardDrawer.DrawBg();
    }

    public void SetCanvasAsParent()
    {
        transform.SetParent(GetComponentInParent<Canvas>(true).transform, true);
    }

    public void Draw(bool drawValue = false)
    {
        if (drawValue == false) cardDrawer.DrawBg();
        else cardDrawer.DrawCard(cardValue);
    }

    public void ChangeInteractability(bool interactability)
    {
        this.interactability = interactability;
        Draw(interactability);
    }
}