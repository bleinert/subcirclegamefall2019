using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    public PlayerStats playerstats;
    public GameObject bullet;
    public Vector3 launchPoint;
    public Transform trans;
    private GameObject firedbullet;
    Rigidbody2D rb;
    public float speed;
    private float moveHorizontal;
    private float moveVertical;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        playerstats.playerhealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
       
      shoot();  
      Move();

    }

   /* private void FixedUpdate()
    {
        
    }*/

     private void Move()
     {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(moveHorizontal, moveVertical) * speed);
    }
     
    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            firedbullet = Instantiate(bullet, (trans.position + launchPoint), trans.rotation);
            firedbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            playerstats.playerhealth -= 5;
            Debug.Log("Player Health: " + playerstats.playerhealth);

        }
    }
}
