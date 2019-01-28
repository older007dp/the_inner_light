using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationExit : MonoBehaviour
{
    [SerializeField] private Button ExitButton;
    private void Awake()
    {
        ExitButton.onClick.AddListener(ApplicationQuit);
    }

    private void ApplicationQuit()
    {
        Application.Quit();
    }
}
