using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
 
    private Rigidbody2D rig;
    public FixedJoystick moveJoystic;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isJump;
    private bool isKeyboardButton;
    private bool isMobileButton;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        Jump();
    }


    void FixedUpdate()
    {
        Move();
    }

    
    void Move()
    {
        //TO DO: Retirar o suporte de teclado ao fim do projeto 
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed * Time.deltaTime, rig.velocity.y);

        if (movement > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
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
