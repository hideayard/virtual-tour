using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public GameObject player;
    public float cameraDistance = 1.5f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        transform.LookAt (player.transform.position);
        transform.position = new Vector3 (transform.position.x, transform.position.y + 0, transform.position.z);
    }

}
