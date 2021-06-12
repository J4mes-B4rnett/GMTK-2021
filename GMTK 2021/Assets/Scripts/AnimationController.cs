using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    public RuntimeAnimatorController rabbitAnimController;
    public RuntimeAnimatorController turtleAnimController;
    public RuntimeAnimatorController turtleWithoutShellAnimController;
    public Controller baseController;
    //enum declaration
    public enum AnimationState { idle, walk, jump, burrow, climb }
    public enum Layer { Rabbit, Turtle, TurtleWithoutShell}

    //enum initialization
    public AnimationState animState = AnimationState.idle;
    public Layer layer;

    void Update()
    {
        UpdateState();
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
        if (baseController.animal == Controller.Animal.Rabbit) layer = Layer.Rabbit;
        if (baseController.animal == Controller.Animal.Turtle && baseController.shellActivated) layer = Layer.TurtleWithoutShell;
        if (baseController.animal == Controller.Animal.Turtle && !baseController.shellActivated) layer = Layer.Turtle;

        switch (layer)
        {
            case Layer.Rabbit:
                anim.runtimeAnimatorController = rabbitAnimController;
                break;
            case Layer.Turtle:
                anim.runtimeAnimatorController = turtleAnimController;
                break;
            case Layer.TurtleWithoutShell:
                anim.runtimeAnimatorController = turtleWithoutShellAnimController;
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
