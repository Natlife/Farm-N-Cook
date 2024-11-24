using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 goal;
    public Animator anim;




    //Update function:
    //declare 2 variable to get the input of the position 
    //horizontal: Left n Right way
    //vertical: Up n Down way
    //identify the vector(horizontal,vertical) as the goal to go
    //apply the movement to okayer
    private void Update()//run once per frame
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        goal= new Vector3 (horizontal, vertical);
        animatorMovement(goal);
        
    }
    //FixedUpdate function:
    //solve the problem when player collider reach another collider in the world map
    private void FixedUpdate()
    {
        transform.position += goal * speed * Time.deltaTime;
    }

    //Animator Movement function:
    //check if the anim have already set
    //check if the player isMoving or not
    //isMoving==true: set the input for horizontal and vertical in anim to decide the way player go
    //isMoving==falsel: stay in the Idle 
    void animatorMovement(Vector3 goal)
    {
        if(anim != null) {
            if(goal.x!=0 || goal.y != 0)
            {
                anim.SetBool("isMoving", true);
                if (goal.x < 0)
                {
                    transform.localScale = new Vector3(-1,1,1);//change the anim way to the left
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);//change the anim way to the right
                }
                anim.SetFloat("horizontal",goal.x);
                anim.SetFloat("vertical",goal.y);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }

    }
}
