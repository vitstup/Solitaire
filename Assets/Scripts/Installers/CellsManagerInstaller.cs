using UnityEngine;
using Zenject;

public class CellsManagerInstaller : MonoInstaller
{
    [SerializeField] private CellsManager cellsManager;
    public override void InstallBindings()
    {
        Container.Bind<CellsManager>().FromInstance(cellsManager).AsSingle().NonLazy();
    }
}