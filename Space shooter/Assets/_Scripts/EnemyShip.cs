using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float hoverSpeed;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private int health = 3;

    private bool canShoot = true;
    private bool goUp = true;
    private Transform upPoint, downPoint;
    private float up, down;
    

    // Use this for initialization
    void Start()
    {
        up = this.transform.position.y + 1f;
        down = this.transform.position.y - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (canShoot)
        {
            canShoot = false;
            Instantiate(rocketPrefab, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0f, 0f, 90f));
            StartCoroutine(shootPlayerCoroutine());
        }
    }

    void Movement()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        //check the direction
        if (transform.position.y >= up)
        {
            goUp = false;
        }else if(transform.position.y <= down)
        {
            goUp = true;
        }
        //move to the direction
        if (goUp)
        {
            transform.Translate(Vector3.left * hoverSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * hoverSpeed * Time.deltaTime);
        }
        //Destroy object
        if (transform.position.x <= -10.63f)
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator shootPlayerCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
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
