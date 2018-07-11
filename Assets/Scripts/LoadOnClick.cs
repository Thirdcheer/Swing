using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public GameObject LoadingScreen;
    public GameObject BackgroundMusic;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setActive();
            Cursor.visible = true;
        }
    }


    public void loadScene(int level)
    {
        if (level == 10)
            Application.Quit();
        else
        {
            Cursor.visible = true;
            LoadingScreen.SetActive(true);
            Application.LoadLevel(level);
            Time.timeScale = 1.0F;
        }
    }

    public void setActive()
    {
        Time.timeScale = 0.0F;
        LoadingScreen.SetActive(true);
    }
    
    public void setActiveOnEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Time.timeScale = 0.0F;
            LoadingScreen.SetActive(true);
            Cursor.visible = true;
        }

    public void deactivate()
    {
        Cursor.visible = false;
        LoadingScreen.SetActive(false);
        Time.timeScale = 1.0F;
    }

    public void MusicMode()
    {
        if (BackgroundMusic.active == true)
            BackgroundMusic.SetActive(false);
   
        else
            BackgroundMusic.SetActive(true);
    }

}
