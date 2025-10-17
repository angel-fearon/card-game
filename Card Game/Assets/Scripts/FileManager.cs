using UnityEngine;
using System.IO;
using UnityEditor.Overlays;
using static FileManager;

public class FileManager : MonoBehaviour
{
    public TextAsset cardData;//the file
    public static CharacterList characterList;

    public static FileManager Instance { get; private set; }

    //ensures turnsystem is a singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);//optional clause
        }

        generateCharacterList();//get list of characters
    }
    [System.Serializable]

    public class CharacterList
    {
        public CharacterCard[] characters;

        public CharacterCard getCharacter(int id)
        {
            return this.characters[id];
        }
    }

    private void generateCharacterList()
    {
        characterList = JsonUtility.FromJson<CharacterList>(cardData.text);
        Debug.Log("Chracter id read" + characterList.getCharacter(0).getId());
        Debug.Log("Chracter id read" + characterList.getCharacter(1).getId());
    }

    void Start()
    {
        

    }
    void Update()
    {
        
    }


}
