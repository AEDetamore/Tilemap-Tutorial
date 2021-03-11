using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private int lives;
    private int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        SetScoreValue();
        SetLivesText();
        scoreValue = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue = scoreValue + 1;
            SetScoreValue();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            lives = lives - 1;
            SetLivesText();
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
    void SetScoreValue()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
        if (scoreValue >= 4)
        {
            winText.text = "You Win! Game created by Abigail Detamore";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            loseText.text = "You Lose! Game created by Abigail Detamore";
            Destroy(this);
        }
    }
}
