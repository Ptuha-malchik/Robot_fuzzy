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
        // дБХФЕМХЕ Й НАЗЕРС

        if ((l.To_target == "пнбмн") && (l.Distance_front == "дюкейн") && (l.Dist_to_target == "дюкейн")) { l.Speed = "ашярпн"; }
        if ((l.To_target == "пнбмн") && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме")) && (l.Dist_to_target == "япедме")) { l.Speed = "япедме"; }
        if ((l.To_target == "пнбмн") && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме") || (l.Distance_front == "акхгйн")) && (l.Dist_to_target == "акхгйн")) {l.Speed = "ледкеммн"; }
        if ((l.To_target == "пнбмн") && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме") || (l.Distance_front == "акхгйн")) && (l.Dist_to_target == "бокнрмсч")) { l.Speed = "ярно"; }

        //ОНБНПНРШ НР ОПЕОЪРЯРБХИ
        if ((l.To_target == "пнбмн") && (l.Distance_front == "акхгйн") && ((l.Distance_left == "дюкейн") || ((l.Distance_left == "япедме")))) { l.Degree = "кебее"; }
        if ((l.To_target == "пнбмн") && (l.Distance_front == "акхгйн") && ((l.Distance_right == "дюкейн") || ((l.Distance_right == "япедме")))) { l.Degree = "опюбее"; }

        //дБХФЕМХЕ ОН ОПЕОЪРЯРБХЪЛ
        if ((l.To_target == "кебее") && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме")) && (l.Distance_left == "акхгйн")) { l.Speed = "япедме"; }
        if ((l.To_target == "опюбее") && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме")) && (l.Distance_right == "акхгйн")) { l.Speed = "япедме"; }

        //гЮБЕПЬЕМХЕ НАЗЕГДЮ
        if (((l.To_target == "кебее") || (l.To_target == "яхкэмн кебее")) && ((l.Distance_left == "дюкейн") || (l.Distance_left == "япедме"))) { l.Degree = "кебее"; }
        if (((l.To_target == "опюбее") || (l.To_target == "яхкэмн опюбее")) && ((l.Distance_right == "дюкейн") || (l.Distance_right == "япедме"))) { l.Degree = "опюбее"; }

        //гЮУНД МЮ ЦКХЯЯЮДС
        if (((l.To_target == "кебее") || (l.To_target == "пнбмн")) && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме"))) { l.Speed = "япедме"; }
        if (((l.To_target == "опюбее") || (l.To_target == "пнбмн")) && ((l.Distance_front == "дюкейн") || (l.Distance_front == "япедме"))) { l.Speed = "япедме"; }

        //бШПЮБМХБЮМХЕ МЮ ЦКХЯЯЮДС
        //if ((l.To_target == "кебее") || ()) 

        /*
        if ((l.To_target == "пнбмн") && (l.Distance_front == "акхгйн") && (l.Distance_left == "дюкейн")) 
            {
            l.Degree = "яхкэмн опюбее";
                if ((l.To_target == "кебее") && (l.Distance_front == "дюкейн") && (l.Distance_left == "акхгйн")) { l.Speed = "ашярпн";}
            }
        if ((l.To_target == "кебее") && (l.Distance_front == "дюкейн")) { l.Degree = "кебее"; }
        if ((l.To_target == "опюбее") && (l.Distance_front == "дюкейн")) { l.Degree = "опюбее"; }
        if ((l.To_target == "яхкэмн опюбее") && (l.Distance_left == "дюкейн")) { l.Degree = "яхкэмн опюбее"; } else if (l.Distance_front == "дюкейн") { l.Speed = "япедме"; }
        if ((l.To_target == "яхкэмн кебее") && (l.Distance_right == "дюкейн")) { l.Degree = "яхкэмн кебее"; } else if (l.Distance_front == "дюкейн") { l.Speed = "япедме"; }
        */
    }
}
