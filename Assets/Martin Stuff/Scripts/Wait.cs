using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Wait : MonoBehaviour
{
    public float wait_time = 130;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait_for_intro()); 
    }

    private IEnumerator Wait_for_intro()
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(1);
    }
}
