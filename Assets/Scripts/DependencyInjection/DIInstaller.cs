using UnityEngine;
using Zenject;

public class DIInstaller : MonoInstaller
{
    [SerializeField] private bool flag; // true - C# class Configuration, false - ScriptableObject
    [SerializeField] private SOConfiguration sOConfig;

    public override void InstallBindings()
    {
        if (flag)
        {
            Container.Bind<IConfiguration>().To<Configuration>().AsSingle().NonLazy();
        }
        else
        {
            Container.Bind<IConfiguration>().To<SOConfiguration>().FromInstance(sOConfig).AsSingle().NonLazy();
        }
    }
}