using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {
    public GameObject cameraPath = null;
    public GameObject playerObject = null;
    public int currentNode = 0;

    public float testSpeed = 0f;
    private Vector3 nextNodeV;
    private Vector3 nodeRail;
    private float testMove = 0f;

    private Vector3 testV;

	// Use this for initialization
	void Start () {
        nextNodeV = getNodeV(currentNode + 1);
        nodeRail = nextNodeV - getNodeV(currentNode);

        testV = transform.position;

        
        //Debug.Log(testV + " ========================== " + nextNodeV);
        //for(int derp = 0; derp < cameraPath.transform.childCount; derp++)
        //    Debug.Log(derp + " NODE: " + cameraPath.transform.GetChild(derp) + " ===>  " + cameraPath.transform.GetChild(derp).position);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(testV, nextNodeV, 0.9f);
        //TODO: Fancy movement along "spline" in sync to player position or w/e
        /*
        
        */


    }

    Vector3 getNodeV(int nodeNumber) {
        //Vector3 herp = cameraPath.transform.GetChild(nodeNumber).position;
        //Debug.Log(herp);
        //return herp;
        return cameraPath.transform.GetChild(nodeNumber).position;
    }
}
