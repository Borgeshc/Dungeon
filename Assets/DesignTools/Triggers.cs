using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{
    public enum TriggerType { None, OnTriggerEnter, OnTriggerExit, OnTriggerStay };
    public enum TriggeredEffect { None, PlayAnimation, Collectables, TakeDamage, Died, LoadNextLevel };

    [HideInInspector, Header("Choose Trigger Type")]
    public TriggerType type;
    [HideInInspector, Header("Choose Trigger Effect")]
    public TriggeredEffect effect;
    
 
    private bool onTriggerEnter;
    private bool onTriggerExit;
    private bool onTriggerStay;

    //TriggeredEffect Variables
    //PlayAnimation Variables
    [HideInInspector, Header("Set Animation Variables"), Tooltip("The Animator that is on the object.")]
    public Animator animatorController;
    [HideInInspector, Tooltip("The name of the Animation Clip you want to play.")]
    public string animationClips;


    //Scene Variables
    [HideInInspector, Tooltip("The name of the next scene you want to load.")]
    public string nextLevel;

    void Update()
    {
        switch(type)
        {
            case TriggerType.None:
                break;
            case TriggerType.OnTriggerEnter:
                onTriggerEnter = true;
                break;
            case TriggerType.OnTriggerExit:
                onTriggerExit = true;
                break;
            case TriggerType.OnTriggerStay:
                onTriggerStay = true;
                break;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(onTriggerEnter)
        {
            //The effect enum goes in here
            switch (effect)
            {
                case TriggeredEffect.None:
                    break;
                case TriggeredEffect.PlayAnimation:
                    PlayAnimation();
                    break;
                case TriggeredEffect.Collectables:
                    Collectable();
                    break;
                case TriggeredEffect.TakeDamage:
                    break;
                case TriggeredEffect.Died:
                    break;
                case TriggeredEffect.LoadNextLevel:
                    break;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(onTriggerExit)
        {
            //The effect enum goes in here
            switch (effect)
            {
                case TriggeredEffect.None:
                    break;
                case TriggeredEffect.PlayAnimation:
                    PlayAnimation();
                    break;
                case TriggeredEffect.Collectables:
                    Collectable();
                    break;
                case TriggeredEffect.TakeDamage:
                    break;
                case TriggeredEffect.Died:
                    break;
                case TriggeredEffect.LoadNextLevel:
                    break;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(onTriggerStay)
        {
            //The effect enum goes in here
            switch (effect)
            {
                case TriggeredEffect.None:
                    break;
                case TriggeredEffect.PlayAnimation:
                    PlayAnimation();
                    break;
                case TriggeredEffect.Collectables:
                    if(other.tag == "Player")
                    {
                        Collectable();
                    }
                    break;
                case TriggeredEffect.TakeDamage:
                    break;
                case TriggeredEffect.Died:
                    break;
                case TriggeredEffect.LoadNextLevel:
                    break;
            }
        }
    }

    void PlayAnimation()
    {
        print("Animation is playing");
        animatorController.Play(animationClips);
    }

    void Collectable()
    {
        Destroy(gameObject);
    }

    void TakeDamage()
    {

    }

    void Died()
    {

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}