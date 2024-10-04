using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ArcherController : MonoBehaviour
{
    public float playermovementSpeed = 5f;
    public float jumpPower = 5f;
    public LayerMask layerM;
    public Transform gCheckTrans;

    public GameObject ArrowBody;
    public Transform arrowPoint;
    public float firepower = 5f;


    Animator animatorContoller;
    public ParticleSystem particleEffect;

    Rigidbody2D rbbody;
    void Start()
    {
        rbbody = GetComponent<Rigidbody2D>();
        animatorContoller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");

        rbbody.velocity = new Vector2(movementX * playermovementSpeed, rbbody.velocity.y);


        //jump

        if (Input.GetButton("Jump") && groundcheck())
        {
            //rbbody.AddForce(Vector2.up * jumpPower);
            rbbody.velocity = new Vector2(rbbody.velocity.x, jumpPower);
        }

        if (groundcheck())
        {
            if (Math.Abs(rbbody.velocity.x) > 0)
            {
                animatorContoller.SetInteger("switchAni", 1);
            }
            else
            {
                animatorContoller.SetInteger("switchAni", 0);
            }

        }
        else
        {
            animatorContoller.SetInteger("switchAni", 2);
        }



        if (rbbody.velocity.x < 0)
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (rbbody.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    bool groundcheck()
    {
        return Physics2D.OverlapCapsule(new Vector2(gCheckTrans.position.x, gCheckTrans.position.y), new Vector2(0.2f, 0.2f), CapsuleDirection2D.Vertical, 0, layerM);
    }

    void Shoot()
    {
        GameObject arrowSp = Instantiate(ArrowBody, arrowPoint.position, Quaternion.identity);
        Rigidbody2D arrowrb = arrowSp.GetComponent<Rigidbody2D>();
        arrowrb.velocity = transform.right * firepower;
        particleEffect.Play();
    }
}
