using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject Tower1;
    public Vector3 GridPos;
    private Vector3 offset = new Vector3(0,0.7f,0);
    public buildSystem sukkel;

    public float HoverSpeed = 0.2f;
    private Vector3 MoveTowards;

    private Renderer rend;
    private Color StartColor;
    public Color HoverColor;

    private bool MouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartColor = rend.material.color;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<buildSystem>().Mode && GetComponent<Grid>().GridField[Grid.targetX,Grid.targetZ].transform.childCount == 0)
            {
                Instantiate(Tower1, GridPos + offset, Quaternion.identity, transform);
            }
            else if (GetComponent<buildSystem>().Mode == false && transform.childCount == 1)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
        }
        
    }
}
