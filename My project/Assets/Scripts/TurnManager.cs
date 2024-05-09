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
    private EnemyCharacter[] ennemies;

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
        ennemies.Append<EnemyCharacter>(enemy);
    }
    public void addEnemies(EnemyCharacter[] enemies)
    {
        ennemies.Concat<EnemyCharacter>(enemies);
    }
    public void setPlayer(PlayerCharacter player)
    {
        this.player = player;
    }

    //Called by the player when his turn end
    public void PlayerEndTurn()
    {
        foreach (Character enemy in ennemies)
        {
            enemy.StartTurn();

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
