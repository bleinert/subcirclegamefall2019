using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Enemy
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
        this.GetComponentInParent<Transform>().position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    override
    public void shoot()
    {

    }


   
    override
    public void loseHealth(float value)
    {
       
    }



}
