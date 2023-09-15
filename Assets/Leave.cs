using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    // Start is called before the first frame update
    public void LeaveGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
