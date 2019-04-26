using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int health = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -10.63f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            health = health - 1;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
