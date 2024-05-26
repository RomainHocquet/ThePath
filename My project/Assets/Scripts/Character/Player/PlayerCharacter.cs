using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : Character
{

[SerializeField]
private Inventory myInventory;
    private new Camera camera;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        // Debug.Log("start = " + hexCell);

        camera = Camera.main;
    }

    public override void Innit(Map map, HexCell hexCell, TurnManager turnManager)
    {
        base.Innit(map, hexCell, turnManager);
        // Debug.Log("Innit = " + myHexCell);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HexCell cellHit;
                try
                {
                    cellHit = hit.transform.GetComponentInParent<HexCell>();

                }
                catch (System.Exception)
                {
                    throw new System.Exception("hit a mesh that doesn't contain a HexCell");
                }
                if (cellHit.IsAdjacent(this.hexCell.coordinates))
                {
                    Move(cellHit);
                    EndTurn();
                }
                else Debug.Log("Clicked cell is not adjacent to player");

            }

        }
    }

public void EnemyKilled(EnemyCharacter enemyKilled){

    myInventory.AddMoney(enemyKilled.moneyValue);
}
    public override void StartTurn()
    {
        base.StartTurn();
    }
    public override void EndTurn()
    {
        base.EndTurn();
       turnManager.PlayerEndTurn();

    }

}
