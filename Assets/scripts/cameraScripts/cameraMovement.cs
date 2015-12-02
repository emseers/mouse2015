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
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        playerPosition = playerObject.transform.position;
        if (playerPosition.z <= 0) {
            this.transform.position = getPositionByNode(0);
        } else if (playerPosition.z < 10) {
            ratio = playerPosition.z / 10.0f;
            cameraPosition = getPositionByNode(1) - getPositionByNode(0);
            cameraPosition *= ratio;
            cameraRotation = getRotationByNode(1) - getRotationByNode(0);
            cameraRotation *= ratio;
            this.transform.position = getPositionByNode(0) + cameraPosition;
            //this.transform.eulerAngles = getRotationByNode(0) + cameraRotation;
        } else if (playerPosition.z < 25) {
            ratio = (playerPosition.z - 10) / (25.0f - 10);
            cameraPosition = getPositionByNode(2) - getPositionByNode(1);
            cameraPosition *= ratio;
            cameraRotation = getRotationByNode(2) - getRotationByNode(1);
            cameraRotation *= ratio;
            this.transform.position = getPositionByNode(1) + cameraPosition;
            //this.transform.eulerAngles = getRotationByNode(1) + cameraRotation;
        }
    }

    // Returns a vector containing the specified camera node position
    Vector3 getPositionByNode (int nodeNumber) {
        return cameraPath.transform.GetChild(nodeNumber).position;
    }

    // Returns a vector containing the specified camera node rotation
    Vector3 getRotationByNode(int nodeNumber) {
        return cameraPath.transform.GetChild(nodeNumber).eulerAngles;
    }
}
