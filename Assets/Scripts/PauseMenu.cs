using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;

    public void activeMenu(int level)
    {
        pauseMenu.SetActive(true);
    }

}
