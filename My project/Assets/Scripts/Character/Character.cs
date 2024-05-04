using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    // [HideInInspector]
    public HexCoordinates coordinates;
    // [HideInInspector]
    public Map map;


    // Start is called before the first frame update
    public virtual void Start()
    {
    }
    public virtual void Innit(Map map,HexCoordinates coordinates)
    {
        // map = GameObject.Find("Map").GetComponent<Map>();
        this.map = map;
        this.coordinates = coordinates;
        
        HexCoordinates startingDest = new HexCoordinates(coordinates.X, coordinates.Z);
        this.coordinates = map.Move(gameObject, startingDest);
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    //the map is in charge of moving the character
    public virtual void Move(HexCoordinates destGrid)
    {
        HexCell targetCell = map.GetHexCell(destGrid);
        if(targetCell.IsOccupied()){
            //Do nothing
        }
        this.coordinates = map.MoveFrom(gameObject, destGrid,coordinates);
    }
    public virtual void Move(HexCell destGrid)
    {
        Move(destGrid.coordinates);
    }
}
