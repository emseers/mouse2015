using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	public float playerSpeed = 0f;
	public float playerRotateSpeed = 0f;

	private float playerAngle = 0f;
	private float angleToRotate = 0f;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

		bool rotateClockwise = false;
		bool rotateCounterClockwise = false;

		playerAngle = this.transform.eulerAngles.y;
		if (Input.GetKey(KeyCode.W)) {
			if (playerAngle != 0) {
				if (Mathf.Abs(0 - playerAngle) < 5) //Tolerance
					this.transform.Rotate(0f, 0 - playerAngle, 0f, Space.World); //Rotate to become 0
				else if (Mathf.Abs(360 - playerAngle) < 5) //Tolerance
					this.transform.Rotate(0f, 360 - playerAngle, 0f, Space.World); //Rotate to become 0
				else if (playerAngle > 0 && playerAngle < 180) { //Quadrant 1 and 4
					angleToRotate = playerAngle;
					this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
					rotateCounterClockwise = true;
				} else { //Quadrant 2 and 3
					angleToRotate = 360 - playerAngle;
					this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate clockwise
					rotateClockwise = true;
				}
			}
			this.transform.Translate(0f, 0f, playerSpeed * Time.deltaTime, Space.World); //Translate forward
		} else if (Input.GetKey(KeyCode.S)) {
			if (playerAngle != 180) {
				if (Mathf.Abs(180 - playerAngle) < 5) //Tolerance
					this.transform.Rotate(0f, 180 - playerAngle, 0f, Space.World); //Rotate to become 180
				else { //All quadrants
					angleToRotate = 180 - playerAngle;
					this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate
					if (playerAngle < 180)
						rotateClockwise = true;
					else
						rotateCounterClockwise = true;
				}
			}
			this.transform.Translate(0f, 0f, -1 * playerSpeed * Time.deltaTime, Space.World); //Translate backward
		}

		if (Input.GetKey(KeyCode.D)) {
			if (playerAngle != 90) {
				if (Mathf.Abs(90 - playerAngle) < 5) //Tolerance
					this.transform.Rotate(0f, 90 - playerAngle, 0f, Space.World); //Rotate to become 90
				else if (playerAngle < 90 || playerAngle > 270) {
					if (playerAngle < 90) //Quadrant 1
						angleToRotate = 90 - playerAngle;
					else //Quadrant 2
						angleToRotate = 180 - (playerAngle - 270);
					
					if (!rotateClockwise)
						this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate clockwise
				} else {
					if (playerAngle > 180) //Quadrant 3
						angleToRotate = 90 + (playerAngle - 180);
					else //Quuadrant 4
						angleToRotate = 90 - (180 - playerAngle);
					
					if (!rotateCounterClockwise)
						this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
				}
			}
			this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, Space.World); //Translate right
		} else if (Input.GetKey(KeyCode.A)) {
			if (playerAngle != 270) {
				if (Mathf.Abs(270 - playerAngle) < 5) //Tolerance
					this.transform.Rotate(0f, 270 - playerAngle, 0f, Space.World); //Rotate to become 270
				else if (playerAngle < 90 || playerAngle > 270) {
					if (playerAngle < 90) //Quadrant 1
						angleToRotate = 180 - (90 - playerAngle);
					else //Quadrant 2
						angleToRotate = playerAngle - 270;
					
					if (!rotateCounterClockwise)
						this.transform.Rotate(0f, -1 * angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Rotate counterclockwise
				} else {
					if (playerAngle > 180) //Quadrant 3
						angleToRotate = 90 - (playerAngle - 180);
					else //Quadrant 4
						angleToRotate = 90 + (180 - playerAngle);
					
					if (!rotateClockwise)
						this.transform.Rotate(0f, angleToRotate * Time.deltaTime / playerRotateSpeed, 0f, Space.World); //Roatate clockwise
				}
			}
			this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, Space.World); //Translate left
		}
	}
}
