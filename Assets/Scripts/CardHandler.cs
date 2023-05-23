using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class CardHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Inject] AudioManager audioManager;
    private CanvasGroup canvasGroup;
    private Card card;
    private Canvas canvas;

    [HideInInspector] public CardHolder holder;
    public Card[] draggingCards { get; private set; }

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        card = GetComponent<Card>();
        canvas = GetComponentInParent<Canvas>(true);

        draggingCards = new Card[0];
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (card.interactability)
        {
            audioManager.PlayCardTaken();

            holder = GetComponentInParent<CardHolder>(true);

            draggingCards = holder.GetNextCards(card);

            for (int i = 0; i < draggingCards.Length; i++)
            {
                holder.RemoveCard(draggingCards[i]);
                canvasGroup.blocksRaycasts = false;
            }
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (card.interactability)
        {
            for (int i = 0; i < draggingCards.Length; i++)
            {
                draggingCards[i].rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        audioManager.PlayCardSetted();
        for (int i = 0; i < draggingCards.Length; i++)
        {
            canvasGroup.blocksRaycasts = true;
            if (holder != null) holder.AddCard(draggingCards[i]);
        }
    }
}