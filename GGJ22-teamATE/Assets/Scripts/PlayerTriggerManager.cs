
using UnityEngine;

public class PlayerTriggerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name.Contains("GameOver"))
        {
            Debug.Log("GameOver");
        }
        else if (other.transform.name.Contains("Win"))
        {
            Debug.Log("Nom nom nom (win)");
        }
        else if (other.transform.name.Contains("Sided"))
        {
            var platform = other.transform.GetComponent<OneSidedPlatform>();
            var collider = GetComponent<CharacterController>();
            platform.Deactivate(collider);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.name.Contains("Sided"))
        {
            var platform = other.transform.GetComponent<OneSidedPlatform>();
            platform.Activate(GetComponent<CharacterController>());
        }
    }
}
