using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VersMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("Menu");
           
        }

    }
}
