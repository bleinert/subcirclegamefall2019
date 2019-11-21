using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerStats stats;
    public GameObject text;
    
        // Start is called before the first frame update
    void Start()
    {
       stats.playerhealth = 100f;
    

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            stats.playerhealth -= 5;
        
            Debug.Log("Player Health: " + stats.playerhealth);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            stats.playerhealth -= 5;

            Debug.Log("Player Health: " + stats.playerhealth);

        }
    }
}
