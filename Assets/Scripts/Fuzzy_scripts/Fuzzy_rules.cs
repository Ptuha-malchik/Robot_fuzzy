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
        //Разворот к цели
        
        if (((l.To_target == "ЛЕВЕЕ") || (l.To_target == "СИЛЬНО ЛЕВЕЕ")) && (l.Distance_front != "ТЕЛО")) { l.Degree = "ЛЕВЕЕ"; }
        if (((l.To_target == "ПРАВЕЕ") || (l.To_target == "СИЛЬНО ПРАВЕЕ")) && (l.Distance_front != "ТЕЛО")) { l.Degree = "ПРАВЕЕ"; }
        if (l.To_target == "РОВНО") { l.Degree = "РОВНО"; }

        //ПОДХОД К ПРЕПЯТСТВИЯМ
        if ((l.Distance_front != "ДАЛЕКО") && (l.Distance_45_left != "ДАЛЕКО")) { l.Speed = "СРЕДНЕ"; }
        if (l.Distance_front == "ТЕЛО") { l.Speed = "СТОП"; }

        //ПОПОРОТ ОТ ПРЕПЯТСВИЙ
        if ((l.Distance_front != "ДАЛЕКО") && (l.Distance_right != "БЛИЗКО")) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }
        if ((l.Distance_left == "БЛИЗКО") && (l.Distance_45_left == "БЛИЗКО")  ) { l.Degree = "ПРАВЕЕ"; }

        if ((l.Distance_front != "ДАЛЕКО") && (l.Distance_left  != "БЛИЗКО")) { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
        if ((l.Distance_left == "БЛИЗКО") && (l.Distance_45_right == "БЛИЗКО")) { l.Degree = "ЛЕВЕЕ"; }

        //Если вошли телом
        if ((l.Distance_right == "ТЕЛО") && (l.Distance_45_right == "ТЕЛО")) { l.Degree = "ЛЕВЕЕ"; l.Speed = "СРЕДНЕ"; }
        if ((l.Distance_left == "ТЕЛО") && (l.Distance_45_left == "ТЕЛО")) { l.Degree = "ПРАВЕЕ"; l.Speed = "СРЕДНЕ"; }

        //ОСТАВНОВКА
        if (l.Dist_to_target == "ВПЛОТНУЮ") { l.Speed = "СТОП"; l.Degree = "РОВНО"; }
          /*
          // Расстояния. Базовая проверка, много условий, но если они все совпадут, то робот поедет в направление цели и при удачном стечении он на ней оставноится

          if ((l.To_target == "РОВНО") && (l.Distance_front == "ДАЛЕКО") && (l.Dist_to_target == "ДАЛЕКО")) { l.Speed = "БЫСТРО"; l.Degree = "РОВНО"; }
              if ((l.To_target == "РОВНО") && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ")) && (l.Dist_to_target == "СРЕДНЕ")) { l.Speed = "СРЕДНЕ"; l.Degree = "РОВНО"; }
              if ((l.To_target == "РОВНО") && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ") || (l.Distance_front == "БЛИЗКО")) && (l.Dist_to_target == "БЛИЗКО")) { l.Speed = "МЕДЛЕННО"; l.Degree = "РОВНО"; }


              //повороты от препятствий. Если на предыдущем шаге мы уперлись в препядствие, а двигались мы в направление цели, делается проверка лево-право, и поворот осуществляется в свободное пространство
              if ((l.To_target == "РОВНО") && (l.Distance_front == "БЛИЗКО") && ((l.Distance_left == "ДАЛЕКО") || ((l.Distance_left == "СРЕДНЕ")))) { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
              if ((l.To_target == "РОВНО") && (l.Distance_front == "БЛИЗКО") && ((l.Distance_right == "ДАЛЕКО") || ((l.Distance_right == "СРЕДНЕ")))) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }

              //Движение по препятствиям. После заверщения предыдущего шага мы проходим по стенке, на это есть проверки близости к стене, проходим до тех пор, пока дистанция слева(справа в случае если поворот был на право) не будет похожа на проход
              if ((l.To_target == "ЛЕВЕЕ") && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ")) && (l.Distance_left == "БЛИЗКО")) { l.Speed = "СРЕДНЕ"; }
              if ((l.To_target == "ПРАВЕЕ") && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ")) && (l.Distance_right == "БЛИЗКО")) { l.Speed = "СРЕДНЕ"; }

              //Завершение объезда, поворачиваемся в проход и молимся, что мы сможем из него выйти и все работает так как я думаю
              if (((l.To_target == "ЛЕВЕЕ") || (l.To_target == "СИЛЬНО ЛЕВЕЕ")) && ((l.Distance_left == "ДАЛЕКО") || (l.Distance_left == "СРЕДНЕ"))) { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
              if (((l.To_target == "ПРАВЕЕ") || (l.To_target == "СИЛЬНО ПРАВЕЕ")) && ((l.Distance_right == "ДАЛЕКО") || (l.Distance_right == "СРЕДНЕ"))) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }

              //Заход на глиссаду. Термин из авиации, делаем вид что на прошлом этапе мы довернули в проход и все не пойдет по пизде, по этому мы едем в проход, и молимся и надеемся, что мы этих условий хватит на выход из прохода
              if (((l.To_target == "ЛЕВЕЕ") || (l.To_target == "РОВНО")) && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ"))) { l.Speed = "СРЕДНЕ"; }
              if (((l.To_target == "ПРАВЕЕ") || (l.To_target == "РОВНО")) && ((l.Distance_front == "ДАЛЕКО") || (l.Distance_front == "СРЕДНЕ"))) { l.Speed = "СРЕДНЕ"; }

          //ВЫравнивание на глиссаду. Тут делаем поворот, чтобы ту таргет стал ровно и мы вернулись к началу. т.е. петля должана замкнуться.

          if ((l.Distance_left == "БЛИЗКО") && ((l.To_target == "ЛЕВЕЕ") || (l.To_target == "СИЛЬНО ЛЕВЕЕ"))) { l.Degree = "СИЛЬНО ЛЕВЕЕ"; }
          if ((l.Distance_right == "БЛИЗКО") && ((l.To_target == "ПРАВЕЕ") || (l.To_target == "СИЛЬНО ПРАВЕЕ"))) { l.Degree = "СИЛЬНО ПРАВЕЕ"; }


          if ((l.Dist_to_target == "ВПЛОТНУЮ")) { l.Speed = "СТОП"; l.Degree = "РОВНО"; }*/
    }
}
