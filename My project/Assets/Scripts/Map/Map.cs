using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Map : MonoBehaviour
{


    public int width = 8;
    public int height = 8;

    [SerializeField]
    private PlayerCharacter player;//used to instantiate the player

    public HexCell cellPrefab;

    // HexCell[] cells;
    HexCell[,] cells;


    void Start()
    {
        cells = new HexCell[height, width];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                CreateCell(x, z);
            }
        }

        Instantiate(player);
        player.coordinates = new HexCoordinates(1, 1);

    }

    /*
    Move a give object to the given hexCoordinate
    return false if it fail
    */
    public HexCoordinates Move(GameObject movedObject, HexCoordinates destGrid)
    {
        int destGridArrayZ = destGrid.Z;
        int destGridArrayX = destGrid.X + destGridArrayZ / 2;

        HexCell targetCell;
        try
        {
            targetCell = cells[destGridArrayX, destGridArrayZ];
        }
        catch (System.Exception)
        {
            throw new System.Exception(movedObject + " tried to move out of the map:  (" + destGridArrayX + "," + destGridArrayZ + ")");
        }

        Vector3 dest = targetCell.transform.position;
        movedObject.transform.position = dest;

        // Debug.Log("new coordinates: (" + destGridArrayX + "," + destGridArrayZ + ")");

        return targetCell.coordinates;
    }

    void CreateCell(int x, int z)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[x, z] = Instantiate(cellPrefab);
        cell.gameObject.name = cellPrefab.gameObject.name + "(" + x + "," + z + ")";

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

    }

    // Update is called once per frame
    void Update()
    {

    }
}


