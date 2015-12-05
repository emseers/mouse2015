using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
	public GameObject cameraPath = null;
	public GameObject playerPath = null;
	public GameObject playerObject = null;
	public int currentNode = 0;
	public float testSpeed = 0f;

	private Vector3 cameraPosition;
	private Vector3 cameraRotation;
	private float testMove = 0f;

	private Vector3 playerPosition;
	private float ratio;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		playerPosition = playerObject.transform.position;
		float[] distances = new float[3];
		float minDistance = getPositionBetweenNodes(1, 2); //Initialize minimum to first distance
		int instance = 0; //Variable to store which instance the player is closest to
		for (int i = 0; i < 2; i++) {
			distances[i] = getPositionBetweenNodes(i, i + 1); //Set distances for all instances
			if (distances[i] <= minDistance) {
				minDistance = distances[i]; //Store the minimum distance for comparison
				instance = i; //Store the instance where distance is the minimum
			}
		}

		distances[instance] = getPositionBetweenNodes(instance, instance + 1); //Re-run function to store correct ratio;
		cameraPosition = getPositionByNode(instance + 1) - getPositionByNode(instance);
		cameraPosition *= ratio;
		this.transform.position = getPositionByNode(instance) + cameraPosition;
		//if (playerPosition.z <= 0) {
		//	this.transform.position = getPositionByNode(0);
		//} else if (playerPosition.z < 10) {
		//	ratio = playerPosition.z / 10.0f;
		//	cameraPosition = getPositionByNode(1) - getPositionByNode(0);
		//	cameraPosition *= ratio;
		//	cameraRotation = getRotationByNode(1) - getRotationByNode(0);
		//	cameraRotation *= ratio;
		//	this.transform.position = getPositionByNode(0) + cameraPosition;
		//	//this.transform.eulerAngles = getRotationByNode(0) + cameraRotation;
		//} else if (playerPosition.z < 25) {
		//	ratio = (playerPosition.z - 10) / (25.0f - 10);
		//	cameraPosition = getPositionByNode(2) - getPositionByNode(1);
		//	cameraPosition *= ratio;
		//	cameraRotation = getRotationByNode(2) - getRotationByNode(1);
		//	cameraRotation *= ratio;
		//	this.transform.position = getPositionByNode(1) + cameraPosition;
		//	//this.transform.eulerAngles = getRotationByNode(1) + cameraRotation;
		//}
	}

	// Returns a vector containing the specified camera node position
	Vector3 getPositionByNode(int nodeNumber) {
		return cameraPath.transform.GetChild(nodeNumber).position;
	}

	// Returns a vector containing the specified camera node rotation
	Vector3 getRotationByNode(int nodeNumber) {
		return cameraPath.transform.GetChild(nodeNumber).eulerAngles;
	}

	//Sets the ratio to a number between 0 and 1 on how far along the player is between two specified player nodes
	//and returns the distance from the player to the line connecting the two nodes
	float getPositionBetweenNodes(int node1, int node2) {
		Vector3 nodeVector = new Vector3(playerPath.transform.GetChild(node2).transform.position.x -
										playerPath.transform.GetChild(node1).transform.position.x,
										playerPath.transform.GetChild(node2).transform.position.y -
										playerPath.transform.GetChild(node1).transform.position.y,
										playerPath.transform.GetChild(node2).transform.position.z -
										playerPath.transform.GetChild(node1).transform.position.z);
		Vector3 playerVector = new Vector3(playerPosition.x - playerPath.transform.GetChild(node1).transform.position.x,
										playerPosition.y - playerPath.transform.GetChild(node1).transform.position.y,
										playerPosition.z - playerPath.transform.GetChild(node1).transform.position.z);
		Vector3 projection = Vector3.Project(playerVector, nodeVector);
		ratio = projection.magnitude / nodeVector.magnitude;
		float distance = (playerVector - projection).magnitude;
		if (ratio > 1)
			ratio = 1;
		else if (nodeVector.normalized != projection.normalized)
			ratio = 0;
		return distance;
	}
}
