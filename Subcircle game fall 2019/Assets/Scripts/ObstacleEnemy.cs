using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEnemy : Enemy
{
   


    // Update is called once per frame
    void Update()
    {
        //shoot();
        //move();
    }

    override
    public void move()
    { 

    }

    override
    public void shoot()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Crashed into player");
        }
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
        }
    }

}
