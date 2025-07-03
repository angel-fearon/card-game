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
    public CharacterCard c;
    public GameObject parent;
    public int currentHealth;
    private bool isAlive;
    public bool isFaceDown;
    

    //scripts
    public AttackScript attack;
    public TurnSystem turnSystem;

    void Start()
    {
        isAlive = true;
        parent = transform.parent.gameObject;
        c = CardDatabase.characters[displayId];
        currentHealth = c.getHealth();
        
    }
    void Update()
    {
        cardBack.SetActive(isFaceDown);
        show();
    }
    public void show()
    {
        //name.text = c.getName();
        health.text = currentHealth.ToString();
        image.sprite = c.getSprite();
    }
    public void cardClicked()
    {
        //Debug.Log(c.getName() + " card selected ID: " + displayId);
        abilityPanel.SetActive(true);
        attack.setCurrentCharacter(c,parent,this);
    }

    public void damageCharacter(int damage)
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
                TurnSystem.continueGame = false;
            }
            
        }
    }

    public bool checkAlliesAlive()
    {
        bool alliesAlive = false;

        //get other charaacters within panel
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
