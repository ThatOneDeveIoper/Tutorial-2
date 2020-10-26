using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;
    public Text winText;
    public Text loseText;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    public Text Lives;
    private int scoreValue = 0;
    private int TotalLives = 3;
    public GameObject objectToDisable;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Score: " + scoreValue.ToString();
        winText.text = "";
        loseText.text = "";
        SetLivesCount();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        

     isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);
     

    if (TotalLives<= 0)
     {
      loseText.text= "You Lose...";
      GameObject.Find("Player").GetComponent<PlayerScript>().enabled = false;
     }
     
     if (scoreValue>= 4)
     {
      winText.text= "You've Won! - Game by Brandon Brennen";
     }

     

        if (Input.GetKey("escape"))
     {
            Application.Quit();
     }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
if (collision.collider.tag == "Foe")
        {
            TotalLives -= 1;
            Lives.text = "Lives: " + TotalLives.ToString();
            Destroy(collision.collider.gameObject);
        }

    }
    

    
    void SetLivesCount()
    {
        Lives.text = "Lives: " + TotalLives.ToString();
        {

    }
}
    void SetScoreText()
    {
 score.text = "Score: " + scoreValue.ToString ();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }

 
        }
    }
}