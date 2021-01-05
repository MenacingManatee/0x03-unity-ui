using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Speed stat of player
    /// </summary>
    public float speed = 50;

    public int health = 5;

    /// Rigidbody component
    private Rigidbody rb;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movex, 0, movey);
        rb.AddForce (movement * speed);

        if (health <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            health = 5;
            score = 0;
        }
    }

    /// Collide checker for coins
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup") {
            score += 1;
            Debug.Log(string.Format("Score: {0}", score));
            Destroy(other.gameObject);
        } else if (other.tag == "Trap") {
            health -= 1;
            Debug.Log(string.Format("Health: {0}", health));
        } else if (other.tag == "Goal") {
            Debug.Log("You win!");
        }
        
    }
}
