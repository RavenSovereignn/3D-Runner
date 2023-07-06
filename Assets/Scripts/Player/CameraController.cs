using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPos = new Vector3(transform.position.x, transform.position.y, camOffset.z + player.position.z);
        transform.position = newPos;
    }
}
