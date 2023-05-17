using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip_btn : MonoBehaviour
{
    public void btn_skip()
    {
        SceneManager.LoadScene(2);
    }
}