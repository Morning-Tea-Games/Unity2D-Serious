using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEffect : MonoBehaviour
{
    public GameObject originalImage;      
    public GameObject pressedEffectImage;

    public string sceneName;


    public void OnClick()
    {


        if (originalImage != null)
            originalImage.SetActive(false); 

        if (pressedEffectImage != null)
            pressedEffectImage.SetActive(true); 

        Invoke(nameof(LoadScene), 0.2f);
    }

        void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

