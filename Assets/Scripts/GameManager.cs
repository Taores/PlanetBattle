using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] enemyPrefebs;
    // Start is called before the first frame update
    void Start()
    {
        //enemyPrefebs = Resources.Load<GameObject>("Enemy");
        enemyPrefebs = Resources.LoadAll<GameObject>("Enemys");
        InvokeRepeating("createEnemy",1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void createEnemy()
    {
        int randomNum = Random.Range(0, 3);
        GameObject enemy = Instantiate(enemyPrefebs[randomNum], new Vector3(Random.Range(-3.5f,3.5f),6.0f,0.0f),Quaternion.identity);
        enemy.AddComponent<EnemyControler>();
    }
}
