using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{

    //Base comportement for a player interacting with an ennemy is the player attacking the ennemy
    public override void Interact()
    {
        TakeDamage(1);
    }


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {

    }
    public override void StartTurn()
    {
        base.StartTurn();

    }
    public override void EndTurn()
    {
        base.EndTurn();
     Debug.Log("ca marche ennemy");
    }
}
