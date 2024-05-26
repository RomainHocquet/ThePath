using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ZombieCharacter : EnemyCharacter
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
base.moneyValue = 10;
    }

    // Update is called once per frame
    public override void Update()
    {

    }
    public override void StartTurn()
    {
        base.StartTurn();
        List<HexCell> path = PathFinder.FindPath(this.hexCell, map.player.hexCell);

        //if a path exist
        if (path.Count > 1)
        {
            // Debug.Log("path = " + path[1]);
            Move(path[1]);
        }
    }
    public override void EndTurn()
    {
        base.EndTurn();

        List<HexCell> adjacentCells = hexCell.returnAdjacent();


        foreach (HexCell cell in adjacentCells)
        {

            // Debug.Log($"HexCell at coordinates ({cell.coordinates.X}, {cell.coordinates.Z})");

            PlayerCharacter player;
            if (cell.cellContent != null)
            {
                if (cell.cellContent.TryGetComponent(out player))
                {
                    Debug.Log("Here " + this);
                    player.TakeDamage(1);
                }
            }
        }



    }
}
