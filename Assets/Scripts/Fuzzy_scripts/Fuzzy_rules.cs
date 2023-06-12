using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy_rules : MonoBehaviour
{
    public Fuzzy_logic l;

    private void FixedUpdate()
    {
        Rules();
    }

    private void Rules()
    {

        // Расстояния. Базовая проверка, много условий, но если они все совпадут, то робот поедет в направление цели и при удачном стечении он на ней оставноится
        /*
        if (l.To_target == "РОВНО") { l.Degree = "РОВНО"; }
        if (l.To_target == "ЛЕВЕЕ") { l.Degree = "ЛЕВЕЕ"; }
        if (l.To_target == "СИЛЬНО ЛЕВЕЕ") { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
        if (l.To_target == "ПРАВЕЕ") { l.Degree = "ПРАВЕЕ"; }
        if (l.To_target == "СИЛЬНО ПРАВЕЕ") { l.Degree = "СИЛЬНО ПРАВЕЕ"; }

        if (l.Distance_front == "ДАЛЕКО") { l.Speed = "БЫСТРО"; }
        if (l.Distance_front == "СРЕДНЕ") { l.Speed = "СРЕДНЕ"; }
        if (l.Distance_front == "БЛИЗКО") { l.Speed = "МЕДЛЕННО"; }

        if ((l.Distance_right == "СРЕДНЕ")) { l.Degree = "ЛЕВЕЕ"; }
        if ((l.Distance_left == "СРЕДНЕ")) { l.Degree = "ПРАВЕЕ"; }

        if ((l.Distance_right == "БЛИЗКО")) { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
        if ((l.Distance_left == "БЛИЗКО")) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }

        //if ((l.Distance_front == "БЛИЗКО") & (l.Distance_right == "ДАЛЕКО")) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }


        if (l.Dist_to_target == "ВПЛОТНУЮ") { l.Speed = "СТОП"; l.Degree = "РОВНО"; }
        */
    }
}
