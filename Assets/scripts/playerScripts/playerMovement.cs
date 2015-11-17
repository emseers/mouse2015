using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
	public float playerSpeed = 0f;
	public float playerRotateSpeed = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
			this.transform.Translate(0f, 0f,  playerSpeed * Time.deltaTime, Space.Self);
		else if(Input.GetKey(KeyCode.S))
	        this.transform.Translate(0f, 0f,  -1 * playerSpeed * Time.deltaTime, Space.Self);

		if (Input.GetKey (KeyCode.D))
			this.transform.Rotate (0f, playerRotateSpeed * Time.deltaTime, 0f, Space.World);
		else if (Input.GetKey (KeyCode.A))
			this.transform.Rotate (0f, -1 * playerRotateSpeed * Time.deltaTime, 0f, Space.World);

	}
}
