using UnityEngine;
using System.Collections;

public class NetworkPlayer : MonoBehaviour
{
    public Warrior warrior;
    public Berserker berserker;
    public Archer archer;
    public Caster caster;

    PhotonView pv;
    
	void Start ()
    {
        pv = GetComponent<PhotonView>();
	    if(pv.isMine)
        {
            if(warrior != null)
            {
                warrior.enabled = true;
            }
            if (berserker != null)
            {
                berserker.enabled = true;
            }
            if (archer != null)
            {
                archer.enabled = true;
            }
            if (caster != null)
            {
                caster.enabled = true;
            }
        }
	}
	
	void Update () {
	
	}
}
