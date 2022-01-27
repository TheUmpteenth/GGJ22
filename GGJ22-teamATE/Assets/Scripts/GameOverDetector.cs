using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name.Contains("GameOver"))
        {
            Debug.Log("GameOver");
        }
    }
}
