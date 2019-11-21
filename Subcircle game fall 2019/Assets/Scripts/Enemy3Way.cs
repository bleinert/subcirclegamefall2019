﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Way : Enemy
{
    public GameObject bulletPrefab;

    public Transform shootPoint; // the position where the bullet will spawn



    private bool isCooldown = false;// whether or not the shooting ability is on cooldown

    public List<Transform> pathNodes = new List<Transform>();
    private int nodeIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
        move();

    }



    public void ResetShootCooldown()
    {
        isCooldown = false;
    }

    override
    public void shoot() // shoots a bullet with some force
    {

        if (!isCooldown) // only shoot when there is no cooldown
        {
            //Debug.Log("Shoot2");
            isCooldown = true;
            GameObject projectile = GameObject.Instantiate(bulletPrefab); // spawn the bullet
            GameObject projectile2 = GameObject.Instantiate(bulletPrefab); // spawn the bullet
            GameObject projectile3 = GameObject.Instantiate(bulletPrefab); // spawn the bullet

            projectile2.transform.position = shootPoint.position;
            projectile3.transform.position = shootPoint.position;
            projectile.transform.position = shootPoint.position; // set location of made bullet 
                                                                 //to shootpoint location
                                                                 //Debug.Log(shootPoint.position);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed); // give the bullet speed
            projectile2.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed *.5f, -bulletSpeed *.5f);
            projectile3.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed * .5f, -bulletSpeed * .5f);

            Invoke("ResetShootCooldown", 2f); // reset the shoot cooldown after some time
        }
    }



    override
    public void move()
    {

        // this.transform.position = new Vector3(Mathf.PingPong
        //  (Time.time * 2, xRightBoundry - xLeftBoundry) + xLeftBoundry,
        //  this.transform.position.y, this. transform.position.z);

        if (pathNodes.Count > 0) // if there is a path to follow, do the following: 
        {

            if (Vector2.Distance(this.transform.position, pathNodes[nodeIndex].position) < 1f) // if the enemy's position reaches the first node
                                                                                               // in the pathway, start following the next node
                                                                                               //Only compare x and y coords and not z coords
            {


                if (nodeIndex < pathNodes.Count - 1)
                {
                    nodeIndex++; // get next node if enemy has not reach end of its path
                }

                else //  if it reaches the end of its path, go back to first node
                {

                    nodeIndex = 0;
                }


                // Debug.Log(nodeIndex);

            }
            else // if enemy has not reach its next node in the path, make it move a step closer to that node
            {



                Vector3 vDirection = new Vector3(pathNodes[nodeIndex].position.x - this.transform.position.x,
                   pathNodes[nodeIndex].position.y - this.transform.position.y, 0); // calculate direction vector

                vDirection = vDirection.normalized;

                this.transform.position = transform.position + (speed * Time.deltaTime * vDirection); //move enemy towards that 
                                                                                                      // direction with given speed

            }
        }



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