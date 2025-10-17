using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static Dictionary<int,Card> cards = new Dictionary<int,Card> ();
    public static Dictionary<int, CharacterCard> characters = new Dictionary<int, CharacterCard>();

    void Awake()
    {
        cards.Add(1, new Card(1, "Bonnet", 2, "Shield", Resources.Load<Sprite>("bonnet")));
        cards.Add(2, new Card(2, "Afro pick", 2, "The next attack does 2 addittional damage", Resources.Load<Sprite>("pick")));
        cards.Add(3, new Card(3, "Folding chair", 2, "Weapon", Resources.Load<Sprite>("folding chair")));
        cards.Add(4, new Card(4, "Jerk chicken", 2, "Chicken", Resources.Load<Sprite>("folding chair")));

        //Effect[] effects = { new Effect("heal", 1) };
        //Effect[] empty = { };
        //Ability[] melAbilities = { new Ability("1st ability", 2, empty), 
        //                           new Ability(" 2nd ability",3, effects )};
        //characters.Add(1, new CharacterCard(1, "Mel Medarda", 10, Resources.Load<Sprite>("mel medarda"), melAbilities));
        //Ability[] desireeAbilities = { new Ability("desiree ability", 3, empty),
        //                           new Ability(" 2nd ability",3, effects ) };
        //characters.Add(2, new CharacterCard(2, "Desiree", 10, Resources.Load<Sprite>("afro girl"),desireeAbilities));
        //Ability[] twinsAbilities = { new Ability("twins ability", 6, empty),
        //                           new Ability(" 2nd ability",3, effects ) };
        //characters.Add(3, new CharacterCard(3, "Smoke Stack Twins", 10, Resources.Load<Sprite>("smoke stack twins"), twinsAbilities));

    }
}
/*hours: 4.5
 * ideas:
 electric slide
*/
