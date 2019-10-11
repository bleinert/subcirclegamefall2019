using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysEnemy : Enemy
{
    public GameObject bulletPrefab;

    public Transform shootPoint; // the position where the bullet will spawn

    public float xLeftBoundry; // enity cannot move left past this x coord
    public float xRightBoundry; // enity cannot move right past this x coord

    private bool isCooldown = false;// whether or not the shooting ability is on cooldown

    // Start is called before the first frame update
    void Start()
    {
        health =100; 
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
       // Debug.Log(!isCooldown);
        if (!isCooldown) // only shoot when there is no cooldown
        {
            Debug.Log("Shoot2");
            isCooldown = true;
            GameObject projectile = GameObject.Instantiate(bulletPrefab); // spawn the bullet
            

            projectile.transform.position = shootPoint.position; // set location of made bullet 
                                                                 //to shootpoint location
            Debug.Log(shootPoint.position);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed); // give the bullet speed

            Invoke("ResetShootCooldown", 2f); // reset the shoot cooldown after some time
        }
    }



    override
    public  void move()
    {
     
        // this.transform.position = new Vector3(Mathf.PingPong
        //  (Time.time * 2, xRightBoundry - xLeftBoundry) + xLeftBoundry,
        //  this.transform.position.y, this. transform.position.z);

        if (this.transform.position.x > xRightBoundry && speed > 0) //if enemy is moving right and past the 
                                                                    // right boundry
        {
            speed *= -1;// change its moving direction to left
        }

        if (this.transform.position.x < xLeftBoundry && speed < 0)//if enemy is moving left and past the 
                                                                  // left boundry
        {
            speed *= -1; // change its moving direction to right
        }

        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0); // move enemy based on speed

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
            Debug.Log("Sideways Enemy Health: "+ health);

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
