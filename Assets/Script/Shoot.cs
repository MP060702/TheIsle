using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera mainCam;
    public GameObject Bullet;
    public Transform BulletTransform;
    public GameObject SniperBullet;

    public int Ammo1;
    public int Ammo2;
    public int Ammo3;

    public float rotZ;
    public float Cultime;
    public float timer;
    public int GunType;

    public float OffSet;

    public Transform ShotPos;

    public GameObject BugshotBullet;

    public int AmountBullets;

    public float Spread, BulletSpeed;

    public Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();  
    }

    // Update is called once per frame
    void Update()
    {   

        GunMoveing();
        GunChoose();   
        GunShooting();

        timer += Time.deltaTime;

        switch (GunType)
        {   
            case 0:
                Cultime = 0.4f;
                break;
            case 1:
                Cultime = 0.65f;
                break;
            case 2:
                Cultime = 0.15f;
                break;
            case 3:
                Cultime = 0.92f;
                break;
               
        }

    }


    void GunMoveing()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }

    void GunChoose()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GunType = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GunType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GunType = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GunType = 3;
        }
    }

    void GunShooting()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (timer < Cultime)
            return;

        if (GunType == 0)
        {
            
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);

        }
        if (GunType == 1)
        {
            if (Ammo1 != 0)
            {
                for (int i = 0; i < AmountBullets; i++)
                {
                    GameObject b = Instantiate(BugshotBullet, ShotPos.position, ShotPos.rotation);
                    Rigidbody2D brb = b.GetComponent<Rigidbody2D>();
                    Vector2 dir = transform.rotation * Vector2.right;
                    Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-Spread, Spread);
                    brb.velocity = (dir + pdir) * BulletSpeed;
                }
                Ammo1 -= 1;
            }         
        }
        if (GunType == 2)
        {
           if(Ammo2 != 0)
            {
                Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
                Ammo2 -= 1;
            } 
            
        }
        if (GunType == 3)
        {
            
            if(Ammo3 != 0)
            {
                Instantiate(SniperBullet, BulletTransform.position, Quaternion.identity);
                Ammo3 -= 1;
            }
        }

        timer = 0;
    }
}
