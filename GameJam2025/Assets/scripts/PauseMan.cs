using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMan : MonoBehaviour
{
    private bool IsPaused;
    private int escPressed;

    public GameObject PixelView;
    public GameObject Pausescreen;
    public GameObject Controlscreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        escPressed = 0;
    }

    private void Awake()
    {
        Pausescreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsPaused = false;
        Controlscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausescreen.SetActive(true);
            Controlscreen.SetActive(false );
            Time.timeScale = 0f;

            IsPaused = true;
            escPressed++;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
            if (escPressed >= 2 && IsPaused)
        {
            Pausescreen.SetActive(false);
            Controlscreen.SetActive(false );
            IsPaused = false;
            escPressed = 0;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Controlthings()
    {
        Controlscreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Controsl");
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
