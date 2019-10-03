using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 launchPoint;
    public Transform trans;
   
 

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
 
            Instantiate(bullet,(trans.position+launchPoint),transform.rotation);



        }
    }
    
}
