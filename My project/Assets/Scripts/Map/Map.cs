using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Map : MonoBehaviour
{

    //witth and height should be setted in the unity editor
    public int width = 8;
    public int height = 8;

    [SerializeField]
    private PlayerCharacter player;//used to instantiate the player
    [SerializeField]
    private EnemyCharacter[] ennemiesType;

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
        HexCoordinates playerCoordinates = new HexCoordinates(1, 1);
        player.Innit(this, playerCoordinates);

        SpawnEnemies();

    }

    private void SpawnEnemies()
    {
        EnemyCharacter enemy = Instantiate(ennemiesType[0]);
        HexCoordinates enemyCoordinates = new HexCoordinates(3, 4);
        enemy.Innit(this, enemyCoordinates);

        enemy = Instantiate(ennemiesType[0]);
        enemyCoordinates = new HexCoordinates(2, 4);
        enemy.Innit(this, enemyCoordinates);

        enemy = Instantiate(ennemiesType[0]);
        enemyCoordinates = new HexCoordinates(1, 3);
        enemy.Innit(this, enemyCoordinates);

        enemy = Instantiate(ennemiesType[0]);
        enemyCoordinates = new HexCoordinates(4, 2);
        enemy.Innit(this, enemyCoordinates);

    }

    public HexCell GetHexCell(HexCoordinates destGrid)
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
            throw new System.Exception(" tried to get a cell out of the map:  (" + destGridArrayX + "," + destGridArrayZ + ")");
        }

        return targetCell;

    }

    /*
    Work like Move but will remove the gameobject from the old cell content
    
    return the new coordinate
    */

    public HexCoordinates MoveFrom(GameObject movedObject, HexCoordinates destGrid, HexCoordinates startingDest)
    {
        HexCoordinates newCoordinate = Move(movedObject, destGrid);

        //character from the old cell and add it for the new cell
        HexCell objectCell = GetHexCell(startingDest);
        objectCell.cellContent = null;

        return newCoordinate;
    }
    /*
    Move a give object to the given hexCoordinate
    You should check yourself if you can move to the given destination
    
    return the new coordinate
    */
    public HexCoordinates Move(GameObject movedObject, HexCoordinates destGrid)
    {

        HexCell targetCell;
        try
        {
            targetCell = GetHexCell(destGrid);
        }
        catch (System.Exception)
        {
            int destGridArrayZ = destGrid.Z;
            int destGridArrayX = destGrid.X + destGridArrayZ / 2;
            throw new System.Exception(movedObject + " tried to move out of the map:  (" + destGridArrayX + "," + destGridArrayZ + ")");
        }
        if (targetCell.IsOccupied())
        {
            int destGridArrayZ = destGrid.Z;
            int destGridArrayX = destGrid.X + destGridArrayZ / 2;
            throw new System.Exception(movedObject + " tried to move in an occupied spaces:  (" + destGridArrayX + "," + destGridArrayZ + ")");
        }

        targetCell.cellContent = movedObject;
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


