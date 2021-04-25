using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    [Header ("Скорость игрока")]
    [SerializeField] private float speedX = 1f;
    [Header("Сила прыжка")]
    [SerializeField] private float jumppower = 200f;

    const float speedMultiplier = 50f;

    private float _horizontal = 0;

    private bool _isGround = false;
    private bool _isJump = false;

    private bool _isFacingRight = true;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal"); // -1...1
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && _isGround)
        {
            _isJump = true;
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * speedMultiplier * Time.fixedDeltaTime, _rb.velocity.y);
        if (_isJump)
        {
            _rb.AddForce(new Vector2(0, jumppower));
            _isGround = false;
            _isJump = false;
        }
        if (_horizontal > 0f && !_isFacingRight)
        {
            Flip();
        }
        else if (_horizontal < 0f && _isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.z *= -1;
        transform.localScale = playerScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
           _isGround = true;
        }
    }
}