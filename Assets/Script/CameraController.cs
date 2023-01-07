using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Versi 1
    public PlayerMovement thePlayer;
    
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    // Start is called before the first frame update
    void Start() {
        thePlayer = FindObjectOfType<PlayerMovement>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update() {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
        
    }

    // Versi 2
    // [SerializeField] private Transform player;

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    // }
}
