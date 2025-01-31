using UnityEngine;

public static class BattleSystemFactory 
{
    public static ICardBehavior Create(TypeCard typeCard)
    {
        switch (typeCard)
        {
            case TypeCard.Citizen:
               return new CitizenCardBehavior();
            case TypeCard.Slave:
                return new SlaveCardBehavior();
            case TypeCard.Emperor:
                return new EmperorCardBehavior();
        }

        throw new System.ArgumentOutOfRangeException("TypeCard",$"There is not behavior for {typeCard}");
    }



}
