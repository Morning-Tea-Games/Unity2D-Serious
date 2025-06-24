using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toanotherscene : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("StartScene");
    }
 
}
