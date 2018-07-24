using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrepare : MonoBehaviour {

    public Transform playerTransform;
    private GameObject player;
    private string playerName;
    public CameraController cameraController;
    public OcclusionController occlusionController;

	// Use this for initialization
	void Start () {
        playerName = PlayerPrefs.GetString("PlayerName");
        player = (GameObject)Resources.Load("Prefabs/"+ playerName);
        player = Instantiate(player);
        player.transform.parent = playerTransform;
        cameraController.enabled = true;
        occlusionController.enabled = true;

    }
}
