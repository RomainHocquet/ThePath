using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Map : MonoBehaviour
{

    //witth and height should be setted in the unity editor
    public int width = 8;
    public int height = 8;

    [SerializeField]
    public PlayerCharacter player;//used to instantiate the player
    [SerializeField]
    private TurnManager turnManager;

    [SerializeField]
    private Character[] entitiesType;

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

        //Spawn player
        player = Instantiate(player);
        HexCoordinates playerCoordinates = new HexCoordinates(1, 1);
        HexCell destHex = GetHexCell(playerCoordinates);
        player.Innit(this, destHex, turnManager);
        Move(player, destHex);
        turnManager.setPlayer(player);


        SpawnEnemies();

        //spawn merchent
        HexCoordinates enemyCoordinates = new HexCoordinates(3, 1);
          Character newCharacter = SpawnCharacter(entitiesType[1], enemyCoordinates);
        Debug.Log(" entitiesType[1] = " + entitiesType[1]);
        Debug.Log(" newCharacter =" + newCharacter);
    }

    private void SpawnEnemies()
    {
        HexCoordinates enemyCoordinates = new HexCoordinates(3, 4);
        SpawnCharacter(entitiesType[0], enemyCoordinates);

        enemyCoordinates = new HexCoordinates(4, 2);
        SpawnCharacter(entitiesType[0], enemyCoordinates);

        enemyCoordinates = new HexCoordinates(2, 4);
        SpawnCharacter(entitiesType[0], enemyCoordinates);

    }

    private Character SpawnCharacter(Character characterType, HexCoordinates coordinates)
    {
        Character newCharacter;
        if (characterType is EnemyCharacter)
        {
            newCharacter = (EnemyCharacter)Instantiate(characterType);
            turnManager.addCharacter((EnemyCharacter)newCharacter);
        }
        else
        {
            newCharacter = Instantiate(characterType);
            turnManager.addCharacter(newCharacter);
        }

        HexCell destHex = GetHexCell(coordinates);
        newCharacter.Innit(this, destHex, turnManager);
        Move(newCharacter, destHex);
        return newCharacter;
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
    
    return the HexCell
    */

    public HexCell MoveFrom(CellObject movedObject, HexCell destGrid, HexCell startingDest)
    {
        HexCell newCoordinate = Move(movedObject, destGrid);

        //character from the old cell and add it for the new cell
        startingDest.cellContent = null;

        return newCoordinate;
    }
    /*
    Move a give object to the given hexCoordinate
    You should check yourself if you can move to the given destination
    
    return the HexCell
    */
    public HexCell Move(CellObject movedObject, HexCell destCell)
    {

        if (destCell.IsOccupied())
        {
            int destGridArrayZ = destCell.coordinates.Z;
            int destGridArrayX = destCell.coordinates.X + destGridArrayZ / 2;
            throw new System.Exception(movedObject + " tried to move in an occupied spaces:  (" + destGridArrayX + "," + destGridArrayZ + ")");
        }

        destCell.cellContent = movedObject;
        Vector3 dest = destCell.transform.position;
        movedObject.transform.position = dest;

        // Debug.Log("new coordinates: (" + destGridArrayX + "," + destGridArrayZ + ")");

        return destCell;
    }

    void CreateCell(int x, int z)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        HexCell cell = cells[x, z] = Instantiate(cellPrefab);
        cell.map = this;
        cell.gameObject.name = cellPrefab.gameObject.name + "(" + x + "," + z + ")";
        cell.isObstacle = false;

        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

    }

    // Update is called once per frame
    void Update()
    {

    }
}


