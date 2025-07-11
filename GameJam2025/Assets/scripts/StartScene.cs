using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject Controls;

    // Start is called before the first frame update
    void Start()
    {
        Controls.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Controls.SetActive(false );
        }
    }

    public void play()
    {
        SceneManager.LoadScene("layout");
    }

    public void Cont()
    {
        Controls.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
