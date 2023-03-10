using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlingBall : MonoBehaviour
{
    public float leftConstraint;
    public float rightConstraint;
    public float forwardForce;
    public float moveIncrement;
    public Rigidbody rig;
    float startingPosition = 16.0f;

    void Start()
    {

    }

    public void Bowl()
    {
        //if(transform.position.x == startingPosition)
        //{
            rig.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        //}
        
    }

    public void MoveLeft()
    {
        if(transform.position.z > leftConstraint)
        {
            transform.position += new Vector3(0, 0, -moveIncrement);
        }
        
    }

    public void MoveRight()
    {
        if (transform.position.z < rightConstraint)
        {
            transform.position += new Vector3(0, 0, moveIncrement);
        }

    }

    void ResetGame()
    {
        if(transform.position.x < -100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Bowl();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        ResetGame();
    }

}
