using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movement;
 
    private Rigidbody2D rig;
    public FixedJoystick moveJoystic;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isJump;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        
    }


    void FixedUpdate()
    {
        Move();
    }

    void Flip()
    {
        if (movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void Move()
    {
        //TO DO: Retirar essa lógica podre feita só pra testar o jogo pelo pc
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            movement = Input.GetAxis("Horizontal");
            rig.velocity = new Vector2(movement * speed * Time.deltaTime, rig.velocity.y);

        }

        else
        {
            movement = moveJoystic.Horizontal;
            rig.velocity = new Vector2(movement * speed * Time.deltaTime, rig.velocity.y);

        }
    }

    public void Jump()
    {
       
        if(!isJump)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isJump = false;
        }
    }
}
