using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    private GameObject enemyBulletPrefeb;

    private Animator animator;
    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -6.0f;
    public float yMax = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyBulletPrefeb = Resources.Load<GameObject>("EnemyBullet");
        //InvokeRepeating("EnemyAttack",0.0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * Random.Range(3,6));
         if (transform.position.x < xMin || transform.position.x > xMax || transform.position.y < yMin || transform.position.y > yMax)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyAttack()
    {
        GameObject enemyBullet = Instantiate(enemyBulletPrefeb,this.transform.position ,Quaternion.identity);
        enemyBullet.AddComponent<EnemyBulletControler>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            PlayExplosion();
            Destroy(other.gameObject); // 销毁子弹
            //Destroy(gameObject); // 销毁敌人
            PlayerControler.onGetScore();
        }
    }

    public void PlayExplosion()
    {
        animator.SetBool("isExplosion",true);
        Debug.Log("ex");
    }
    
    public void PlayEnd()
    {
        animator.SetBool("isExplosion",false);
    }

}
