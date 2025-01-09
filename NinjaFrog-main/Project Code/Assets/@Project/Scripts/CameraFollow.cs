using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private float minX = 0, maxX = 55;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 vitri = transform.position;
            vitri.x = player.position.x;
            if (vitri.x < minX) vitri.x = 0;
            if (vitri.x > maxX) vitri.x = maxX;
            transform.position = vitri;
        }
    }
}
