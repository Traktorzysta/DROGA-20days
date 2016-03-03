using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public float maxSpeed = 3;
    public bool up;

    private Rigidbody2D rb2d;
    private Animator anim;
    private float v;


    // Use this for initialization
    void Start()
    {

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }
    void Update()
    {

        anim.SetBool("up", Input.GetKey("up"));
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));


        if (Input.GetAxis("Horizontal") < -0.01f)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }


        if (Input.GetAxis("Vertical") < -0.01f)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Vertical") > 0.01f)
        {

            transform.localScale = new Vector3(1, 1, 1);
        }

    }




    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        {
            rb2d.AddForce((Vector2.right * speed) * h);

            if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

            }
            if (rb2d.velocity.x < -maxSpeed)
            {

                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
            }
        }
        float v = Input.GetAxis("Vertical");
        {


            rb2d.AddForce((Vector2.up * speed) * v);

            if (rb2d.velocity.y > maxSpeed)
            {
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.x);

            }
            if (rb2d.velocity.y < -maxSpeed)
            {

                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.x);
            }
        }
    }
}
    