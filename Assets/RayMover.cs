using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMover : MonoBehaviour
{
    public GameObject FiveGBox;
    int rows = 4;
    int columns = 4;
    public float widthUnit;
    public float heightUnit;
    Vector3 bottomLeft;
    [SerializeField] private float minHorizantalAngel;

    // Start is called before the first frame update
    void Start()
    {
        //widthUnit = 1.8f / columns;
        //heightUnit = 2.5f / rows;
        bottomLeft = transform.position;
        StartCoroutine(MoveRayEverySecond());
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(1, 0, 0);
    }

    IEnumerator MoveRayEverySecond()
    {
        while(true)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    MoveRay(i, j);
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }
    void MoveRay(int row, int column)
    {
        this.transform.position = bottomLeft + new Vector3(0,heightUnit*row,widthUnit*column);
    }
}
