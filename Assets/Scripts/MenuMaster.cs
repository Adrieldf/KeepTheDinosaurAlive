using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public void onClickPlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
