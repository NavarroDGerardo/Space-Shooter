using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private int health = 5;
    [SerializeField] private Text gameOverText;

    private bool canShoot = true;
    private Renderer rend;
    private Color colorToTurn = Color.red;
    

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        horizontalInput = horizontalInput * -1;

        transform.Translate(Vector3.right * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * horizontalInput * speed * Time.deltaTime);

        if (transform.position.y > 4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }
        else if (transform.position.y < -4.3f)
        {
            transform.position = new Vector3(transform.position.x, 4.3f, 0);
        }

        if (transform.position.x >= 0f)
        {
            transform.position = new Vector3(0f, transform.position.y, 0);
        }
        else if (transform.position.x <= -8.4f)
        {
            transform.position = new Vector3(-8.4f, transform.position.y, 0);
        }
    }

    void shoot()
    {
        Instantiate(rocketPrefab, transform.position + new Vector3(0.7f, 0, 0), Quaternion.Euler(0f, 0f, -90f));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            StartCoroutine(colorChangeCoroutine());
            Destroy(other.gameObject);
            health = health - 1;
            if (health <= 0)
            {
                Destroy(this.gameObject);
                gameOverText.text = "GAME OVER";
            }
        }
    }

    public IEnumerator colorChangeCoroutine()
    {
        rend.material.color = colorToTurn;
        yield return new WaitForSeconds(0.2f);
        rend.material.color = Color.white;
    }


}
