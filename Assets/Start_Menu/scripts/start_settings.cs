using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class start_settings : MonoBehaviour
{
    public void OnPointerDown()
    {
    SceneManager.LoadScene("Settings");
    }
    public void OnPointerClose()
    {
    Application.Quit();
    //Debug.Log("Exit");
    }
    public void OnPointerStart()
    {
    //SceneManager.LoadScene("Settings");
    }
}
