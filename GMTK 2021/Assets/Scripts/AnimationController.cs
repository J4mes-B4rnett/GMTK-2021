using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator rabbitAnim;
    public Animator turtleAnim;
    public Controller baseController;
    //enum declaration
    public enum RabbitState { idle, walk, jump, burrow }
    public enum TurtleState { idle, walk, climb }
    public enum Layer { Rabbit, Turtle }

    //enum initialization
    public RabbitState rabbitState = RabbitState.idle;
    public TurtleState turtleState = TurtleState.idle;
    public Layer layer;
    
    void Start()
    {
        layer = baseController.animal == Controller.Animal.Rabbit ? Layer.Rabbit : Layer.Turtle;
    }

    
    public void UpdateState()
    {
        if(layer == Layer.Rabbit)
        {
            rabbitAnim.enabled = true;
            turtleAnim.enabled = false;

            switch (rabbitState)
            {
                case RabbitState.idle:
                    rabbitAnim.SetInteger("State", 0);
                    break;
                case RabbitState.walk:
                    rabbitAnim.SetInteger("State", 1);
                    break;
                case RabbitState.jump:
                    rabbitAnim.SetInteger("State", 2);
                    break;
                case RabbitState.burrow:
                    rabbitAnim.SetInteger("State", 3);
                    break;
            }
        } else
        {
            rabbitAnim.enabled = false;
            turtleAnim.enabled = true;
            switch (turtleState)
            {
                case TurtleState.idle:
                    turtleAnim.SetInteger("State", 0);
                    break;
                case TurtleState.walk:
                    turtleAnim.SetInteger("State", 1);
                    break;
                case TurtleState.climb:
                    turtleAnim.SetInteger("State", 2);
                    break;
            }
        }
    }
}
