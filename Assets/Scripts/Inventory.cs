using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] items; // Array para almacenar los objetos del inventario
    private int currentItemIndex = 0; // �ndice del objeto actualmente seleccionado

    void Update()
    {
        // Cambiar de objeto en el inventario con los n�meros 1, 2 y 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeItem(2);
        }
    }

    void ChangeItem(int index)
    {
        // Verificar si el �ndice es v�lido y si el objeto en ese �ndice existe
        if (index >= 0 && index < items.Length && items[index] != null)
        {

            // Desactivar el objeto actualmente seleccionado
            if (items[currentItemIndex] != null)
            {
                items[currentItemIndex].SetActive(false);
            }

            // Activar el nuevo objeto seleccionado
            items[index].SetActive(true);

            // Actualizar el �ndice del objeto actualmente seleccionado
            currentItemIndex = index;
        }
    }


}
