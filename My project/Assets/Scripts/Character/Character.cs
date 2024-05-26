using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : CellObject
{
    // [HideInInspector]
    public HexCell hexCell;
    // [HideInInspector]
    public Map map;

    public int MaxHeatlhPoint = 1;
    public int currentHeatlhPoint = 1;
    public HealthBar healthbar;
    protected TurnManager turnManager;


    // Start is called before the first frame update
    public virtual void Start()
    {
    }
    public virtual void Innit(Map map, HexCell hexCell, TurnManager turnManager)
    {
        // map = GameObject.Find("Map").GetComponent<Map>();
        this.map = map;
        this.hexCell = hexCell;
        this.turnManager = turnManager;
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    //the map is in charge of moving the character
    public virtual void Move(HexCell destCell)
    {
            FaceDirection(destCell);
        if (destCell.IsOccupied())
        {
            destCell.cellContent.Interact();
        }
        else
        {
            this.hexCell = map.MoveFrom(this, destCell, hexCell);
        }


    }

    public virtual void FaceDirection(HexCell destCell)
    {

        Transform pointA = hexCell.transform; // First point
        Transform pointB = destCell.transform; // Second point

        // Step 1: Calculate the direction vector
        Vector3 direction = pointB.position - pointA.position;

        // Step 2: Create the rotation
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Optionally, apply this rotation to an object (for example, pointA)
        gameObject.transform.rotation = rotation;

        // Debugging: Visualize the direction in the editor
        Debug.DrawLine(pointA.position, pointB.position, Color.red);
        Debug.Log(rotation);

    }




    public virtual void Die()
    {
        Destroy(this.gameObject);

    }
    public void TakeDamage(int damage)
    {

        currentHeatlhPoint -= damage;
        if (currentHeatlhPoint <= 0)
        {
            Die();
        }

        healthbar.UpdateHealth((float)currentHeatlhPoint / (float)MaxHeatlhPoint);
    }
    public virtual void StartTurn()
    {

    }
    public virtual void EndTurn()
    {
        // Debug.Log("ca marche?");

    }
}
