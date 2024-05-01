using UnityEngine;

public class HexCell : MonoBehaviour
{

	public HexCoordinates coordinates;

	public bool IsAdjacent(HexCoordinates coords)
	{

		int xDiff = coords.X - coordinates.X;
		int zDiff = coords.Z - coordinates.Z;
		double distance = Mathf.Sqrt(xDiff * xDiff + zDiff * zDiff);
		return distance <= 1;
	}



}