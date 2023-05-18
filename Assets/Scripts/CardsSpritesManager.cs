using UnityEngine;

public class CardsSpritesManager : MonoBehaviour
{
    public Sprite[,] cardSprites { get; private set; }

    [SerializeField] private Sprite[] sprites;

    [field: SerializeField] public Sprite cardBg { get; private set; }

    private void Awake()
    {
        SetCardSprites();
    }

    private void SetCardSprites()
    {
        cardSprites = new Sprite[4, sprites.Length / 4];
        for (int s = 0; s < cardSprites.GetLength(0); s++)
        {
            for (int r = 0; r < cardSprites.GetLength(1); r++)
            {
                cardSprites[s, r] = sprites[r + (cardSprites.GetLength(1) * s)];
            }
        }
    }
}
