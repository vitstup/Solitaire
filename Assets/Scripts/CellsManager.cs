using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    [field: SerializeField] public Cell[] cells { get; private set; }

    [SerializeField] private float animationTime = 0.15f;

    public IEnumerator InitializeCells(List<Card> cards)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            int fillAmount = i + 1;
            while (fillAmount > 0)
            {
                var card = cards.Last();
                card.SetCanvasAsParent();
                card.rect.DOMove(cells[i].NewCardTarget(), animationTime);
                yield return new WaitForSeconds(animationTime);
                if (fillAmount == 1) card.ChangeInteractability(true);
                fillAmount--;
                cells[i].AddCard(card);
                cards.Remove(card);
            }
        }
    }
}