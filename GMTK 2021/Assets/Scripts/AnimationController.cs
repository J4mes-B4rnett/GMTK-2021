using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public RuntimeAnimatorController rabbitAnimController;
    public RuntimeAnimatorController turtleAnimController;
    public Controller baseController;
    //enum declaration
    public enum AnimationState { idle, walk, jump, burrow, climb }
    public enum Layer { Rabbit, Turtle }

    //enum initialization
    public AnimationState animState = AnimationState.idle;
    public Layer layer;

    private void Start()
    {
        Debug.Log("hello");
    }
    void Update()
    {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.1f && baseController.isTouchingGround)
        {
            animState = AnimationState.walk;
        }
        else if (!baseController.isTouchingGround)
        {
            animState = AnimationState.jump;
        } else
        {
            animState = AnimationState.idle;
        }

        //to implement for burrow and climb
    }


    public void UpdateState()
    {
        layer = baseController.animal == Controller.Animal.Rabbit ? Layer.Rabbit : Layer.Turtle;
        
        switch (layer)
        {
            case Layer.Rabbit:
                anim.runtimeAnimatorController = rabbitAnimController;
                break;
            case Layer.Turtle:
                anim.runtimeAnimatorController = turtleAnimController;
                break;
        }

        switch (animState)
        {
            case AnimationState.idle:
                anim.SetInteger("State", 0);
                break;
            case AnimationState.walk:
                anim.SetInteger("State", 1);
                break;
            case AnimationState.jump:
                anim.SetInteger("State", 2);
                break;
            case AnimationState.burrow:
                anim.SetInteger("State", 3);
                break;
            case AnimationState.climb:
                anim.SetInteger("State", 4);
                break;
        }
    }
}
