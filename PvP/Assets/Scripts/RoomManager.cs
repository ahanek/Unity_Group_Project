using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1) // We're in the game scene
        {
            
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), transform.position, Quaternion.identity);
            // PhotonNetwork.Instantiate("PlayerController", new Vector2(Random.Range(-18f, 11f), transform.position.y),
            //     quaternion.identity);           
            // PhotonNetwork.Instantiate("PlayerController", new Vector2(Random.Range(-18f, 11f), transform.position.y),
            //     quaternion.identity);
            
            PhotonNetwork.Instantiate("PlayerController", new Vector2(-11f, 20f),
                quaternion.identity); 

            //-18 - 8

        }
    }
} 