using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
	public GameObject cameraPath = null;
	public GameObject playerPath = null;
	public GameObject playerObject = null;

	//IMPORTANT: Make sure cameraPath and playerPath have same number of children,
	//nodes is calculated assuming above is true
	private int nodes = 0;

	private Vector3 cameraPosition; //A vector to help calculate camera position
	private Vector3 cameraRotation; //A vector to help calculate camera rotation

	private Vector3 playerPosition; //A vector to store player position
	private float ratio; //A variable to store how far in between two nodes the player is

	// Use this for initialization
	void Start() {
		nodes = cameraPath.transform.childCount;
		this.transform.position = getPositionByNode(0); //Set the initial position to the first node (duh)
	}

	// Update is called once per frame
	void Update() {
		playerPosition = playerObject.transform.position;

		//An array to store distances between all possible nodes (to see which one is minimum)
		float[] distances = new float[nodes];

		//A variable to store the minimum distance. Initialize to first distance
		float minDistance = getPositionBetweenNodes(0, 1);

		//A variable to store in which instance the distance was the smallest
		int instance = 0;

		for (int i = 0; i < nodes - 1; i++) {
			distances[i] = getPositionBetweenNodes(i, i + 1); //Set distances for all instances
			if (distances[i] <= minDistance) {
				minDistance = distances[i]; //Store the minimum distance for comparison
				instance = i; //Store the instance where distance is the minimum
			}
		}

		distances[instance] = getPositionBetweenNodes(instance, instance + 1); //Re-run function to store correct ratio;
		
		//Some vector math to set the correct camera position based on ratio
		cameraPosition = getPositionByNode(instance + 1) - getPositionByNode(instance);
		cameraPosition *= ratio;
		this.transform.position = getPositionByNode(instance) + cameraPosition;
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
	float getPositionBetweenNodes(int node1, int node2) {
		//A vector going from node1 to node2
		Vector3 nodeVector = playerPath.transform.GetChild(node2).position - playerPath.transform.GetChild(node1).position;

		//A vector going from node1 to player position
		Vector3 playerVector = playerPosition - playerPath.transform.GetChild (node1).position;
		
		//A vector projection of the player vector projected onto the node vector
		Vector3 projection = Vector3.Project(playerVector, nodeVector);
		
		ratio = projection.magnitude / nodeVector.magnitude; //Calculate ratio with projection
		float distance = (playerVector - projection).magnitude; //Calculate distance with projection
		
		//Base cases if the projection doesn't actually fall on the node vector (if it's too big or in the opposite direction)
		if (ratio > 1) {
			ratio = 1;
			distance = (playerVector - nodeVector).magnitude;
		} else if (nodeVector.normalized != projection.normalized) {
			ratio = 0;
			distance = playerVector.magnitude;
		}

		return distance;
	}
}
