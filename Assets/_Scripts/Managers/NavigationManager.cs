using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    [SerializeField] List<GameObject> screens;
    
    void Start()
    {
        ChangeScreenByIndex(0);
    }

    void Update()
    {
        DebugInput();
    }

    void DebugInput()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeScreenByIndex(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeScreenByIndex(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeScreenByIndex(2);
        }
    }

    public void ChangeScreenByIndex(int index)
    {
        if (index >= 0 && index < screens.Count)
        {
            for (int i = 0; i < screens.Count; i++)
            {
                screens[i].SetActive(i == index);
            }
        }
        else Debug.LogError("Índice fuera de los límites de la lista.");
    }
}
