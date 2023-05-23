using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource shuffleSource;
    [SerializeField] private AudioSource drawSource;
    [SerializeField] private AudioSource cardTakenSource;
    [SerializeField] private AudioSource cardSettedSource;

    public void PlayShuffle()
    {
        shuffleSource.Play();
    }
    public void PlayDraw()
    {
        drawSource.Play();
    }

    public void PlayCardTaken()
    {
        cardTakenSource.Play();
    }

    public void PlayCardSetted()
    {
        cardSettedSource.Play();
    }

}