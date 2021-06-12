using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int startValue;
    public int currentValue { get; private set; }

    void Start()
    {
        currentValue = startValue;
    }


    void check()
    {
        if(currentValue <= 0)
        {
            //Die
        }
    }
    
    public void ChangeValue(int delta)
    {
        currentValue += delta;
        check();
    }
}
