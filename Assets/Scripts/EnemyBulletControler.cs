using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControler : MonoBehaviour
{
   
    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -6.0f;
    public float yMax = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * 10);

        if (transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // Debug.Log("Bullet hit Bullet!");
            // Destroy(other.gameObject); // 销毁子弹
            // Destroy(gameObject); // 销毁子弹
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // 销毁子弹
        }
    }
}

