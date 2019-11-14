using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    [SerializeField] protected float speed;
    public float bulletSpeed;

    public abstract void shoot();
    public abstract void move();

    public abstract void loseHealth(float value);
   
}
