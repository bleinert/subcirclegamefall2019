using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGeneral : MonoBehaviour
{
    public PlayerStats playerstats;
    public GameObject bullet;
    public Vector3 launchPoint;
    public Transform trans;
    private GameObject firedbullet;
    public float moveSpeed;
    
    Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;

    public AudioClip playerSound;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        playerstats.playerhealth = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (playerstats.playerhealth <= 0)
        {
            SceneManager.LoadScene("GameOverMenu");
        }
    }
    void FixedUpdate()
    {
       
      shoot();
        Move();

    }

    /* private void FixedUpdate()
     {

     }*/

    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            firedbullet = Instantiate(bullet, (trans.position + launchPoint), trans.rotation);
            firedbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
            AudioManager.Instance.PlayAudio(playerSound);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet"))
        {
            playerstats.playerhealth -= 10;
            Debug.Log("Player Health: " + playerstats.playerhealth);

        }
    }
}
