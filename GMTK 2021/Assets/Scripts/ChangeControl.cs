using UnityEngine;

public class ChangeControl : MonoBehaviour
{
    public Controller.Animal selectedAnimal;
    public GameObject Rabbit;
    public GameObject Turtle;
    GameObject rabbitArrow;
    GameObject turtleArrow;
    private void Start()
    {
        rabbitArrow = Rabbit.transform.Find("Arrow").gameObject;
        turtleArrow = Turtle.transform.Find("Arrow").gameObject;
        SwapAnimals();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
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
            rabbitArrow.SetActive(true);

            Turtle.GetComponent<Controller>().isActive = false;
            turtleArrow.SetActive(false);
            return;
        }
        if (selectedAnimal == Controller.Animal.Turtle)
        {
            Turtle.GetComponent<Controller>().isActive = true;
            turtleArrow.SetActive(true);

            Rabbit.GetComponent<Controller>().isActive = false;
            rabbitArrow.SetActive(false);
            return;
        }
    }
}
