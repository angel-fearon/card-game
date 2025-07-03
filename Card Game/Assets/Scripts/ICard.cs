using UnityEngine;
namespace AbilityConstructor {
    /*Decorator design pattern has been used*/
    public class AbilityResult
    {
        public int Damage { get; set; }
        public int Healing { get; set; }

        //default value for params is 0 if not set
        public AbilityResult(int damage = 0, int healing = 0)
        {
            Damage = damage;
            Healing = healing;
        }

        public void Add(AbilityResult other)
        {
            Damage += other.Damage;
            Healing += other.Healing;
        }
    }
    //base component interface
    public interface IAbility
    {
        public AbilityResult play();
    }

    //concrete component
    public class ConcreteAbility : IAbility
    {
        readonly int damage;
        
        public ConcreteAbility(int damage)
        {
            this.damage = damage;
        }
        public AbilityResult play()
        {
            return new AbilityResult(damage: damage);
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
        
        //by default the wrapped abilities play method is returned unless overriden
        public virtual AbilityResult play()
        {
            return wrappedAbility.play();
        }
    }

    //concrete decorator(s) use heal as template
    public class HealDecorator : AbilityDecorator
    {
        private readonly int healAmount;
        //constructs HealDecorator by calling the superclass constructor
        public HealDecorator(IAbility ability,int heal) : base(ability)
        {
            this.healAmount = heal;
        }
        public override AbilityResult play()
        {
            var result = base.play();
            result.Healing += healAmount;
            return result;
        }
    }
}