using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Character_Mechanics : MonoBehaviour
{
    private Rigidbody2D rb;
    public static float velocity;
    public float character_jump_force;
    public bool groundcheck;
    public static int Score;
    public static int deaths;
    public TextMeshProUGUI ScoreText;
    public GameObject JumpSound;
    public GameObject GemSound;
    public GameObject KeySound;
    private Animator anima2D;
    public GameObject Door1;
    public GameObject Door2;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 4.5f;
        Score = 0;
        groundcheck = true;
        rb = GetComponent<Rigidbody2D>();
        anima2D = GetComponent<Animator>();
        ScoreText.text = "000" + ScoreText.text;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1, 0) * Time.deltaTime * velocity, Space.World);
        anima2D.SetBool("groundcheck", groundcheck);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "follow")
        {
            groundcheck = true;
        }

        if (col.gameObject.tag == "enemie")
        {
            SceneManager.LoadScene("game_over");
        }

        if (col.gameObject.tag == "follow")
        {
            transform.parent = col.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        groundcheck = false;

        if (col.gameObject.tag == "follow")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "gem")
        {
            GemSound.GetComponent<AudioSource>().Play();
            Score = Score + 1;
            ScoreText.text = "" + Score;
            Destroy(col.gameObject);

            if (Score >= 0f && Score <= 9f)
            {
                ScoreText.text = "00" + ScoreText.text;
            }

            if (Score >= 10f && Score < 100f)
            {
                ScoreText.text = "0" + ScoreText.text;
            }

            if (Score >= 100f && Score <= 999f)
            {
                ScoreText.text = "" + ScoreText.text;
            }
        }

        if (col.gameObject.name == "Key")
        {
            KeySound.GetComponent<AudioSource>().Play();
            Destroy(col.gameObject);
            Destroy(Door1);
        }

        if (col.gameObject.name == "Key_2")
        {
            KeySound.GetComponent<AudioSource>().Play();
            Destroy(col.gameObject);
            Destroy(Door2);
        }

        if (col.gameObject.tag == "fall")
        {
            SceneManager.LoadScene("game_over");
        }

        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("win");
        }
    }

    public void JumpButton()
    {
        if (groundcheck == true)
        {
            rb.velocity = Vector2.up * character_jump_force;
            JumpSound.GetComponent<AudioSource>().Play();
        }
    }
}