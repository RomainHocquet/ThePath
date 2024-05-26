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
    private List<EnemyCharacter> enemies = new List<EnemyCharacter>();


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

    public void addEnemies(EnemyCharacter enemy)
    {
        enemies.Add(enemy);
    }
    public void addEnemies(EnemyCharacter[] enemies)
    {
        this.enemies.AddRange(enemies);
    }
    public void removeEnemies(EnemyCharacter enemy)
    {
        enemies.Remove(enemy);
    }

    public void setPlayer(PlayerCharacter player)
    {
        this.player = player;
    }

    //Called by the player when his turn end
    public void PlayerEndTurn()
    {
        foreach (Character enemy in enemies)
        {
            enemy.StartTurn();
            enemy.EndTurn();

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
