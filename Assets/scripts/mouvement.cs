using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mouvement : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 8f;
    private Rigidbody2D rb;
    public float decalage;

    private bool grounded;
    private Collider2D[] colls;
    private CapsuleCollider2D monColl;
    private SpriteRenderer skin;
    private Animator anim;
    public GameObject roue;
    public GameObject roue2;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        monColl= GetComponent<CapsuleCollider2D>();
        skin = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        groundCheck();
        moveCheck();
        flipCheck();
        //animCheck();
    }

    void groundCheck() {
        grounded = false;
        colls = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, monColl.bounds.min.y + decalage), monColl.bounds.extents.x * 0.9f);
        foreach(Collider2D coll in colls) {
            if(coll != monColl && !coll.isTrigger) {
                grounded = true;
                break;
            }
        }
    }

    void moveCheck() {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Mouse X") * 30f, rb.velocity.y);
            roue.transform.Rotate(new Vector3(0, 0, Convert.ToInt32(Input.GetAxis("Mouse X")*-4f)));
            roue2.transform.Rotate(new Vector3(0, 0, Convert.ToInt32(Input.GetAxis("Mouse X") * -4f)));
        }
    }

    void flipCheck() {
        if(Input.GetAxisRaw("Horizontal") > 0) {
            skin.flipX = false;
        }

        if (Input.GetAxisRaw("Horizontal") < 0) {
            skin.flipX = true;
        }
    }

    void animCheck() {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY", rb.velocity.y);
        anim.SetBool("grounded", grounded);
    }

    void OnDrawGizmos() {
        if(monColl == null) {
            monColl = GetComponent<CapsuleCollider2D>();
        }

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, monColl.bounds.min.y + decalage), monColl.bounds.extents.x * 0.9f);
    }
}
