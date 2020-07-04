using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // player's parameter
    [SerializeField]
    private float _speed = 15;  // c sharp cannot do conversion automatically
    [SerializeField]
    private float _slowSpeed = 5f;
    [SerializeField]
    private int _fireRate = 5;
    [SerializeField]
    private float _coolTime = 0.1f;
    private float _canfire = 0.0f;

    // Cached input
    private float _prevHorizontalInput;
    private float _prevVerticalInput;

    // player's components
    [SerializeField]
    private GameObject _laserPrefab;

    void Start()
    {
        // init the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && Time.time > _canfire) {
            _canfire = Time.time + _coolTime;
            Shoot();
        }

        float sp = _speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sp = _slowSpeed;
        }
        
        CalculateMovement(sp);
        BoundaryCheck();
    }

    void CalculateMovement(float sp)
    {
        // get the input of moving
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // set the moving direction
        float dirx, diry;
        dirx = horizontalInput;
        diry = verticalInput;
        if (_prevHorizontalInput * horizontalInput < 0)
            dirx *= 10;
        if (_prevVerticalInput * verticalInput < 0)
            diry *= 10;

        // conduct the move
        Vector3 dirs = new Vector3(dirx, diry, 0);
        transform.Translate(dirs * Time.deltaTime * sp);

        // cache the old input
        _prevHorizontalInput = horizontalInput;
        _prevVerticalInput = verticalInput;
    }

    void BoundaryCheck()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -GlobleMono.screenWidth, GlobleMono.screenWidth),
            Mathf.Clamp(transform.position.y, -GlobleMono.screenHeight, GlobleMono.screenHeight),
            0
        );
    }

    void Shoot()
    {
        for (int i = - _fireRate / 2; i <= _fireRate / 2; i++)
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0.3f * i, 0.7f, 0), Quaternion.identity);

        }
    }
}
