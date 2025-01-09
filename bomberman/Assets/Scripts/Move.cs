using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Move : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.zero;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public Animation spriteAnimationUp;
    public Animation spriteAnimationDown;
    public Animation spriteAnimationLeft;
    public Animation spriteAnimationRight;
    private Animation activeSpriteAnimation;
    public Animation spriteAnimationDeath;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteAnimation = spriteAnimationDown;
    }

    private void Update()
    {
        direction = Vector2.zero;

        if (Input.GetKey(inputUp))
        {
            direction += Vector2.up;
            SetDirection(Vector2.up, spriteAnimationUp);
        }
        else if (Input.GetKey(inputDown))
        {
            direction += Vector2.down;
            SetDirection(Vector2.down, spriteAnimationDown);
        }
        else if (Input.GetKey(inputLeft))
        {
            direction += Vector2.left;
            SetDirection(Vector2.left, spriteAnimationLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            direction += Vector2.right;
            SetDirection(Vector2.right, spriteAnimationRight);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction.normalized * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, Animation animation)
    {
        direction = newDirection;

        spriteAnimationUp.enabled = animation == spriteAnimationUp;
        spriteAnimationDown.enabled = animation == spriteAnimationDown;
        spriteAnimationLeft.enabled = animation == spriteAnimationLeft;
        spriteAnimationRight.enabled = animation == spriteAnimationRight;

        activeSpriteAnimation = animation;
        activeSpriteAnimation.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        GetComponent<BombController>().enabled = false;

        spriteAnimationUp.enabled = false;
        spriteAnimationDown.enabled = false;
        spriteAnimationLeft.enabled = false;
        spriteAnimationRight.enabled = false;
        spriteAnimationDeath.enabled = true;

        Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    }

    private void OnDeathSequenceEnded()
    {
        gameObject.SetActive(false);
        /*GameManager.Instance.CheckWinState();*/
    }

}


