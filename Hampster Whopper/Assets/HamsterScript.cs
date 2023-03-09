using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterScript : MonoBehaviour
{
    public float moveForce;

    public float runningSpeed;

    public Rigidbody rig;

    public bool gameWon = false;

    public bool gameLose = false;

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");

        rig.AddForce(Vector3.right * xInput * moveForce);

        float yInput = Input.GetAxis("Vertical");

        rig.AddForce(Vector3.forward * yInput * runningSpeed);
    }

    void gameWin()
    {
        if(transform.position.z > 500)
        {
            gameWon = true;
        }
    }

    void gameLost()
    {
        if(transform.position.y < -1000)
        {
            gameLose = true;
        }
    }

    void Update()
    {
        gameWin();
        gameLost();
    }
}
