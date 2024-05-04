using Unity.VisualScripting;
using UnityEngine;

public class HexCell : MonoBehaviour
{
	/*
	Ressource for pathfinding https://blog.theknightsofunity.com/pathfinding-on-a-hexagonal-grid-a-algorithm/
	*/

	public HexCoordinates coordinates;
	public GameObject cellContent;

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



}