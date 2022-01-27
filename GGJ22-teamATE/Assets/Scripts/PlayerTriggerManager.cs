
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name.Contains("GameOver"))
        {
            SceneManager.LoadScene("Scenes/GameOverScene");
        }
        else if (other.transform.name.Contains("Win"))
        {
            SceneManager.LoadScene("Scenes/WinScene");
        }
        else if (other.transform.name.Contains("Sided"))
        {
            var platform = other.transform.GetComponent<OneSidedPlatform>();
            var collider = GetComponent<CharacterController>();
            platform.DisablePassThrough(collider);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Contains("Sided"))
        {
            var platform = other.transform.GetComponent<OneSidedPlatform>();
            platform.EnablePassThrough(GetComponent<CharacterController>());
        }
    }
}
