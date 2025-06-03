using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    Animator anim;
    bool moveFlag, backFlag;

    public float turnSpeed = 1, moveSpeed = 1;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        moveFlag = backFlag = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveFlag = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backFlag = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
        }

        anim.SetBool("Move", moveFlag);
        anim.SetBool("Back", backFlag);
    }

    private void LateUpdate()
    {
        if (moveFlag)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        } else if (backFlag)
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }
        moveFlag = backFlag = false;
    }
}
