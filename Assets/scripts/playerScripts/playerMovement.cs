using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 0f;
    public float playerRotateSpeed = 0f;
    public float angleToRotate = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (this.transform.eulerAngles.y != 0)
            {
                if (Mathf.Abs(0 - this.transform.eulerAngles.y) < 5) //Tolerance
                    this.transform.Rotate(0f, 0 - this.transform.eulerAngles.y, 0f, Space.World); //Rotate to become 0
                else if (Mathf.Abs(this.transform.eulerAngles.y - 360) < 5) //Tolerance
                    this.transform.Rotate(0f, this.transform.eulerAngles.y - 360, 0f, Space.World); //Rotate to become 0
                else if (this.transform.eulerAngles.y > 0 && this.transform.eulerAngles.y < 180) //Quadrant 1 and 4
                {
                    angleToRotate = this.transform.eulerAngles.y;
                    this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
                }
                else //Quadrant 2 and 3
                {
                    angleToRotate = 360 - this.transform.eulerAngles.y;
                    this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate clockwise
                }
            }
            this.transform.Translate(0f, 0f, playerSpeed * Time.deltaTime, Space.World); //Translate forward
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (this.transform.eulerAngles.y != 180)
            {
                if (Mathf.Abs(180 - this.transform.eulerAngles.y) < 5) //Tolerance
                    this.transform.Rotate(0f, 180 - this.transform.eulerAngles.y, 0f, Space.World); //Rotate to become 180
                else //All quadrants
                {
                    angleToRotate = 180 - this.transform.eulerAngles.y;
                    this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate
                }
            }
            this.transform.Translate(0f, 0f, -1 * playerSpeed * Time.deltaTime, Space.World); //Translate backward
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.transform.eulerAngles.y != 90)
            {
                if (Mathf.Abs(90 - this.transform.eulerAngles.y) < 5) //Tolerance
                    this.transform.Rotate(0f, 90 - this.transform.eulerAngles.y, 0f, Space.World); //Rotate to become 90
                else if (this.transform.eulerAngles.y < 90 || this.transform.eulerAngles.y > 270)
                {
                    if (this.transform.eulerAngles.y < 90) //Quadrant 1
                        angleToRotate = 90 - this.transform.eulerAngles.y;
                    else //Quadrant 2
                        angleToRotate = 180 - (this.transform.eulerAngles.y - 270);
                    this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate clockwise
                }
                else
                {
                    if (this.transform.eulerAngles.y > 180) //Quadrant 3
                        angleToRotate = 90 + (this.transform.eulerAngles.y - 180);
                    else //Quuadrant 4
                        angleToRotate = 90 - (180 - this.transform.eulerAngles.y);
                    this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
                }
            }
            this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, Space.World); //Translate right
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (this.transform.eulerAngles.y != 270)
            {
                if (Mathf.Abs(270 - this.transform.eulerAngles.y) < 5) //Tolerance
                    this.transform.Rotate(0f, 270 - this.transform.eulerAngles.y, 0f, Space.World); //Rotate to become 270
                else if (this.transform.eulerAngles.y < 90 || this.transform.eulerAngles.y > 270)
                {
                    if (this.transform.eulerAngles.y < 90) //Quadrant 1
                        angleToRotate = 180 - (90 - this.transform.eulerAngles.y);
                    else //Quadrant 2
                        angleToRotate = this.transform.eulerAngles.y - 270;
                    this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
                }
                else
                {
                    if (this.transform.eulerAngles.y > 180) //Quadrant 3
                        angleToRotate = 90 - (this.transform.eulerAngles.y - 180);
                    else //Quadrant 4
                        angleToRotate = 90 + (180 - this.transform.eulerAngles.y);
                    this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Roatate clockwise
                }
            }
            this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, Space.World); //Translate left
        }
    }
}
