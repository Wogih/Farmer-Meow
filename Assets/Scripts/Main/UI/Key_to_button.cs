using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_to_button : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(keyCode)) button.onClick.Invoke();
    }
}
