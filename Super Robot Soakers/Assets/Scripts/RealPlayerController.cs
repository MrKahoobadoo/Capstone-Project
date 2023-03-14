using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RealPlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public Camera mainCamera;
    public GameObject hamsterModel;

    public PlayerWeaponScript playerWeaponScript;
    
    public AudioSource audioSource;
    public AudioClip audioClip;
    
    public AudioSource audioSource2;
    public AudioClip audioClip2;
    
    public AudioSource audioSource3;

    public UIScriptGameOver gameOverText;


    public float moveSpeed;
    public float jumpForce;

    public float initialFOV;
    public float finalFOV;
    public float fovChange;

    public float hamsterLeftAngle;
    public float hamsterRightAngle;
    public float hamsterLerpDuration;
    private float elapsedTime;

    private bool isGrounded;
    private bool isMoving;
    private bool isRunning;

    //important
    public bool isSilly = true;
    //importamt

    public int score;

    /*void Awake()
    {
        playerWeaponScript = GetComponent<PlayerWeaponScript>();
    }*/

    void move()
    {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            x *= 2;
            z *= 2;
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
         
        //Debug.Log(z + ", " + x);
        if(isGrounded)
        {
            if (x != 0 || z != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            
            rig.velocity = transform.forward * z + transform.right * x + new Vector3(0, rig.velocity.y, 0);
        }
        else
        {
            x /= 2;
            z /= 2;
            
            if (x != 0 || z != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            rig.velocity = transform.forward * z + transform.right * x + new Vector3(0, rig.velocity.y, 0);
        }
    }

    void fovChanger()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            mainCamera.fieldOfView = Mathf.MoveTowards(mainCamera.fieldOfView, finalFOV, fovChange * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.MoveTowards(mainCamera.fieldOfView, initialFOV, fovChange * Time.deltaTime);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            audioSource2.Play();
        }
    }

    void FireWeapon()
    {
        if (Input.GetMouseButton(0))
        {
            if (playerWeaponScript.CanShoot() == true)
            {
                
                playerWeaponScript.Shoot();
            }
        }
    }

    void wobbler()
    {
        if (isRunning)
        {
            hamsterLerpDuration /= 2;
        }

        if (isMoving && isGrounded)
        {
            
            elapsedTime += Time.deltaTime;
            float t = Mathf.PingPong(elapsedTime / hamsterLerpDuration, 1.0f);
            float currentValue = Mathf.Lerp(hamsterLeftAngle, hamsterRightAngle, t);

            hamsterModel.transform.localRotation = Quaternion.Euler(0, 0, currentValue);

        }
        else
        {
            hamsterModel.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(hamsterModel.transform.localRotation.z, 0, 1));
        }

        if (isRunning)
        {
            hamsterLerpDuration *= 2;
        }

    }

    void audioPlayer()
    {
        if (isMoving && isGrounded)
        {
            audioSource.volume = 0.5f;
        }
        else
        {
            audioSource.volume = 0f;
        }

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameOverText.gameIsOver = true;
        Invoke("ReloadScene", 3f);
    }

    public void AddScore(int amount)
    {
        score += amount;
        audioSource3.Play();
        //update score text UI
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        fovChanger();
        wobbler();
        audioPlayer();
        FireWeapon();
        
        
        if(transform.position.y < -5)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
}
