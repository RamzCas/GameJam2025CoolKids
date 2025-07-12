using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject ControlsPage;
    public GameObject StartScreen;
    public FirstPersonControls firstPersonControls;
    public GameObject tutorialPage;

    // Start is called before the first frame update
    void Start()
    {
        ControlsPage.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (ControlsPage.activeInHierarchy))
        {
            ControlsPage.SetActive(false);
        }
     
    }

    public void play()
    {
        SceneManager.LoadScene("layout");
    }

    public  void StartGame()
    {
        firstPersonControls.GameStart();
        tutorialPage.SetActive(true);
        StartCoroutine(Tutorial());
    }

    public IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(7f);
        tutorialPage.SetActive(false);
        StartScreen.SetActive(false);
    }
    public void Cont()
    {
        ControlsPage.SetActive(true);
    }

    public void ContClose()
    {
        ControlsPage.SetActive(false);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
