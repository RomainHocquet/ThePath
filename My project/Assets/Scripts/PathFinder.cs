using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

// Define a class that holds HexCell object along with F, G, and H integers
//May need to be defined in its own file
public class PathFindData
{
    public int F;// = G+H
    public int G;
    public int H;

    public PathFindData(int g, int h)
    {
        G = g;
        H = h;
        F = g + h;
    }
}



public static class PathFinder
{

    /// Finds path from given start point to end point. Returns an empty list if the path couldn't be found.
    public static List<HexCell> FindPath(HexCell startPoint, HexCell endPoint)
    {

        List<HexCell> openPathHexCells = new List<HexCell>();
        List<HexCell> closedPathHexCells = new List<HexCell>();

        //G is our current movement cost we have to spend to move from the starting point to the current considered tile
        int g = 0;
        //H is the estimated movement cost from the current considered tile to target tile.
        int h = startPoint.Distance(endPoint);

        HexCell currentHexCell = startPoint;
        currentHexCell.pathFindData = new PathFindData(g, h);

        // Add the start HexCell to the open list.
        openPathHexCells.Add(currentHexCell);
        while (openPathHexCells.Count != 0)
        {
            // Sorting the open list to get the HexCell with the lowest F.
            openPathHexCells = openPathHexCells.OrderBy(x => x.pathFindData.F).ThenByDescending(x => x.pathFindData.G).ToList();

            // openPathHexCells = openPathHexCells.OrderBy(x => x.F).ThenByDescending(x => x.g).ToList();
            currentHexCell = openPathHexCells[0];

            // Removing the current HexCell from the open list and adding it to the closed list.
            openPathHexCells.Remove(currentHexCell);
            closedPathHexCells.Add(currentHexCell);

            g = currentHexCell.pathFindData.G + 1;

            // If there is a target HexCell in the closed list, we have found a path.
            if (closedPathHexCells.Contains(endPoint))
            {
                break;
            }

            List<HexCell> adjacentHexCells = currentHexCell.returnAdjacent();
            // Investigating each adjacent HexCell of the current HexCell.
            foreach (HexCell adjacentHexCell in adjacentHexCells)
            {
                // Ignore not walkable adjacent tiles.
                if (adjacentHexCell.isObstacle)
                {
                    continue;
                }

                // Ignore the HexCell if it's already in the closed list.
                if (closedPathHexCells.Contains(adjacentHexCell))
                {
                    continue;
                }

                // If it's not in the open list - add it and compute G and H.
                if (!(openPathHexCells.Contains(adjacentHexCell)))
                {
                    adjacentHexCell.pathFindData = new PathFindData(g, adjacentHexCell.Distance(endPoint.coordinates));
                    openPathHexCells.Add(adjacentHexCell);
                }
                // Otherwise check if using current G we can get a lower value of F, if so update it's value.
                else if (adjacentHexCell.pathFindData.G > g)
                {
                    adjacentHexCell.pathFindData.G = g;
                }
            }
        }

        List<HexCell> finalPathHexCells = new List<HexCell>();

        // Backtracking - setting the final path.
        if (closedPathHexCells.Contains(endPoint))
        {
            currentHexCell = endPoint;
            finalPathHexCells.Add(currentHexCell);

            for (int i = endPoint.pathFindData.G - 1; i >= 0; i--)
            {
                List<HexCell> adjacentHexCells = currentHexCell.returnAdjacent();

                currentHexCell = closedPathHexCells.Find(x => x.pathFindData.G == i && adjacentHexCells.Contains(x));
                finalPathHexCells.Add(currentHexCell);
            }

            finalPathHexCells.Reverse();
        }

        return finalPathHexCells;
    }


}

