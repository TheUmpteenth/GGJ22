using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickSceneLoader : MonoBehaviour
{
    public string m_sceneToLoad;
    
    public void OnClick()
    {
        SceneManager.LoadScene(m_sceneToLoad);
    }
}
