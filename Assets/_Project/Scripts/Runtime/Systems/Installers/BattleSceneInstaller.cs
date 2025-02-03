using UnityEngine;
using Zenject;

public class BattleSceneInstaller : MonoInstaller
{
    [SerializeField] private TurnControl turnControl;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CardSpawner cardSpawner;

    public override void InstallBindings()
    {
        Container.Bind<TurnControl>().FromInstance(turnControl);
        Container.Bind<GameManager>().FromInstance(gameManager);
        Container.Bind<CardSpawner>().FromInstance(cardSpawner);


        Container.BindFactory<PlayerCard, PlayerCard, PlayerCardFactoryPlaceholder>().FromFactory<PlayerCardFactory>();
    }
}