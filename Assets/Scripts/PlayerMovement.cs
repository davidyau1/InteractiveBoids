using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variables
    public float speed = 3f;

    #endregion

    #region methods
    void Movement()
    {
        Vector2 moveDirection = Vector2.zero;

        //movements based on wasd
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;

        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
        }
        moveDirection.Normalize();
        moveDirection *= speed * Time.deltaTime;

        transform.position += (Vector3)moveDirection;


    }
    void Quit()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();

        }

    }

    #endregion



    // Update is called once per frame
    void Update()
    {
        Movement();

        Quit();
    }

    
 
}
