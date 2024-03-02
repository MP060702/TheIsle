using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
   
    public GameObject shot;
    public Text Ammos1;
    public Text Ammos2;
    public Text Ammos3;
    public Text Timerr;
    public Player Players;
    public GameObject player;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public Transform[] SpawnPoints;
    public static GameManager instance;

    public float CurSpawnDelay;
    public float MaxSpawnDelay;

    public float GameTimer;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
               
    }

   void Update()
    {

        CurSpawnDelay += Time.deltaTime;

        GameTimer += Time.deltaTime;

        if(CurSpawnDelay > MaxSpawnDelay )
        {
            SpawnEnemy();
            MaxSpawnDelay = Random.Range(0.5f, 3f);
            CurSpawnDelay = 0;
        }


        if(GameTimer >= 300) 
        {
            SceneManager.LoadScene("Win");
        }


        Shoot shots = shot.GetComponent<Shoot>();
        Ammos1.text = string.Format("{0:n0}", shots.Ammo1);
   
        Ammos2.text = string.Format("{0:n0}", shots.Ammo2);

        Ammos3.text = string.Format("{0:n0}", shots.Ammo3);  
        
        Timerr.text = string.Format("{0:n0}", GameTimer);



    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 10);
        int ranPoint = Random.Range(0, 8);
        
        if( ranEnemy < 6)
        {
            Instantiate(Enemy1, SpawnPoints[ranPoint].position, SpawnPoints[ranPoint].rotation);

        }
        else if( ranEnemy < 7)
        {
            Instantiate(Enemy2, SpawnPoints[ranPoint].position, SpawnPoints[ranPoint].rotation);
        }
        else if( ranEnemy < 8)
        {
            Instantiate(Enemy3, SpawnPoints[ranPoint].position, SpawnPoints[ranPoint].rotation);
        }
        else if(ranEnemy < 10)
        {
            Instantiate(Enemy4, SpawnPoints[ranPoint].position, SpawnPoints[ranPoint].rotation);
        }
    }

    
}
