using UnityEngine;

public class ChangeControl : MonoBehaviour
{
    public Controller.Animal selectedAnimal;
    public GameObject Rabbit;
    public GameObject Turtle;
    private void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            SwapAnimals();
        }
    }
    void SwapAnimals()
    {
        if (selectedAnimal == Controller.Animal.Rabbit) { selectedAnimal = Controller.Animal.Turtle; ApplySelected(); return; }
        if (selectedAnimal == Controller.Animal.Turtle) { selectedAnimal = Controller.Animal.Rabbit; ApplySelected(); return; }
    }
    void ApplySelected()
    {
        if(selectedAnimal == Controller.Animal.Rabbit)
        {
            Rabbit.GetComponent<Controller>().isActive = true;

            Turtle.GetComponent<Controller>().isActive = false;
            return;
        }
        if (selectedAnimal == Controller.Animal.Turtle)
        {
            Turtle.GetComponent<Controller>().isActive = true;

            Rabbit.GetComponent<Controller>().isActive = false;
            return;
        }
    }
}
