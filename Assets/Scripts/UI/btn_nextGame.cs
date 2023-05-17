using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_nextGame : MonoBehaviour
{
    public void btn_NextGame()
    {
        SceneManager.LoadScene(3);
    }
}
