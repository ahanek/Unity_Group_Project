using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float increase = 5f;

    //plays power up sound
    //bug: not working
    private AudioSource powerUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Powerup was touched");
            GameObject player = collision.gameObject;
            PlayerMovement playerScript = player.GetComponent<PlayerMovement>();

            if (playerScript)
            {
                powerUpSound.Play();
                playerScript.runSpeed += increase;
                Destroy(gameObject);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
