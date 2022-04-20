using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public AudioSource powerUpSound;

    public float delay = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Bullet was touched");
            GameObject player = collision.gameObject;
            PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
            if (playerScript.bulletCount < 3)
            {
                playerScript.bulletCount++;
                powerUpSound.Play();
                playerScript.startTimer();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
