using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeathZone : MonoBehaviour
{
    public bool harmsTurtle = true;
    public bool harmsRabbit = true;
    public SceneTransitionController sCT;
    void Start()
    {
        sCT = GameObject.Find("Game Manager").GetComponent<SceneTransitionController>();
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (harmsRabbit && collision.name == "Rabbit") { sCT.RestartButton(); }
        if (harmsTurtle && collision.name == "Turtle") { sCT.RestartButton(); }
    }
}
