using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyJoystick : MonoBehaviour
{
    [HideInInspector] public bool facingLeft = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;

    public float speed;             //Floating point variable to store the player's movement speed.
    public GameObject arrowSprite;
    private Vector2 bossPosition;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform heroTransform;
    public GameObject hero;

    protected Joystick joystick;
    protected JoyButton joybutton;
    protected Reset resetbtn;

    // Start is called before the first frame update
    void Start()
    {
        bossPosition = GameObject.FindWithTag("bossObject").transform.position;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
        resetbtn = FindObjectOfType<Reset>();
        rb2d =GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        heroTransform = GameObject.FindWithTag("Player").transform;
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //joystick movement
        anim.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        if (joystick.Horizontal > 0.1)
        {
            rb2d.AddForce(Vector2.right * joystick.Horizontal * moveForce);
        }
        if (joystick.Horizontal < -0.1)
        {
            rb2d.AddForce(Vector2.right * joystick.Horizontal * moveForce);
        }
   

        if (joystick.Horizontal < 0 && !facingLeft)
            Flip();
        else if (joystick.Horizontal > 0 && facingLeft)
            Flip();

        //firing logic
        if (joybutton.Pressed == true)
        {
            float angle = Vector2.Angle(bossPosition, heroTransform.position);
            if (heroTransform.position.x > bossPosition.x)
            {
                angle *= -1;
            }
            GameObject shot = Instantiate(arrowSprite, heroTransform.position,
                Quaternion.Euler(heroTransform.position.x, heroTransform.position.y, angle));
        }

        //reset logic
        if (resetbtn.Pressed == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        rb2d.velocity = new Vector2(0.0f, 0.0f);
    }


    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = rb2d.transform.localScale;
        theScale.x *= -1;
        rb2d.transform.localScale = theScale;
    }
}
