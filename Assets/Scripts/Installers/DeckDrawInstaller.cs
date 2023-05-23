using UnityEngine;
using Zenject;

public class DeckDrawInstaller : MonoInstaller
{
    [SerializeField] private DeckDraw deckDraw;

    public override void InstallBindings()
    {
        Container.Bind<DeckDraw>().FromInstance(deckDraw).AsSingle().NonLazy();
    }
}