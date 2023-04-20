using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;

    [SerializeField]
    float maxPos;

    [SerializeField]
    float moveSpeed;
    bool isLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move() {

        float inputX = Input.GetAxis("Horizontal");
        float inputXPhone = Input.acceleration.x;
        print(inputX);
        transform.position += Vector3.right * inputXPhone * moveSpeed * Time.deltaTime;
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
   
}
