using System.Collections;
using UnityEngine;
using TMPro;
public class PointSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI UIpointDisplay;
    public int startValue;
    int desiredValue;
    public int currentValue { get; private set; }


    void Start()
    {
        currentValue = startValue;
        desiredValue = startValue;
        UIpointDisplay.text = currentValue.ToString();
    }

    IEnumerator pointShift(int delta)
    {
        int direction = delta > 0 ? 1 : -1;
        while(delta != 0)
        {
            currentValue += 1 * direction;
            delta -= 1 * direction;
            UIpointDisplay.text = currentValue.ToString();
            yield return new WaitForSeconds(0.02f);
        }
        checkIfDead();
    }

    public void ChangePoints(int delta)
    {
        desiredValue += delta;
        StartCoroutine(pointShift(desiredValue-currentValue));
    }

    void checkIfDead()
    {
        if (currentValue <= 0)
        {
            //Die
        }
    }
}
