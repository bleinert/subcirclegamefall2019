using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerStats stats; 
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
}
