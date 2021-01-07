using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    /// Score Text
    public Text scoreText;

    /// Health text
    public Text healthText;

    /// End game text
    public Text winLoseText;

    /// End game image
    public GameObject winLoseBG;

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
            
            Image tmp = winLoseBG.GetComponent<Image>();
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            tmp.color = Color.red;
            winLoseBG.SetActive(true);
            StartCoroutine(Loadscene(3));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    /// Reloads the scene after x seconds on gameover
    IEnumerator Loadscene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        health = 5;
        score = 0;
    }

    /// Collide checker for coins
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup") {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        } else if (other.tag == "Trap") {
            health -= 1;
            SetHealthText();
        } else if (other.tag == "Goal") {
            Image tmp = winLoseBG.GetComponent<Image>();
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            tmp.color = Color.green;
            winLoseBG.SetActive(true);
            StartCoroutine(Loadscene(3));
        }
        
    }

    /// sets scoreText variable
    void SetScoreText()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    /// sets healthText variable
    void SetHealthText()
    {
        healthText.text = string.Format("Health: {0}", health);
    }
}
