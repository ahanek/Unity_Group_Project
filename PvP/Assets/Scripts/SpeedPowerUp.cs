using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float increase = 5f;
    public float duration = 5f;

    //plays power up sound
    //bug: not working
    public AudioSource powerUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Powerup was touched");
            //GameObject player = collision.gameObject;
            StartCoroutine( Pickup(collision));
            powerUpSound.Play();

            
            
        }
    }

    //pick up method
    IEnumerator Pickup(Collider2D player)
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();

        //increases speed    
        playerScript.runSpeed += increase;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        //wait
        yield return new WaitForSeconds(duration);

        //powerup fades away
        playerScript.runSpeed -= increase;
        Destroy(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        powerUpSound = GetComponent<AudioSource>();
        powerUpSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
