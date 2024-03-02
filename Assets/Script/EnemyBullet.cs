  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D Target;
    Rigidbody2D rb2D;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {   
       rb2D = GetComponent<Rigidbody2D>();

        Target = GameManager.instance.player.GetComponent<Rigidbody2D>();

        Vector3 direction = Target.transform.position - transform.position;
        rb2D.velocity = new Vector2 (direction.x, direction.y).normalized  * Speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
