using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HexCell : MonoBehaviour
{
	/*
	Ressource for pathfinding https://blog.theknightsofunity.com/pathfinding-on-a-hexagonal-grid-a-algorithm/
	*/

	public HexCoordinates coordinates;
	public CellObject cellContent;
	public Map map;
	//Can be walked on
	public bool isObstacle;
public PathFindData pathFindData;

	//return true if there is a gameobject on that cell
	public bool IsOccupied()
	{
		if (cellContent)
			return true;
		else
			return false;
	}

	public bool IsAdjacent(HexCoordinates coords)
	{
		return Distance(coords) <= 1;
	}
	public List<HexCell> returnAdjacent()
	{
		List<HexCell> adjacentCells = new List<HexCell>();

		int[,] directions = {
	{ -1, 1 }, { 0, 1 }, { 1, 0 },
	{ 1, -1 }, { 0, -1 }, { -1, 0 }
	};

		for (int i = 0; i < directions.GetLength(0); i++)
		{
			int deltaX = directions[i, 0];
			int deltaZ = directions[i, 1];

			// Calculate the coordinates of the neighbor cell
			HexCoordinates destGridCoordinate = new HexCoordinates(coordinates.X + deltaX, coordinates.Z + deltaZ);

			// HexCell cell = map.GetHexCell(destGridCoordinate);
			// if (cell != null)
			// {
			// 	adjacentCells.Add(cell);
			// }    


			try
			{
				HexCell cell = map.GetHexCell(destGridCoordinate);
				adjacentCells.Add(cell);
			}
			catch (System.Exception)
			{
				//TODO: create a custom OutOfMap exception
				//Happen when the cell is null, then you should to nothing
			}

		}
		return adjacentCells;
	}

	public int Distance(HexCoordinates coords)
	{

		int xDiff = Mathf.Abs(coords.X - coordinates.X);
		int yDiff = Mathf.Abs(coords.Y - coordinates.Y);
		int zDiff = Mathf.Abs(coords.Z - coordinates.Z);
		int distance = Mathf.Max(xDiff, yDiff, zDiff);

		// Debug.Log("xDiff = " + xDiff) ;
		// Debug.Log("xDiff = " + yDiff) ;
		// Debug.Log("zDiff = "+ zDiff );
		// Debug.Log("distance = " + distance);
		return distance;

	}
	public int Distance(HexCell destHexCell)
	{
		return Distance(destHexCell.coordinates);

	}



}