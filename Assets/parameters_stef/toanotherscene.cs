using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toanotherscene : MonoBehaviour
{
  public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGameScene1()
    {
        SceneManager.LoadScene("Settings");
    }
    public void LoadGameScene2()
    {
        SceneManager.LoadScene("Team");
    }
}
