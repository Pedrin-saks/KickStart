using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HaterController : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform groundCheck;

    [Range(1,5)]
    public float waitTimeJumpMinimum;
    [Range(1,5)]
    public float waitTimeJumpMaximum;
    public float jumpForce;

    private bool isGrounded;
    private Rigidbody2D rbEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05F, whatIsGround);
    }


    public void Jump()
    {
        if (isGrounded == false)
        {
            return;
        }

        rbEnemy.velocity = new Vector2(rbEnemy.velocity.x, 0);
        rbEnemy.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //isJumping = false;
    }

    public IEnumerator JumpTime()
    {
        Jump();
        float randT = Random.Range(waitTimeJumpMinimum, waitTimeJumpMaximum);

        yield return new WaitUntil(() => isGrounded);
        yield return new WaitForSeconds(randT);

        print(randT);

        StartCoroutine(JumpTime());

    }

}
