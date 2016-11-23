using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    //This script requires a collider.

    [Tooltip("How much health does this object have?")]
    public float health;
    [Tooltip("This is the tag that the projectile needs.")]
    public string projectileTag;
    Animator anim;

    private float currentHealth;
    public bool test;
    int chooseDeath;
    movement pMovement;
    EnemyMovement eMovement;
    KillCount killCounter;
    bool scoreCounted;
    void Start()
    {
        currentHealth = health;
        anim = GetComponent<Animator>();
        if(transform.tag == "Enemy")
        {
            eMovement = GetComponent<EnemyMovement>();
            killCounter = GameObject.Find("GameManager").GetComponent<KillCount>();
        }
        else
        {
            pMovement = GetComponent<movement>();
        }
    }
    void Update()
    {
        if(test)
        {
            WasDestroyed();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == projectileTag)
        {
            TookDamage();
        }
    }

    public void TookDamage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            WasDestroyed();
        }
    }

    public void WasDestroyed()
    {
        if(transform.tag == "Enemy")
        {
            chooseDeath = Random.Range(1, 2);
            eMovement.enabled = false;
            SpawnManager.activeEnemies--;
            if (transform.tag == "Enemy" && !scoreCounted)
            {
                scoreCounted = true;
                killCounter.UpdateScore();
            }
            if (SpawnManager.activeEnemies <= 0)
            {
                SpawnManager.startNextWave = true;
            }
        }
        else
        {
            pMovement.enabled = false;
            chooseDeath = 1;
        }
        anim.SetInteger("Death", chooseDeath);

        Destroy(gameObject,3);
    }
}
