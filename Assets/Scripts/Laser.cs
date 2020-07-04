using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // laser params
    [SerializeField]
    private float _speed = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        BoundaryCheck();
    
    }
    
    void CalculateMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }

    void BoundaryCheck()
    {
        if (transform.position.y > GlobleMono.screenHeight + 2)
        {
            // destroy the bullet
            Destroy(this.gameObject);
        }
    }
}
