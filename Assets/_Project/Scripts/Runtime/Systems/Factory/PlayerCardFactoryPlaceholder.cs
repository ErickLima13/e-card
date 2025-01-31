using UnityEngine;
using Zenject;

public class PlayerCardFactoryPlaceholder : PlaceholderFactory<PlayerCard,PlayerCard>
{
}

public class PlayerCardFactory : IFactory<PlayerCard,PlayerCard>
{
    private readonly DiContainer _container;

    public PlayerCardFactory(DiContainer diContainer)
    {
        _container = diContainer;
    }

    public PlayerCard Create(PlayerCard playerCardPrefab)
    {
        var card =  GameObject.Instantiate(playerCardPrefab);
        _container.BindInstance(card);
        _container.Inject(card);
        return card;
    }


}

