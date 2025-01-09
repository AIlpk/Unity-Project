using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dichuyen : MonoBehaviour
{
    public float speed=5;
    public float maxX = 7.5f;
    float chuyendong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        chuyendong = Input.GetAxis("Horizontal");
        if((chuyendong>0 && transform.position.x<maxX) || chuyendong<0 && transform.position.x> -maxX)
        {
            transform.position += Vector3.right*chuyendong*speed*Time.deltaTime;
        }
    }
}
