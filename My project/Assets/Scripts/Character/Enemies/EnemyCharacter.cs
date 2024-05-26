using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public int moneyValue;
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


    public override void Die()
    {
        //Give money to player
        map.player.EnemyKilled(this);


        base.Die();

        turnManager.removeEnemies(this);



    }
    public override void StartTurn()
    {
        base.StartTurn();

    }
    public override void EndTurn()
    {
        base.EndTurn();
    }
    //the map is in charge of moving the character
    public override void Move(HexCell destCell)
    {
        if (destCell.IsOccupied())
        {
            if (destCell.cellContent is EnemyCharacter)
            {
                //Do nothing == wait
            }
            else //prevent from enemies from attachink each other, I might add a "friendly interact" one day
            {
                FaceDirection(destCell);
                destCell.cellContent.Interact();

            }
        }
        else
        {
            FaceDirection(destCell);
            this.hexCell = map.MoveFrom(this, destCell, hexCell);
        }

    }














}














