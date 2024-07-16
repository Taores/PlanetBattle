using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class PlayerControler : MonoBehaviour
{

    private GameObject bulletPrefeb;
    public float moveSpeed = 5f;

    public int HP;

    public static int score;

    public TMP_Text HPText; 
    public TMP_Text ScoreText;
    public float xMin = -5f;
    public float xMax = 5f;
    public float yMin = -3.5f;
    public float yMax = 3.5f;

    public GameObject GameoverCanvas;

    public SpriteRenderer spriteRenderer; 
    public Sprite[] sprites;

    public DataManger dataMangerInstance;
    void Start()
    {
        bulletPrefeb = Resources.Load<GameObject>("PB");
        HP = 10;
        score = 0;
        GameoverCanvas.SetActive(false);
        updateHero(PlayerPrefs.GetInt("PlayerID"));
    }

    void Update()
    {
        PlayerMove();
        PlayerAttack();
        updateScoreText();
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 newPosition = transform.position + new Vector3(moveX, moveY) * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);

        transform.position = newPosition;
    }

    private void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject bullet = Instantiate(bulletPrefeb,this.transform.position,this.transform.rotation);
            bullet.AddComponent<BulletControler>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject); 
            OnDamage();
        }
    }

    private void OnDamage()
    {
        HP--;
        updateHPText();
        if (HP <= 0)
        {
            Die();
        }
    }

    private void updateHPText()
    {
        HPText.text = "HP:" + HP.ToString();
    }

    private void updateScoreText()
    {
        ScoreText.text = "Score:" + score.ToString();
    }

    public static void onGetScore()
    {
        score += 1;
    }

    private void Die()
    {
        GameoverCanvas.SetActive(true);
    }

    private void updateHero(int id)
    {
        spriteRenderer.sprite = sprites[id];
        Debug.Log(id.ToString());
    }
}
