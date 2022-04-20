using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    PhotonView PV;

    GameObject controller;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if(PV.IsMine)//if own by the local player
        {
            CreateController();
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate("PlayerController", new Vector2(-11f, 20f),
            quaternion.identity);        
        //PhotonNetwork.Instantiate("PlayerController", new Vector2(Random.Range(-18f, 11f), Random.Range(3f, 24f)),
          //  quaternion.identity);
        // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
        //  Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        // controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        CreateController();
    }
}