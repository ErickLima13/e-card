using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private TurnControl turnControl;

    public override void InstallBindings()
    {
        Container.Bind<TurnControl>().FromInstance(turnControl);
        Container.Bind<PlayerHand>().FromComponentInHierarchy().AsSingle().NonLazy();

        Container.BindFactory<PlayerCard, PlayerCard, PlayerCardFactoryPlaceholder>().FromFactory<PlayerCardFactory>();
    }
}