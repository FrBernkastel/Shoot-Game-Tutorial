using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 8f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down at 4 memters per second
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        // if bottom of screen
        // respawn at top with a new random x position
        if (transform.position.y < -GlobleMono.screenHeight) {
            float randomX = Random.Range(-GlobleMono.screenWidth, GlobleMono.screenWidth);
            transform.position = new Vector3(randomX, GlobleMono.screenHeight, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if other is Player: destory us and damage the player
        if (other.tag == "Player")  // get the object by tag
        {
            Damage();
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            // if other is Laser: destory us and destory laser
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Damage()
    {

    }
}
