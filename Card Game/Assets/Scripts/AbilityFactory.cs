using AbilityConstructor;
using UnityEngine;
using UnityEngine.Assertions.Must;
/**/
public class AbilityFactory
{
    public static IAbility createAbility(Ability a, DisplayCharacter defenseCard)
    {
        IAbility ability = new ConcreteAbility(a, defenseCard);

        foreach (var e in a.effects)
        {
            switch (e.type.ToLower())
            {
                case "heal":
                    ability = new HealDecorator(ability, e.value);
                    break;

                //add more effects where necessary
            }
        }
        return ability;
    }
    
}
