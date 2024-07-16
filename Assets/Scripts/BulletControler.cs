using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{
    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -3.5f;
    public float yMax = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * 10);

        if (transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Debug.Log("Bullet hit Bullet!");
            Destroy(other.gameObject); // 销毁子弹
            Destroy(gameObject); // 销毁子弹
        }
        else if (other.CompareTag("Enemy"))
        {
          //Destroy(other.gameObject);  //销毁敌机
            Destroy(gameObject); // 销毁子弹
        }
    }
}
