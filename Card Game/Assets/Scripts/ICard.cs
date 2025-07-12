using UnityEngine;
namespace AbilityConstructor {
    /*Decorator design pattern has been used*/
    public interface IAbility
    {
        public void play();
    }

    //concrete component
    public class ConcreteAbility : IAbility
    {
        readonly Ability attackAbility;//protected (instead of readonly) keyword may cause problems
        readonly DisplayCharacter defenceCard;


        public ConcreteAbility(Ability attackAbility, DisplayCharacter defenceCard)
        {
            this.attackAbility = attackAbility;
            this.defenceCard = defenceCard;
        }
        public void play()
        {
            defenceCard.damage(attackAbility.baseDamage);
            Debug.Log(attackAbility.baseDamage + "damage dealt");
        }

    }

    //abstract decorator
    public abstract class AbilityDecorator: IAbility
    {
        protected IAbility wrappedAbility;

        protected AbilityDecorator(IAbility ability)
        {
            this.wrappedAbility = ability;
        }
        
        //by default the wrapped abilities play method is called unless overriden
        public virtual void play()
        {
           wrappedAbility.play();
        }

    }

    //concrete decorator(s) use heal as template
    public class HealDecorator : AbilityDecorator
    {
        private readonly int heal;
        //constructs HealDecorator by calling the superclass constructor using the abillity passed in (may be a concrete ability or even wrapped)
        public HealDecorator(IAbility ability,int heal) : base(ability)
        {
            this.heal = heal;
        }
        public override void play()
        {
            base.play();
            AttackScript.attackCard.damage(heal*-1);
            Debug.Log(AttackScript.attackCard + "healed for " + heal);
        }
    }
}