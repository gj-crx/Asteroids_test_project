using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class EnemyObject : MonoBehaviour
    {
        public float Speed = 4;
        public bool ChasingPlayer = true;

        private Vector3 StaticDirection;
        void Start()
        {
            if (ChasingPlayer == false)
            {
                StaticDirection = GetRandomDirection();
            }
        }

        private void FixedUpdate()
        {
            if (ChasingPlayer)
            {
                transform.Translate(GetDirection(GameLogic.PlayerObject.transform.position) * Speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(StaticDirection * Speed * Time.deltaTime);
            }
        }
        private Vector3 GetDirection(Vector3 target)
        {
            return (target - transform.position).normalized;
        }
        private Vector3 GetRandomDirection()
        {
            float rnd = Random.Range(0.0f, 1.0f);
            float modif1 = 1, modif2 = 1;
            if (transform.position.x > 0)
            {
                modif1 *= -1;
            }
            if (transform.position.y > 0)
            {
                modif2 *= -1;
            }
            return new Vector3(rnd * modif1, (1 - rnd) * modif2);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "MapBorder")
            {
                Destroy(gameObject);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameLogic.gc.LoseGame();
            }
        }
    }
