using UnityEngine;
using Zenject;

public class GenericFactory<T> where T : MonoBehaviour
{
    private DiContainer container;

    private T prefab;

    public GenericFactory(DiContainer container, T prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public T GetNewInstance()
    {
        return container.InstantiatePrefab(prefab.gameObject).GetComponent<T>();
    }
}