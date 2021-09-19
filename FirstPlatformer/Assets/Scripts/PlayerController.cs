using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    [SerializeField]
    LayerMask platformLayerMask;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D collider;
    private Rigidbody2D rb;
    private float movement;
    private bool jumped;


    // Start is called before the first frame update
    void Start()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame, we do our input collection and animation handling here
    void Update()
    {
        throw new NotImplementedException();
    }

    //Fixed Update runs ona  regular interval, we do our physics calculations here
    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }

    //Detect if the players feet are on the ground
    bool IsGrounded()
    {
        throw new NotImplementedException();
    }


    //Detect when the player runs into a coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        throw new NotImplementedException();
    }
}
