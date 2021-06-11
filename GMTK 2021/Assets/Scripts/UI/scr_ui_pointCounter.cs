using UnityEngine;
using TMPro;

public class scr_ui_pointCounter : MonoBehaviour {

    private TMP_Text UIText;

    public int points { get; set; }

    private void Start() {
        UIText = gameObject.GetComponent<TMP_Text>();
    }

    private void Update() {
        UIText.text = $"Points: {points}";
    }
}