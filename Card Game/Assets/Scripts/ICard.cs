using UnityEngine;
namespace AbilityConstructor {
    /*Decorator design pattern has been used*/
    //public class AbilityResult
    //{
    //    public int Damage { get; set; }
    //    public int Healing { get; set; }

    //    //default value for params is 0 if not set
    //    public AbilityResult(int damage = 0, int healing = 0)
    //    {
    //        Damage = damage;
    //        Healing = healing;
    //    }

    //    public void Add(AbilityResult other)
    //    {
    //        Damage += other.Damage;
    //        Healing += other.Healing;
    //    }
    //}
    //base component interface
    public interface IAbility
    {
        public void play();
        public Ability getAttackAbility();
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
        }

        public Ability getAttackAbility()
        {
            return attackAbility;
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

        public Ability getAttackAbility()
        {
            return wrappedAbility.getAttackAbility();
        }
    }

    //concrete decorator(s) use heal as template
    public class HealDecorator : AbilityDecorator
    {
        private readonly int heal;
        private readonly DisplayCard parentCard;
        //constructs HealDecorator by calling the superclass constructor using the abillity passed in (may be a concrete ability or even wrapped)
        public HealDecorator(IAbility ability,int heal) : base(ability)
        {
            this.heal = heal;
            //this.parentCard = ability.transform.parent.GetComponent<DisplayCard>();
        }
        public override void play()
        {
            Ability attack = wrappedAbility.getAttackAbility();
            
            //base.play();
        }
    }
}