using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{   
    static CameraManager instance;

    public GameObject Target;
    public float MoveSpeed;
    private Vector3 targetPosition;

    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    private float HalfWidth;
    private float HalfHeight;

    private Camera theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        HalfHeight = theCamera.orthographicSize;
        HalfWidth = HalfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target.gameObject != null)
        {
            targetPosition.Set(Target.transform.position.x, Target.transform.position.y, this.transform.position.z);
            
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, MoveSpeed * Time.deltaTime);

            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + HalfWidth, maxBound.x - HalfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + HalfHeight, maxBound.x - HalfHeight);
            
            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

        }
    }
}
