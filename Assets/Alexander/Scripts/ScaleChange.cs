using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    public GameObject CatChangeScale;
    public int MaxPoints;
    public int MinPoints;
    public Vector3 MaxScale;
    public Vector3 MinScale;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int ActualScore = ThisScore();

        ActualScore = Mathf.Clamp(ActualScore, MinPoints, MaxPoints);

        float t = (float)(ActualScore - MinPoints) / (MaxPoints - MinPoints);
        Vector3 newScale = Vector3.Lerp(MinScale, MaxScale, t);

        CatChangeScale.transform.localScale = newScale;


    }

    int ThisScore()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
             

            Debug.Log("La tecla Espacio ha sido presionada");
        }

        return 0;
    }
}
