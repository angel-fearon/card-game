using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCharacter : MonoBehaviour
{
    public GameObject cardBack;
    public GameObject abilityPanel;
    public int displayId;
    public Text health;
    public Image image;
    public CharacterCard character;
    private GameObject parent;
    public int currentHealth;
    private bool isAlive;
    public bool isFaceDown;
    

    //scripts
    public TurnSystem turnSystem;

    void Start()
    {
        abilityPanel.SetActive(false);
        isAlive = true;
        parent = transform.parent.gameObject;
        character = CardDatabase.characters[displayId];
        currentHealth = character.getHealth();
        
    }
    void Update()
    {
        cardBack.SetActive(isFaceDown);
        show();
    }
    public void show()
    {
        //name.text = character.getName();
        health.text = currentHealth.ToString();
        image.sprite = character.getSprite();
    }
    public void cardClicked()
    {
        //Debug.Log(character.getName() + " card selected ID: " + displayId);
        if (TurnSystem.isYourTurn == true && parent.name == "PlayerCharacters" || TurnSystem.isYourTurn == false && parent.name == "OpponentCharacters")
        {
            abilityPanel.SetActive(true);
        }
        AttackScript.Instance.setCurrentCharacter(this);
    }

    public void damage(int damage)
    {
        //deals damage
        if (damage <= currentHealth)
        {
            currentHealth -= damage;
        }
        else if (damage > currentHealth)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            isAlive = false;
            if (checkAlliesAlive() == false)
            {
                TurnSystem.currentPhase = GamePhase.GameOver;
            }
            
        }
    }

    public bool checkAlliesAlive()
    {
        bool alliesAlive = false;

        //get other chararacters within panel
        GameObject[] characters = new GameObject[3];
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = parent.transform.GetChild(i).gameObject;
        }

        //check if each character isAlive
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].GetComponent<DisplayCharacter>().getIsAlive() == true)
            {
                alliesAlive = true;
                break;
            }
        }
        return alliesAlive;
    }

    public bool getIsAlive()
    {
        return isAlive;
    }


}
