using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 InputVec;
    public float speed;
    public int PlayerHp = 100;
    public HealthBar healthBar;
    public HealthSystem healthSystem;
    public Shoot shots;
    public int PlusMonsterDamage;
    public float Hard;

    public float CurHealDelay;
    public float MaxHealDelay;

    Rigidbody2D rb2D;
    SpriteRenderer sr;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {   
        healthSystem = new HealthSystem(PlayerHp);
        healthBar.Setup(healthSystem);
        Debug.Log("Health : " + healthSystem.GetHealth());

        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputVec.x = Input.GetAxisRaw("Horizontal");
        InputVec.y = Input.GetAxisRaw("Vertical");

        Hard += Time.deltaTime;

        CurHealDelay += Time.deltaTime;
        if (CurHealDelay < MaxHealDelay)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            healthSystem.Heal(25);
            CurHealDelay = 0;
        }

        if(Hard >= 50)
        {
            PlusMonsterDamage = 3;
        }
        else if (Hard >= 100)
        {
            PlusMonsterDamage = 6;
        }
        else if (Hard >= 150)
        {
            PlusMonsterDamage = 9;
        }
        else if (Hard >= 200)
        {
            PlusMonsterDamage = 12;
        }

    }
    void FixedUpdate()
    {
        PlayerMove();
        
        
    }

    void PlayerMove()
    {
        Vector2 nextVec = InputVec.normalized * speed * Time.fixedDeltaTime;
        rb2D.MovePosition(rb2D.position + nextVec);

        anim.SetFloat("Speed", InputVec.magnitude);

        if(InputVec.x != 0)
        {
            sr.flipX = InputVec.x < 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ammo1")
        {
            shots.Ammo1 += 12;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Ammo2")
        {
            shots.Ammo2 += 30;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Ammo3")
        {
            shots.Ammo3 += 8;
            Destroy(collision.gameObject);
        }    

    }

    void OnCollisionEnter2D(Collision2D collision)
    {       

        if (collision.gameObject.tag == "Enemy")
        {
            healthSystem.Damage(8 + PlusMonsterDamage);
           
            OnDamged(collision.transform.position);
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            healthSystem.Damage(10 + PlusMonsterDamage);

            OnDamged(collision.transform.position);
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            healthSystem.Damage(5 + PlusMonsterDamage);

            OnDamged(collision.transform.position);
        }
        if (collision.gameObject.tag == "Enemy4")
        {
            healthSystem.Damage(6 + PlusMonsterDamage);

            OnDamged(collision.transform.position);
        }

    }

    void OnDamged(Vector2 targetPos)
    {
        
        gameObject.layer = 8;

        sr.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 1);

    }

    void OffDamaged()
    {
        gameObject.layer = 7;
        sr.color = new Color(1, 1, 1, 1);

    }
}
