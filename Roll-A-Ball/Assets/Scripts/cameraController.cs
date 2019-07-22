using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;   
    }

    // Runs after all other updates have been performed. Ensures we get final player position
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
