using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // global parameter
    private float _screenRatio = 16f / 9;
    private float _screenWidth;
    private float _screenHeight;

    // player's parameter
    private float _speed = 30f;  // c sharp cannot do conversion automatically
    private float _slowSpeed = 10f;

    // Cached input
    private float _prevHorizontalInput;
    private float _prevVerticalInput;

    // states
    private bool isShoot = false;
    private bool isSlowMove = false;

    void Start()
    {
        // init the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        // init the screen size
        _screenWidth = -Camera.main.transform.position.z;
        _screenHeight = -Camera.main.transform.position.z / _screenRatio;
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            Shoot();
        }
        float sp = _speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sp = _slowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            sp = _speed;
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
            Mathf.Clamp(transform.position.x, -_screenWidth, _screenWidth),
            Mathf.Clamp(transform.position.y, -_screenHeight, _screenHeight),
            0
        );
    }

    void Shoot() {

    }
}
