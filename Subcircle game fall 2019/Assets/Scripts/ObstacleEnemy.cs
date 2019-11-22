using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEnemy : Enemy
{

    public AudioClip EnemySound;

    // Update is called once per frame
    void Update()
    {
        //shoot();
        move();
    }

    override
    public void move()
    {
        this.GetComponentInParent<Transform>().position += new Vector3(0,  -speed * Time.deltaTime, 0);
    } 

    override
    public void shoot()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("PlayerBullet"))
        {
            loseHealth(5);
            Debug.Log("Sideways Enemy Health: " + health);

        }
    }
    override
    public void loseHealth(float value)
    {
        health = health - value;
        if (health <= 0)
        {
            Debug.Log("Sideways Enemy Died");
            //health = 0;
            Destroy(this.gameObject); // destroy this gameobject enemy if health is 0 or below
            AudioManager.Instance.PlayAudio(EnemySound); // make death noise
        }
    }

   

}
