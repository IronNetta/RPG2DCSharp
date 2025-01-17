using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacterScript : MonoBehaviour
{
    // Variables
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer; 
    Vector2 dir;
    int dirValue= 0; //0 = idle, 1= down,  2 = Side, 3 = up

    // Fonctions Unity
    void Update()
    {
        HandleKeys();

        HandelMove();
    }

    //Fonctions custom
    public void HandleKeys()
    {
        if(Input.GetKey(KeyCode.UpArrow))//Flèche du haut
        {
            dir = Vector2.up;
            dirValue = 3;
        }
        else if(Input.GetKey(KeyCode.RightArrow))// droite
        {
            dir = Vector2.right;
            dirValue = 2;
            spriteRenderer.flipX = true;
        }
        else if(Input.GetKey(KeyCode.DownArrow))//bas
        {
            dir = Vector2.down;
            dirValue = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))//gauche
        {
            dir = Vector2.left;
            dirValue = 2;
            spriteRenderer.flipX = false;
        }
        else //rien
        {
            dir = Vector2.zero;
            dirValue = 0;
        }
    }

    //gestion de mouvement
    public void HandelMove()
    {
        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        animator.SetInteger("dir", dirValue);
    }
}
