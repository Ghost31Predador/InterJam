using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            load();
        }
    }
    void load()
    {
        SceneManager.LoadScene(1);
    }
}