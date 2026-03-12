using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpStrength = 10f;
    private float speed = 2f;
    private Animator animator;

    //public PlayerPositionHandler pph;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.Instance.GameManagerCheck();
    }

    private void PlayWalkAnimation()
    {
        animator.SetTrigger("goWalk");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        var x = horizontalInput * speed * Time.deltaTime;
        var xyz = new Vector3(x, 0f, 0f);
        transform.Translate(xyz);

        if (horizontalInput != 0) PlayWalkAnimation();

        var mth = Mathf.Abs(rb.linearVelocity.y) < 0.001f;

        if (Input.GetKeyDown(KeyCode.Space) && mth)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
        }
    }
}


//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    private Rigidbody2D rb;
//    private float jumpStrength = 10f;
//    private float speed = 5f;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");

//        // Gerak kiri kanan pakai Rigidbody
//        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

//        // Cek apakah hampir menyentuh tanah
//        bool isGrounded = Mathf.Abs(rb.velocity.y) < 0.01f;

//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
//        }
//    }
//}
