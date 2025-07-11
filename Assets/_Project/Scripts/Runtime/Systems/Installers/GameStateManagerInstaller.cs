using UnityEngine;
using Zenject;

public class GameStateManagerInstaller : MonoInstaller
{
    [SerializeField] private StateMachineManager _stateMachineManager;

    public override void InstallBindings()
    {
        Container.Bind<StateMachineManager>().FromInstance(_stateMachineManager);
    }
}