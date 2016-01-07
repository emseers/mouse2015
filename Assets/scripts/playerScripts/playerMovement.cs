using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	public GameObject camera = null;
	public float playerSpeed = 0f;
	public float playerRotateSpeed = 0f;

	private float playerAngleX = 0f;
	private float playerAngleY = 0f;
	private float playerAngleZ = 0f;

	private float cameraAngleY = 0f;
	private float newPLayerAngleY = 0f;
	private float deltaAngle = 0f;

	private Transform cameraAxis = null;

	// Use this for initialization
	void Start() {
		playerAngleX = this.transform.eulerAngles.x;
		playerAngleZ = this.transform.eulerAngles.z;
	}

	// Update is called once per frame
	void Update() {
		cameraAngleY = camera.transform.eulerAngles.y;
		playerAngleY = this.transform.eulerAngles.y;

		//Create another axis to be used with transforming player object that doesn't take into account camera rotation in x and z
		cameraAxis = new GameObject().transform;
		cameraAxis.eulerAngles = new Vector3(playerAngleX, cameraAngleY, playerAngleZ);

		//Movement is based relative to the camera
		if (Input.GetKey(KeyCode.W)) {
			if (Input.GetKey(KeyCode.A)) {
				transformNorthWest();
			} else if (Input.GetKey(KeyCode.D)) {
				transformNorthEast();
			} else {
				transformNorth();
			}
		} else if (Input.GetKey(KeyCode.S)) {
			if (Input.GetKey(KeyCode.A)) {
				transformSouthWest();
			} else if (Input.GetKey(KeyCode.D)) {
				transformSouthEast();
			} else {
				transformSouth();
			}
		} else if (Input.GetKey(KeyCode.A)) {
			transformWest();
		} else if (Input.GetKey(KeyCode.D)) {
			transformEast();
		}
	}

	void transformNorth() {
		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, playerSpeed * Time.deltaTime, cameraAxis); //Translate forward
	}

	void transformNorthEast() {
		cameraAngleY += 45;
		if (cameraAngleY >= 360)
			cameraAngleY -= 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, playerSpeed * Time.deltaTime, cameraAxis); //Translate forward
		this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate right
	}

	void transformEast() {
		cameraAngleY += 90;
		if (cameraAngleY >= 360)
			cameraAngleY -= 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate right
	}

	void transformSouthEast() {
		cameraAngleY += 135;
		if (cameraAngleY >= 360)
			cameraAngleY -= 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, -1 * playerSpeed * Time.deltaTime, cameraAxis); //Translate backward
		this.transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate right
	}

	void transformSouth() {
		cameraAngleY += 180;
		if (cameraAngleY >= 360)
			cameraAngleY -= 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, -1 * playerSpeed * Time.deltaTime, cameraAxis); //Translate backward
	}

	void transformSouthWest() {
		cameraAngleY -= 135;
		if (cameraAngleY < 0)
			cameraAngleY += 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, -1 * playerSpeed * Time.deltaTime, cameraAxis); //Translate backward
		this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate left
	}

	void transformWest() {
		cameraAngleY -= 90;
		if (cameraAngleY < 0)
			cameraAngleY += 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate left
	}

	void transformNorthWest() {
		cameraAngleY -= 45;
		if (cameraAngleY < 0)
			cameraAngleY += 360;

		deltaAngle = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

		if (!Mathf.Approximately(deltaAngle, 0f)) {
			newPLayerAngleY = Mathf.MoveTowardsAngle(playerAngleY, cameraAngleY, playerRotateSpeed * Time.deltaTime);
			this.transform.eulerAngles = new Vector3(playerAngleX, newPLayerAngleY, playerAngleZ);
		}

		this.transform.Translate(0f, 0f, playerSpeed * Time.deltaTime, cameraAxis); //Translate forward
		this.transform.Translate(-1 * playerSpeed * Time.deltaTime, 0f, 0f, cameraAxis); //Translate left
	}
}
