using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public bool won;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (won == false)
        {
            transform.position = new Vector3(player.position.x + 0.8f, 0, -10);
        }
    }
}
