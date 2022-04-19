using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float CurrentSpeed { get; private set; }
    public float AccelerationSpeed = 2;
    public float RotationSpeed = 5;

    public int MaxLasterShots = 5;
    public float LasterShotsReplenishTime = 3;
    public int LaserShotsAviable = 0;

    [HideInInspector]
    public float timer_LaserReplenish = 0;
    private float rotation;

    void Start()
    {
        
    }

    void Update()
    {
        Accelerate((int)Input.GetAxis("Vertical"));
        rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        LaserChargesReplenish();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ShootLaser();
        }
    }
    private void FixedUpdate()
    {
        Moving();
    }
    private void Accelerate(int direction = 1)
    {
       CurrentSpeed += AccelerationSpeed * direction * Time.deltaTime;
    }
    private void Moving()
    {
        transform.Rotate(0, 0, -rotation);
        transform.Translate(transform.InverseTransformDirection(transform.up) * CurrentSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        GameObject.Instantiate(GameLogic.gc.Prefab_bullet, transform.position, Quaternion.identity);
    }
    private void ShootLaser()
    {
        if (LaserShotsAviable > 0)
        {
            GameObject.Instantiate(GameLogic.gc.Prefab_laser, transform.position, Quaternion.identity);
            LaserShotsAviable--;
        }
    }
    private void LaserChargesReplenish()
    {
        if (LaserShotsAviable < MaxLasterShots)
        {
            if (timer_LaserReplenish > LasterShotsReplenishTime)
            {
                timer_LaserReplenish = 0;
                LaserShotsAviable++;
            }
            else
            {
                timer_LaserReplenish += Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameLogic.MapLeaving(transform);
    }
}
