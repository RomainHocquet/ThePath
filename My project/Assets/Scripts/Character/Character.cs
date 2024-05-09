using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : CellObject
{
    // [HideInInspector]
    public HexCell myHexCell;
    // [HideInInspector]
    public Map map;
    
    public int MaxHeatlhPoint = 1;
    public int currentHeatlhPoint = 1;
    public HealthBar healthbar;


    // Start is called before the first frame update
    public virtual void Start()
    {
    }
    public virtual void Innit(Map map, HexCell hexCell)
    {
        // map = GameObject.Find("Map").GetComponent<Map>();
        this.map = map;
        this.myHexCell = hexCell;

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    //the map is in charge of moving the character
    public virtual void Move(HexCell destCell)
    {
        if (destCell.IsOccupied())
        {
            destCell.cellContent.Interact();
        }
        else
        {
            this.myHexCell = map.MoveFrom(this, destCell, myHexCell);
        }
        
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
        Debug.Log("ca marche?");

    }
}
