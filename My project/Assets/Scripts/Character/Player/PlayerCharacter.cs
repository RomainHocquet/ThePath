using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacter : Character
{

    [SerializeField]
    private Inventory myInventory;

    // [SerializeField]
    private StatsUI myStats;
    private new Camera camera;


    public void Awake()
    {
        myStats = MainUI.PlayerStatsUI.GetComponent<StatsUI>();

    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.attackPower = 2;
        // Debug.Log("start = " + hexCell);

        camera = Camera.main;
    }

    public override void Innit(Map map, HexCell hexCell, TurnManager turnManager)
    {
        base.Innit(map, hexCell, turnManager);

        Debug.Log("myStats = " + myStats);

        myStats.setHealt(base.currentHeatlhPoint);
        myStats.setAttack(base.attackPower);
        // myStats.setArmor(base.attackPower);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...

            if (EventSystem.current.IsPointerOverGameObject())
            {
                //Clicked over the UI so do nothing
                return;
            }


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

                    if (cellHit.cellContent.GetComponent<MerchantCharacter>())
                    {
                        //Don't end the turn if the player open the shop
                    }
                    else
                    {
                        EndTurn();
                    }
                }
                else Debug.Log("Clicked cell is not adjacent to player");

            }

        }
    }

    public void EnemyKilled(EnemyCharacter enemyKilled)
    {

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
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        myStats.setHealt(base.currentHeatlhPoint);
    }

}
