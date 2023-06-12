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

        // пЮЯЯРНЪМХЪ. аЮГНБЮЪ ОПНБЕПЙЮ, ЛМНЦН СЯКНБХИ, МН ЕЯКХ НМХ БЯЕ ЯНБОЮДСР, РН ПНАНР ОНЕДЕР Б МЮОПЮБКЕМХЕ ЖЕКХ Х ОПХ СДЮВМНЛ ЯРЕВЕМХХ НМ МЮ МЕИ НЯРЮБМНХРЯЪ
        
        if (l.To_target == "пнбмн") { l.Degree = "пнбмн"; }
        if (l.To_target == "кебее") { l.Degree = "кебее"; }
        if (l.To_target == "яхкэмн кебее") { l.Degree = "яхкэмн кебее"; }
        if (l.To_target == "опюбее") { l.Degree = "опюбее"; }
        if (l.To_target == "яхкэмн опюбее") { l.Degree = "яхкэмн опюбее"; }

        if (l.Distance_front == "дюкейн") { l.Speed = "ашярпн"; }
        if (l.Distance_front == "япедме") { l.Speed = "япедме"; }
        if (l.Distance_front == "акхгйн") { l.Speed = "ледкеммн"; }

        if ((l.Distance_right == "япедме")) { l.Degree = "кебее"; }
        if ((l.Distance_left == "япедме")) { l.Degree = "опюбее"; }

        if ((l.Distance_right == "акхгйн")) { l.Degree = "яхкэмн кебее"; }
        if ((l.Distance_left == "акхгйн")) { l.Degree = "яхкэмн опюбее"; }

        if ((l.Distance_45_right == "акхгйн")) { l.Degree = "яхкэмн кебее"; }
        if ((l.Distance_45_left == "акхгйн")) { l.Degree = "яхкэмн опюбее"; }
        //if ((l.Distance_front == "акхгйн") & (l.Distance_right == "дюкейн")) { l.Degree = "яхкэмн опюбее"; }


        if (l.Dist_to_target == "бокнрмсч") { l.Speed = "ярно"; l.Degree = "пнбмн"; }
        
    }
}
