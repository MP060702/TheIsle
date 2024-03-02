using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Shoot shots;
    public SpriteRenderer sr;
    public Sprite[] sprites = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shots.rotZ > 90 || shots.rotZ < -90 )
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }

        if(shots.GunType == 0)
        {
            sr.sprite = sprites[0];
        }
        if (shots.GunType == 1)
        {
            sr.sprite = sprites[1];
        }
        if (shots.GunType == 2)
        {
            sr.sprite = sprites[2];
        }
        if (shots.GunType == 3)
        {
            sr.sprite = sprites[3];
        }
    }
}
