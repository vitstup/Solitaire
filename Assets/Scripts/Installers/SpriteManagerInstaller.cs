using UnityEngine;
using Zenject;

public class SpriteManagerInstaller : MonoInstaller
{
    [SerializeField] private CardsSpritesManager spritesManager;

    public override void InstallBindings()
    {
        Container.Bind<CardsSpritesManager>().FromInstance(spritesManager).AsSingle().NonLazy();
    }
}