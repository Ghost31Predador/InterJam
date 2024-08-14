using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject[] menuOptions;
    private int currentOption = 0;

    void Update()
    {
        // Navegar por el menú con la palanca izquierda o la cruceta
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput < 0)
        {
            currentOption = (currentOption + 1) % menuOptions.Length;
            UpdateMenuSelection();
        }
        else if (verticalInput > 0)
        {
            currentOption = (currentOption - 1 + menuOptions.Length) % menuOptions.Length;
            UpdateMenuSelection();
        }

        // Seleccionar opción con el botón X
        if (Input.GetButtonDown("Submit"))
        {
            SelectOption();
        }

        // Retroceder con el botón O
        if (Input.GetButtonDown("Cancel"))
        {
            GoBack();
        }
    }

    void UpdateMenuSelection()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            menuOptions[i].SetActive(i == currentOption);
        }
    }

    void SelectOption()
    {
        // Aquí puedes agregar la lógica para cada opción del menú
        Debug.Log("Opción seleccionada: " + currentOption);
        // Ejemplo: cargar una escena
        // SceneManager.LoadScene("NombreDeLaEscena");
    }

    void GoBack()
    {
        // Aquí puedes agregar la lógica para retroceder en el menú
        Debug.Log("Retroceder en el menú");
        // Ejemplo: cargar una escena anterior
        // SceneManager.LoadScene("NombreDeLaEscenaAnterior");
    }
}
