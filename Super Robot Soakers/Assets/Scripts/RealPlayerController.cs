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

    public GameObject actualHamsterModel;
    public GameObject weaponModel;

    public Transform player;

    public LayerMask layerMask;
    public string excludedTag;


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

    public int curHp;
    public int maxHp;

    //important
    public bool isSilly = true;
    //importamt

    public int score;

    public Vector3 pointOfFocus;
    public bool focusPresent;

   

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

    public void TakeDamage (int damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //DisableRenderersExceptCamera();
        gameOverText.gameIsOver = true;
        Invoke("ReloadScene", 3f);
    }

    void FocusThePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100);

        // Declare a variable to store the raycast hit information
        RaycastHit hit;

        // Perform the raycast and check if it hit an object
        if (Physics.Raycast(ray, out hit))
        {   
            if(hit.distance < 100)
            {
                focusPresent = true;
                // Get the transform point of the hit
                pointOfFocus = hit.point;
            }
            else
            {
                focusPresent = false;
            }
            
            // Do something with the hit point
            Debug.Log("Hit point: " + pointOfFocus);
        }
        else
        {
            focusPresent = false;
        }
    }

    /*void DisableRenderersExceptCamera()
    {
        foreach (Transform child in player)
        {
            if (child.CompareTag("MainCamera"))
            {
                continue; // Skip the camera object
            }
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // Disable the renderer of the child object
            }
        }
    }*/

        // Update is called once per frame
        void Update()
    {
        move();
        jump();
        fovChanger();
        wobbler();
        audioPlayer();
        FireWeapon();
        FocusThePoint();
        
        
        if(transform.position.y < -5)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ReloadWater(int waterAmount)
    {
        playerWeaponScript.curAmmo = Mathf.Clamp(playerWeaponScript.curAmmo + waterAmount, 0, playerWeaponScript.maxAmmo);
    }

    public void GiveHealth(int healthAmount)
    {
        curHp = Mathf.Clamp(curHp + healthAmount, 0, maxHp);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
}