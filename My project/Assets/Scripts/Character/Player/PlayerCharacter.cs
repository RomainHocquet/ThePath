using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCharacter : Character
{

    private new Camera camera;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        camera = Camera.main;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HexCell cellHit;
                try
                {
                    cellHit = hit.transform.GetComponentInParent<HexCell>();

                }
                catch (System.Exception)
                {
                    throw new System.Exception(" hit a mesh that doesn't contain a HexCell");
                }
                if (cellHit.IsAdjacent(this.coordinates))
                {
                    Move(cellHit);
                }
                else Debug.Log("Clicked cell is not adjacent to player");

            }

        }
    }

}