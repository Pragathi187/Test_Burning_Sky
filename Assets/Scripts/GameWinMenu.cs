using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinMenu : MonoBehaviour
{
    public GameObject gamewinmenu;

    public void NextLevel()
    {

        SceneManager.LoadScene(2);
    }

}
