using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    up, down, left, right
}
public class PlayerInput : MonoBehaviour
{
    public Vector3 direction;
    public bool oneDirection, noDirection, turning;

    // Update is called once per frame
    void Update()
    {
        oneDirection = Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0;
        noDirection = Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0;
        turning = Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0;

        if (oneDirection || turning)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                direction = Vector3.forward;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                direction = Vector3.back;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = Vector3.left;
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = Vector3.right;
            }
        }
    }
}
