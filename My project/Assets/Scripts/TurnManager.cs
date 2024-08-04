using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{


    [SerializeField]//Not nessecary
    private PlayerCharacter player;

    [SerializeField]//Not nessecary
    private List<EnemyCharacter> enemiesCharacter = new List<EnemyCharacter>();

    [SerializeField]//Not nessecary
    private List<Character> otherCharacters = new List<Character>();


    [SerializeField]
    private Text turnTimerText;
    private int turnTimer;


    // Start is called before the first frame update
    void Start()
    {
        turnTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addCharacter(Character character)
    {

        if (character is EnemyCharacter)
        {
            EnemyCharacter enemy = (EnemyCharacter)character;
            addEnemies(enemy);
        }
        else
        {

            otherCharacters.Add(character);
        }
    }
    public void removeCharacter(Character character)
    {
        if (character is EnemyCharacter)
        {
            EnemyCharacter enemy = (EnemyCharacter)character;
            removeEnemies(enemy);
        }
        else
        {
            otherCharacters.Remove(character);
        }
    }


    private void addEnemies(EnemyCharacter enemy)
    {
        enemiesCharacter.Add(enemy);
    }

    private void addEnemies(EnemyCharacter[] enemies)
    {
        this.enemiesCharacter.AddRange(enemies);
    }
    private void removeEnemies(EnemyCharacter enemy)
    {
        enemiesCharacter.Remove(enemy);
    }

    public void setPlayer(PlayerCharacter player)
    {
        this.player = player;
    }

    //Called by the player when his turn end
    public void PlayerEndTurn()
    {
        foreach (EnemyCharacter enemy in enemiesCharacter)
        {
            enemy.StartTurn();
            enemy.EndTurn();
        }
        foreach (Character character in otherCharacters)
        {
            character.StartTurn();
            character.EndTurn();
        }
        PlayerStartTurn();
    }
    public void PlayerStartTurn()
    {
        turnTimer += 1;
        setTurn(turnTimer);
    }

    public void setTurn(int turnNumber)
    {
        turnTimerText.text = "Turn : " + turnNumber;
    }
}
