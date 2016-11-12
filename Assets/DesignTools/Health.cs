using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    //This script requires a collider.

    [Tooltip("How much health does this object have?")]
    public float health;
    [Tooltip("This is the tag that the projectile needs.")]
    public string projectileTag;
    public Animator anim;

    private float currentHealth;
    public bool test;

    void Start()
    {
        currentHealth = health;
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
            Destroy(other.gameObject);
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
            SpawnManager.activeEnemies--;
            if(SpawnManager.activeEnemies <= 0)
            {
                SpawnManager.startNextWave = true;
            }
        }
        anim.SetBool("died", true);

        Destroy(gameObject,3);
    }
}
