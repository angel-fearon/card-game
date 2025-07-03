using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAbility : MonoBehaviour
{
    public int displayId;
    public int abilityId;
    public Text abilityName;
    public Ability a;
    public CharacterCard c;
    public DisplayCharacter parentScript;
    void Start()
    {
        parentScript = transform.parent.GetComponentInParent<DisplayCharacter>();
        displayId = parentScript.displayId;
        c = CardDatabase.characters[displayId];
        a = c.getAbilities()[abilityId];
    }

    void Update()
    {
        abilityName.text = a.getName();
    }

    public void onClick()
    {
        Debug.Log(a.getName() + "selected");
        var ability = AbilityFactory.createAbility(a);
    }



}
