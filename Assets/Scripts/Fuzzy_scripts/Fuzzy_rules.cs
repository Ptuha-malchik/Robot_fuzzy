using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy_rules : MonoBehaviour
{
    public Fuzzy_logic l = new Fuzzy_logic();

    private void FixedUpdate()
    {
        Rules();
    }

    private void Rules()
    {
        // пЮЯЯРНЪМХЪ
        
        if ((l.To_target == "пнбмн") && (l.Distance_front == "дюкейн")) { l.Speed = "ашярпн";}
        if ((l.To_target == "пнбмн") && (l.Distance_front == "акхгйн") && (l.Distance_left == "дюкейн")) 
            {
            l.Degree = "яхкэмн опюбее";
                if ((l.To_target == "кебее") && (l.Distance_front == "дюкейн") && (l.Distance_left == "акхгйн")) { l.Speed = "ашярпн";}
            }
        if ((l.To_target == "кебее") && (l.Distance_front == "дюкейн")) { l.Degree = "кебее"; }
        if ((l.To_target == "опюбее") && (l.Distance_front == "дюкейн")) { l.Degree = "опюбее"; }
        if ((l.To_target == "яхкэмн опюбее") && (l.Distance_left == "дюкейн")) { l.Degree = "яхкэмн опюбее"; } else if (l.Distance_front == "дюкейн") { l.Speed = "япедме"; }
        if ((l.To_target == "яхкэмн кебее") && (l.Distance_right == "дюкейн")) { l.Degree = "яхкэмн кебее"; } else if (l.Distance_front == "дюкейн") { l.Speed = "япедме"; }
        
    }
}
