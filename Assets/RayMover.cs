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
    public bool move = true;
    public int beamIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        move = true;
        //widthUnit = 1.8f / columns;
        //heightUnit = 2.5f / rows;
        //bottomLeft = transform.position;
        StartCoroutine(MoveRayEverySecond());
        // Convert angles from degrees to radians
       
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(1, 0, 0);
        if (!move) MoveRay(beamIndex);
    }

    IEnumerator MoveRayEverySecond()
    {
        while(true)
        {
            if (move)
            {
                for (beamIndex = 0; beamIndex <= 300; beamIndex++)
                {
                    MoveRay(beamIndex);
                    yield return new WaitForFixedUpdate();
                }
            }
            else break;
        }
    }
    void MoveRay(int beamIndex)
    {
        float minDegHorizontal = -Mathf.PI / 6;
        float minDegVertical = -Mathf.PI / 12;
        int numColumns = 50;
        int numRows = 6;
        int column = beamIndex % 50;
        int row = (int)Mathf.Floor((float)beamIndex / 50.0f);

        float degreeHorizontal = minDegHorizontal + row * (Mathf.PI / 3) / numColumns;
        float degreeVertical = minDegVertical + column * (Mathf.PI / 6) / numRows;

        // Step 1: Convert radians to local Euler angles.
        Vector3 localEulerAngles = new Vector3(degreeHorizontal, degreeVertical, 0.0f);
        
        // Step 2: Create quaternions from the local Euler angles.
        Quaternion horizontalRotation = Quaternion.Euler(0, localEulerAngles.y * Mathf.Rad2Deg, 0);
        Quaternion verticalRotation = Quaternion.Euler(localEulerAngles.x * Mathf.Rad2Deg, 0, 0);

        // Step 3: Combine the quaternions to obtain the final world-space quaternion.
        Quaternion finalRotation = horizontalRotation * verticalRotation;

        // Apply the rotation to the GameObject.
        transform.localRotation= finalRotation;

        //this.transform.rotation = Quaternion.LookRotation(new Vector3());
        //this.transform.position = bottomLeft + new Vector3(0,heightUnit*row,widthUnit*column);
    }
}
