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

    public List<Transform> pathNodes = new List<Transform>();
    private int nodeIndex = 0;
    private bool isReversePath = false; // whether the ai should move in the opposite direction of the pathway

    // Start is called before the first frame update
    void Start()
    {
        health =100; 
    }

    // Update is called once per frame
    void Update()
    {
        //shoot();
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
            //Debug.Log("Shoot2");
            isCooldown = true;
            GameObject projectile = GameObject.Instantiate(bulletPrefab); // spawn the bullet
            

            projectile.transform.position = shootPoint.position; // set location of made bullet 
                                                                 //to shootpoint location
            //Debug.Log(shootPoint.position);
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

        if (pathNodes != null) // if there is a path to follow, do the following: 
        {
            
            if (Vector2.Distance(this.transform.position, pathNodes[nodeIndex].position) < 1f) // if the enemy's position reaches the first node
                                                                             // in the pathway, start following the next node
                                                                             //Only compare x and y coords and not z coords
            {
                
                if (isReversePath)  // this block segment gets the AI's next path to follow in reverse order
                {
                    if (nodeIndex > 0)
                    {
                        nodeIndex--; // get next node if enemy has not reach end of its path
                    }
                    else //  if it reaches the end of its path, make the enemy start moving the other way
                    {
                        isReversePath = false;
                        nodeIndex++;
                    }
                }


                else // this block segment gets the AI's next path to follow in non reverse order
                {
                    if (nodeIndex < pathNodes.Count-1)
                    {
                        nodeIndex++; // get next node if enemy has not reach end of its path
                    }

                    else //  if it reaches the end of its path, make the enemy start moving the other way
                    {
                        isReversePath = true;
                        nodeIndex--;
                    }
                }

                Debug.Log(nodeIndex);

            }
            else // if enemy has not reach its next node in the path, make it move a step closer to that node
            {
               
               
                this.transform.position += new Vector3 ((pathNodes[nodeIndex].position.x - this.transform.position.x > 0) ?
                    Time.deltaTime : (Time.deltaTime * -1),0,0 );

                this.transform.position += new Vector3(0,(pathNodes[nodeIndex].position.y - this.transform.position.y > 0) ?
                    Time.deltaTime : (Time.deltaTime * -1), 0);
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
