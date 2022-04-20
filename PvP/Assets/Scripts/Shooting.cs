using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 15f;
    private Rigidbody2D _rigidbody;

    private PlayerMovement _playerPrefs;
    // Start is called before the first frame update
    private float localxSpeed;
    [SerializeField] private float attackDamage = 1f;
    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerPrefs = FindObjectOfType<PlayerMovement>();
        
        //based on the player localscale decide the direction of the bullet. if negative shoot left
        // if postive shoot right
        localxSpeed = _playerPrefs.transform.localScale.x * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(localxSpeed, 0f);
    }

    /*
    //method for when bullet touches player
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
        }
        Destroy(gameObject);
    }
}
