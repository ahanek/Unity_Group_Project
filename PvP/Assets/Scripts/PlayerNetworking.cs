using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerNetworking : MonoBehaviour
{
    public MonoBehaviour[] scriptToIgnore;

    private PhotonView _photonView;
    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            foreach (var script in scriptToIgnore)
            {
                script.enabled = false;
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        _photonView = GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            foreach (var script in scriptToIgnore)
            {
                script.enabled = false;
            }
        }
    }
}
