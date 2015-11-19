using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
    public GameObject pauseCanvas;
    public bool isPaused = false;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused){
                isPaused = false;
                Time.timeScale = 1f;
                pauseCanvas.SetActive(false);
            }else {
                isPaused = true;
                Time.timeScale = 0f;
                pauseCanvas.SetActive(true);
            }
        }
	}
}
