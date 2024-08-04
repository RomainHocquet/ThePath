using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField]
        private GameObject LifeUI;
    [SerializeField]
    private GameObject AttackUI;
    [SerializeField]
    private GameObject ArmorUI;

    private TextMeshProUGUI  LifeText;
    private TextMeshProUGUI  AttackText;
    private TextMeshProUGUI  ArmorText;

    // Start is called before the first frame update
    void Awake()
    {       
         // Temporarily enable the GameObject
        bool wasActive = LifeUI.activeSelf;
        LifeUI.SetActive(true);

        // Get the TextMeshProUGUI component
        this.LifeText = LifeUI.GetComponent<TextMeshProUGUI >();
        this.AttackText = AttackUI.GetComponent<TextMeshProUGUI >();
        this.ArmorText = ArmorUI.GetComponent<TextMeshProUGUI >();

        // Restore the original active state
        LifeUI.SetActive(wasActive);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setHealt(int healt)
    {
        LifeText.text = "<color=#005500>Live :  " + healt; //#005500 is green
    }
    public void setAttack(int attack)
    {
        AttackText.text = "<color=#005500>g oublier d changé :  " + attack;  //#FF0000 is red
    }
    public void setArmor(int armor)
    {
        ArmorText.text = "<color=#60F0EF>Armor : " + armor;//#60F0EF
    }
}
