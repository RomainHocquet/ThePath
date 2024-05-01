using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{

    public HexCoordinates coordinates;
    public Map map;


    // Start is called before the first frame update
    public virtual void Start()
    {
        map = GameObject.Find("Map").GetComponent<Map>();
    }

    // Update is called once per frame
    public virtual void  Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            HexCoordinates newDest = new HexCoordinates(coordinates.X - 1, coordinates.Z);
            Move(newDest);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            HexCoordinates newDest = new HexCoordinates(coordinates.X + 1, coordinates.Z);
            Move(newDest);
        }
    }

    //the map is in charge of moving the character
    public virtual void Move(HexCoordinates destGrid)
    {
        this.coordinates = map.Move(gameObject, destGrid);
    }
    public virtual void Move(HexCell destGrid)
    {
        Move(destGrid.coordinates);
    }
}
