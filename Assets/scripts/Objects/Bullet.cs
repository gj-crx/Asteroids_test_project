using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10;
    public bool IsLaser = false;

    private Vector3 direction;

    void Start()
    {
        GetDirection();
    }


    private void FixedUpdate()
    {
        transform.Translate(direction * Speed * Time.deltaTime);
    }
    private void GetDirection()
    {
        direction = transform.InverseTransformDirection(GameLogic.PlayerObject.transform.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Asteroid")
        {
            if (IsLaser == false)
            {
                EnemiesSpawner.DestroyBigAsteroid(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MapBorder")
        {
            Destroy(gameObject);
        }
    }
}
