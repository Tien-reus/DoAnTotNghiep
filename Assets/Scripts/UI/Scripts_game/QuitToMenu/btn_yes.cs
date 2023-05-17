using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_yes : MonoBehaviour
{
    public void yes()
    {
        SceneManager.LoadScene(0);
    }
}
