using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveKnight : MonoBehaviour
{
    public Rigidbody2D knightBody;
    public float baseMoveSpd = 7;
    private float diagonalMoveSpd; 
    public Transform knightTransform;
    public Animator knightAnimator;
    public AudioSource walkingSound;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            twinStickMovement(baseMoveSpd*2); //listen for player inputs for movement
        } else
        {
            twinStickMovement(baseMoveSpd);
        }
         
        knightAnimator.SetFloat("KnightSpd", knightBody.velocity.magnitude);

        walkingAudio(); //play walking audio based on player movement speed

        crouch(); //check if player wants to crouch


    }

    void walkingDirection()
    {
        if (knightBody.velocity.x < 0)
        {
            knightTransform.localScale = new Vector3(-1, 1, 1);
        }
        if (knightBody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void walkingAudio()
    {
        if ((knightBody.velocity.magnitude >= 2) && (walkingSound.isPlaying == false))
        {
            walkingSound.Play();

        }
        else if ((knightBody.velocity.magnitude < 2) && (walkingSound.isPlaying == true))
        {
            walkingSound.Stop();
        }
    }

    void twinStickMovement(float moveSpd)
    {
        diagonalMoveSpd = moveSpd / Mathf.Sqrt(2); // this is a hack
        if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W))
        {
            knightBody.velocity = Vector2.up * moveSpd;
            if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D))
            {
                knightBody.velocity = new Vector2(diagonalMoveSpd, diagonalMoveSpd);
                walkingDirection();
            }
            if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A))
            {
                knightBody.velocity = new Vector2(-diagonalMoveSpd, diagonalMoveSpd);
                walkingDirection();
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D))
        {
            knightBody.velocity = new Vector2(moveSpd, 0);
            walkingDirection();
            if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W))
            {
                knightBody.velocity = new Vector2(diagonalMoveSpd, diagonalMoveSpd);
            }
            if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S))
            {
                knightBody.velocity = new Vector2(diagonalMoveSpd, -diagonalMoveSpd);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A))
        {
            knightBody.velocity = new Vector2(-moveSpd, 0);
            walkingDirection();
            if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W))
            {
                knightBody.velocity = new Vector2(-diagonalMoveSpd, diagonalMoveSpd);
            }
            if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S))
            {
                knightBody.velocity = new Vector2(-diagonalMoveSpd, -diagonalMoveSpd);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S))
        {
            knightBody.velocity = Vector2.down * moveSpd;
            if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D))
            {
                knightBody.velocity = new Vector2(diagonalMoveSpd, -diagonalMoveSpd);
                walkingDirection();
            }
            if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A))
            {
                knightBody.velocity = new Vector2(-diagonalMoveSpd, -diagonalMoveSpd);
                walkingDirection();
            }
        }

    }

    void crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            knightAnimator.SetBool("CrouchTrue", true);
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            knightAnimator.SetBool("CrouchTrue", false);
        }
    }
}
