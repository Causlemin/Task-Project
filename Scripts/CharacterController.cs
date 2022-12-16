using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] float speed = 2f;
    Vector2 mVect;
    public Vector2 lastmVect;
    public Animator[] _animators;
    public bool _isMoving;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        mVect = new Vector2(horizontal, vertical);

        foreach (var anims in _animators)
        {
            if (anims.gameObject.activeSelf)
            {
                anims.SetFloat("horizontal", horizontal);
                anims.SetFloat("vertical", vertical);
                anims.SetBool("isMoving", _isMoving);
            }
        }

        _isMoving = horizontal != 0 || vertical != 0;


        if (horizontal != 0 || vertical != 0)
        {
            lastmVect = new Vector2(horizontal, vertical).normalized;

            foreach (var anims in _animators)
            {
                if (anims.gameObject.activeSelf)
                {
                    anims.SetFloat("lastHorizontal", horizontal);
                    anims.SetFloat("lastVertical", vertical);
                }
                    
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = mVect * speed;
    }
}
