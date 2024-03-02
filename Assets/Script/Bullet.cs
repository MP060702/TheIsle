using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera mainCam;
    private Rigidbody2D rb2D;
    private Vector3 mousePos;
    public float Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2D = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 dir = mousePos - transform.position;
        Vector3 rotat = transform.position - mousePos;

        rb2D.velocity = new Vector2(dir.x, dir.y).normalized * Speed;

        float rot = Mathf.Atan2(rotat.y, rotat.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
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
