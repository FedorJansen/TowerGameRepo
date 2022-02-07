using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject[,] GridField;

    public int targetX;
    public int targetZ;

    private int maxX;
    private int maxZ;

    public GameObject currentTile;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] Temp;
        Temp = GameObject.FindGameObjectsWithTag("GridTile");
        foreach (GameObject Tile in Temp)
        {
            if (Tile.transform.position.x > maxX)
            {
                maxX = (int)Tile.transform.position.x;
            }
            if (Tile.transform.position.z > maxZ)
            {
                maxZ = (int)Tile.transform.position.z;
            }
        }

        GridField = new GameObject[maxX + 1, maxZ+ 1];
        foreach (GameObject Tile in Temp)
        {
            GridField[(int) Tile.transform.position.x, (int)Tile.transform.position.z] = Tile;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseInformation();
        if (MissingTileCheck())
        {
            HighlightTile();
        }
    }

    bool MissingTileCheck()
    {
        if (GridField[targetX,targetZ] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HighlightTile()
    {
        currentTile = GridField[targetX, targetZ];
    }

    void MouseInformation()
    {
        Plane plane = new Plane(Vector3.up, 0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 tempTarget = ray.GetPoint(distance);
            targetX = (int)Mathf.Round(tempTarget.x);
            targetZ = (int)Mathf.Round(tempTarget.z);
        }
        //Safeguard system (out of bounds error)
        if (targetX < 0)
        {
            targetX = 0;
        }
        if (targetZ < 0)
        {
            targetZ = 0;
        }
        if (targetX > maxX)
        {
            targetX = maxX;
        }
        if (targetZ > maxZ)
        {
            targetZ = maxZ;
        }
    }
}
