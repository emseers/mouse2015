using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	public float playerSpeed = 0f;
	public float playerRotateSpeed = 0f;
    public float angleToRotate = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
			this.transform.Translate(0f, 0f,  playerSpeed * Time.deltaTime, Space.Self);
		else if (Input.GetKey(KeyCode.S))
	        this.transform.Translate(0f, 0f,  -1 * playerSpeed * Time.deltaTime, Space.Self);

		if (Input.GetKey(KeyCode.D)) {
			if (this.transform.eulerAngles.y != 90) {
				if (this.transform.eulerAngles.y < 90 || this.transform.eulerAngles.y > 270) {
                    if (this.transform.eulerAngles.y < 90)
                        angleToRotate = 90 - this.transform.eulerAngles.y;
                    else
                        angleToRotate = 180 - (this.transform.eulerAngles.y - 270);
					this.transform.Rotate(0f, angleToRotate / playerRotateSpeed, 0f, Space.World);
                }
                else {
                    if (this.transform.eulerAngles.y < 180)
                        angleToRotate = 90 - (180 - this.transform.eulerAngles.y);
                    else
                        angleToRotate = 90 + (this.transform.eulerAngles.y - 180);
                    this.transform.Rotate(0f, -1 * angleToRotate / playerRotateSpeed, 0f, Space.World);
                }
			}
			this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, Space.World);
		} else if (Input.GetKey(KeyCode.A)) {
			if (this.transform.eulerAngles.y != 270) {
                if (this.transform.eulerAngles.y < 90 || this.transform.eulerAngles.y > 270)
                {
                    if (this.transform.eulerAngles.y < 90)
                        angleToRotate = 180 - (90 - this.transform.eulerAngles.y);
                    else
                        angleToRotate = this.transform.eulerAngles.y - 270;
                    this.transform.Rotate(0f, -1 * angleToRotate / playerRotateSpeed, 0f, Space.World);
                }
                else
                {
                    if (this.transform.eulerAngles.y < 180)
                        angleToRotate = 90 + (180 - this.transform.eulerAngles.y);
                    else
                        angleToRotate = 90 - (this.transform.eulerAngles.y - 180);
                    this.transform.Rotate(0f, angleToRotate / playerRotateSpeed, 0f, Space.World);
                }
			}
			this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, Space.World);
		}
	}
}
