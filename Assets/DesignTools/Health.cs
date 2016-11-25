using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //This script requires a collider.

    [Tooltip("How much health does this object have?")]
    public float health;
    [Tooltip("This is the tag that the projectile needs.")]
    public string projectileTag;
    Animator anim;

    private float currentHealth;
    int chooseDeath;
    movement pMovement;
    EnemyMovement eMovement;
    KillCount killCounter;
    bool scoreCounted;
    bool beingDamaged;
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
    }
    void OnTriggerEnter(Collider other)
    {
        TookDamage(other.gameObject);
    }

    public void TookDamage(GameObject projectile)
    {
        if (!beingDamaged)
        {
            beingDamaged = true;
                switch (projectile.tag)
                {
                    case "EnemyWeapon":
                        if(transform.tag == "Player")
                        {
                            currentHealth--;
                        }
                        break;
                    case "Sword":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 2.5f;
                    }
                        break;
                    case "Axe":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 5;
                    }
                        break;
                    case "Arrow":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 3.5f;
                    }
                        break;
                    case "Fireball":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 5;
                    }
                        break;
                    case "Meteors":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 3;
                    }
                        break;
                case "Rune":
                    if (transform.tag == "Enemy")
                    {
                        currentHealth -= 10;
                    }
                    break;
            }
            
            beingDamaged = false;
        }
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

            anim.SetInteger("Death", chooseDeath);
            Destroy(gameObject, 3);
        }
        else
        {
            pMovement.enabled = false;

            chooseDeath = 1;

            anim.SetInteger("Death", chooseDeath);

            SceneManager.LoadScene("MainMenu");
        }
    }
}
