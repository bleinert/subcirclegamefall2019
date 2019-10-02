using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysEnemy : Enemy
{
    public GameObject bulletPrefab;

    public Transform shootPoint; // the position where the bullet will spawn

    private bool isCooldown = false;// whether or not the shooting ability is on cooldown

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot(); 
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

    }

}
