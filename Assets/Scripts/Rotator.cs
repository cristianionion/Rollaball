using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
            // rotate the game object that this script is attached to by 15 in the x axis
            // 30 in the Y axis and 45 in the Z axis, multiplied by deltaTime in order to make it per second
            // rather than per frame
        transform.Rotate (new Vector3 (15,30,45) * Time.deltaTime);
    }
}
