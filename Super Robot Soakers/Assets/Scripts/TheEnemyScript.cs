using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class TheEnemyScript : MonoBehaviour
{
    [Header("Stats")]
    public int curHp;
    public int maxHp;
    public int scoreToGive;

    [Header("Movement")]
    //public float moveSpeed;
    //public float tempMoveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;

    public EnemyWeaponScript weaponScript;
    private GameObject target;
    private GameObject gameManager;

    void Start()
    {
        //tempMoveSpeed = 0;
        InvokeRepeating("UpdatePath", 0.0f, 0.25f);
        target = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("Game Manager");
    }
    
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange)
        {
            if (weaponScript.CanShoot())
            {
                weaponScript.Shoot();
            }
        }
        else
        {
            ChaseTarget();
        }

        // look at the target
        transform.LookAt(target.transform.position + new Vector3(0, 1, 0));

        FallChecker();
        
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
        {
            return;
        }
        
        // move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), gameManager.GetComponent<GameManager>().moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
        {
            path.RemoveAt(0);
        }
    }

    void UpdatePath()
    {
        // calculate a path to the target

        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        // save that as a list
        path = navMeshPath.corners.ToList();
          
    }

    public void TakeDamage (int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
        {
            Die();
        }
    }

    void FallChecker()
    {
        if(transform.position.y < -5)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        target.GetComponent<RealPlayerController>().AddScore(1);
        gameManager.GetComponent<GameManager>().enemiesEliminated++;
    }
}
