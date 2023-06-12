using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gen : MonoBehaviour
{
    public Fuzzy_logic logic;
    // Описывает гены конкретного робота

    public List<float> Gen_vect = new List<float>(); // Позиции точек препятствий

    public void generate_genetic()
    {
        for (int i = 0; i < logic.Speed_func.Length; i++)
        {
            for(int j = 0; j<4; j++)
            {
                Gen_vect.Add(logic.Speed_func[i, j]);
            }

        }


    }

}
