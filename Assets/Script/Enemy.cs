using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Target;
    public int EnemyHp;
    public int MonsterType;

    public float CurShotDelay;
    public float MaxShotDelay;

    public GameObject Ammo1;
    public GameObject Ammo2;
    public GameObject Ammo3;

    Animator anim;
    Rigidbody2D rb2D;
    SpriteRenderer sr;

   

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

     void Start()
    {
        Target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyMove();
    }

    void FixedUpdate()
    {
        

        if (EnemyHp <= 0)
        {

            int ran = Random.Range(0, 10);
            if (ran < 3)
            {
                Debug.Log("no item");
            }
            else if (ran < 6)
            {
                Instantiate(Ammo2, transform.position, Ammo1.transform.rotation);
            }
            else if (ran < 9)
            {

                Instantiate(Ammo1, transform.position, Ammo1.transform.rotation);
            }
            else if (ran < 10)
            {
                Instantiate(Ammo3, transform.position, Ammo1.transform.rotation);
            }
            Destroy(gameObject);
        }

    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", rb2D.position.magnitude);

        sr.flipX = Target.position.x > rb2D.position.x;
    }

    void EnemyMove()

    {
        Vector2 dirVec = Target.position - rb2D.position;
        Vector2 nextVec = dirVec.normalized * Speed * Time.fixedDeltaTime;

        rb2D.MovePosition(rb2D.position + nextVec);
        rb2D.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet1")
        {   
            
            EnemyHp -= 9;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet2")
        {

            EnemyHp -= 7;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet3")
        {

            EnemyHp -= 30;
            Destroy(collision.gameObject);
        }

    }


}
