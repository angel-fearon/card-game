using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class DiceScript : MonoBehaviour
{
    public int rollNo;
    public Text diceText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roll()
    {
        rollNo = Random.Range(1, 7);
        diceText.text = rollNo.ToString();
    }
}
