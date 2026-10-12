using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement4 : MonoBehaviour
{
    public int facingDirection;

    private Rigidbody2D rb;
    public Animator animator;

    private float x;
    private float y;

    private Vector2 input;
    private bool moving;
    private bool isKnockedBack;

    public PLayer_Combat pLayer_Combat;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();

        if (Input.GetButtonDown("Slash") 
            && pLayer_Combat.enabled == true)
        {
            pLayer_Combat.Attack();
        }
    }

    private void Animate()
    {
        // Gán trực tiếp: moving sẽ là true nếu magnitude > 0.1f, và false nếu ngược lại.
        moving = input.magnitude > 0.1f;

        if (moving)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }

        animator.SetBool("Moving", moving);
    }

    private void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            rb.velocity = input * StatManager.Instance.moveSpeed;
        }

        if (x > 0 && transform.localScale.x < 0 ||
            x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }


    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2 (x, y);
        input.Normalize();
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
