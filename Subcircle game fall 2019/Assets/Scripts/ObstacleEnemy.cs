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

    override
    public void loseHealth(float value)
    {
        health = health - value;
        if (health <= 0)
        {
            //health = 0;
            Destroy(this.gameObject); // destroy this gameobject enemy if health is 0 or below
        }
    }

}
