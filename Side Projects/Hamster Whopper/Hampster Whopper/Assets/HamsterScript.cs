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

    public LoseText loseText;
    public GameObject hampsterObject;
    public Transform hampsterTransform;
    private float count = 0;

    public AudioSource audioSource;

    public AudioClip audioClip;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");

        rig.AddForce(Vector3.right * xInput * moveForce);

        float yInput = Input.GetAxis("Vertical");

        rig.AddForce(Vector3.forward * yInput * runningSpeed);
        
        if (count > 22 && loseText.gameOver)
        {
            count = 0;
            Vector3 spreadVector = Quaternion.Euler((Random.Range(-100, 100)), (Random.Range(-100, 100)), 0f) * hampsterTransform.forward;
            GameObject newObject = Instantiate(hampsterObject, hampsterTransform.position, hampsterTransform.rotation);
            Rigidbody projectileRb = newObject.GetComponent<Rigidbody>();
            projectileRb.AddForce(spreadVector, ForceMode.Impulse);
            audioSource.Play();

        }
        count += 1;


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
