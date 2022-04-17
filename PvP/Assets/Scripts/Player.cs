using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        if (go.tag == "SpeedBoost")
        {
            //if player touches speed boost...
            AbsorbPowerUp(go);
        }
        else
        {
            print("not triggered by power-up: " + go.name);
        }
    }
    public void AbsorbPowerUp(GameObject go)
    {
        PowerUp pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            // Leave this switch block empty for now.
        }
        pu.AbsorbedBy(this.gameObject);
    }*/

}
