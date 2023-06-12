using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Fuzzy_logic : MonoBehaviour
{
    public Transform target;
    public Move Move = new Move();
    public Lidar Lidar = new Lidar();

    // ������� ��������������

    public float[,] Speed_func =            {{-0.2f, -0.1f, 0.1f, 0.2f},    // ����
                                             {0, 2, 3, 4},                  // �������
                                             {3.5f, 5, 8, 10},              // ������
                                             {8.5f, 12, 15, 20}};           // ������

    public float[,] Dist_func =             {{0, 1.5f, 4f, 5},              // ������
                                             {4.5f, 6f, 9f, 10},            // ������
                                             {9.5f, 11, 50, 200}};          // ������

    public float[,] Dist_to_target_func =   {{0, 1.5f, 4f, 5},              // ��������
                                             {4.5f, 5f, 8f, 10},            // ������
                                             {9.5f, 11f, 20f, 30},          // ������
                                             {25f, 30, 50, 100}};           // ������

    public float[,] Deg_to_target_func =    {{-20, -18.5f, 18.5f, 20},      // �����
                                             {-18.5f, -25, -90, -100},      // �����
                                             {-95, -110, -170, -180},       // ������ �����
                                             {18.5f, 25, 90, 100},          // ������
                                             {95, 110, 170, 180}};          // ������ ������

    public float[,] Degree_func =           {{0, 0, 0, 0},                  // �����
                                             {-1, -1, -1, -1},              // �����
                                             {-2, -2, -2, -2},              // ������ �����
                                             {1, 1, 1, 1},                  // ������
                                             {2, 2, 2, 2}};                 // ������ ������
    // ����������
    private static string Speed_stop_name = "����";
    private static string Speed_low_name = "��������";
    private static string Speed_medium_name = "������";
    private static string Speed_fast_name = "������";

    private static string Distance_low_name = "������";
    private static string Distance_med_name = "������";
    private static string Distance_high_name = "������";

    private static string To_target_norm = "�����";
    private static string To_target_left = "�����";
    private static string To_target_more_left = "������ �����";
    private static string To_target_right = "������";
    private static string To_target_more_right = "������ �����";

    private static string Distance_to_target_stop_name = "��������";
    private static string Distance_to_target_low_name = "������";
    private static string Distance_to_target_med_name = "������";
    private static string Distance_to_target_high_name = "������";
    // ������� ���������

    // ����������
    public string Speed = "����";
    public string Degree = "�����";// �������� ���� (����������)


    // ���������� ������
    public string Distance_left = "������";
    public string Distance_right = "������";
    public string Distance_front = "������";
    public string To_target = "�����";
    public string Dist_to_target = "������";

    private void FixedUpdate()
    {
        Update_Move();
        Update_param();
        
    }

    private void Update_Move()
    {
        
        if (Speed == "����") Move.speed = (Speed_func[0, 1]+ Speed_func[0, 2])/2;
        if (Speed == "��������") Move.speed = (Speed_func[1, 1] + Speed_func[1, 2]) / 2;
        if (Speed == "������") Move.speed = (Speed_func[2, 1] + Speed_func[2, 2]) / 2;
        if (Speed == "������") Move.speed = (Speed_func[3, 1] + Speed_func[3, 2]) / 2;
        

        if (Degree == "�����") Move.degree = (Degree_func[0, 1] + Degree_func[0, 2]) / 2;
        if (Degree == "�����") Move.degree = (Degree_func[1, 1] + Degree_func[1, 2]) / 2;
        if (Degree == "������ �����") Move.degree = (Degree_func[2, 1] + Degree_func[2, 2]) / 2;
        if (Degree == "������") Move.degree = (Degree_func[3, 1] + Degree_func[3, 2]) / 2;
        if (Degree == "������ ������") Move.degree = (Degree_func[3, 1] + Degree_func[3, 2]) / 2;

    }

    public float Rules_y(float[] x_m, float x)
    {
        float y = 0;
        if (x >= 0)
        {
            if ((x >= x_m[0]) && (x <= x_m[1])) y = (x - x_m[0]) / (x_m[1] - x_m[0]);
            if ((x > x_m[1]) & (x <= x_m[2])) y = 1;
            if ((x > x_m[2]) & (x <= x_m[3])) y = (x_m[3] - x) / (x_m[3] - x_m[2]);
        }
        else
        {
            if ((x <= x_m[0]) && (x >= x_m[1])) y = (x - x_m[0]) / (x_m[1] - x_m[0]);
            if ((x < x_m[1]) & (x >= x_m[2])) y = 1;
            if ((x < x_m[2]) & (x >= x_m[3])) y = (x_m[3] - x) / (x_m[3] - x_m[2]);
        }

        return y;
    }

    public void Update_param()
    {
        // ������� �������������� �������� ��� ����������� ����������
        float y_speed_stop = Rules_y(Get_rows(Speed_func, 0), Move.speed);
        float y_speed_low = Rules_y(Get_rows(Speed_func, 1), Move.speed);
        float y_speed_medium = Rules_y(Get_rows(Speed_func, 2), Move.speed);
        float y_speed_fast = Rules_y(Get_rows(Speed_func, 3), Move.speed);

        float[] mass_speed = { y_speed_stop, y_speed_low, y_speed_medium, y_speed_fast };
        Array.Sort(mass_speed);

        if (y_speed_stop == mass_speed[3]) Speed = Speed_stop_name;
        if (y_speed_low == mass_speed[3]) Speed = Speed_low_name;
        if (y_speed_medium == mass_speed[3]) Speed = Speed_medium_name;
        if (y_speed_fast == mass_speed[3]) Speed = Speed_fast_name;

        // ������� ��������� ��� ����������� ����������
        // �����
        float y_dist_low = Rules_y(Get_rows(Dist_func, 0), Lidar.left_dist);
        float y_dist_med = Rules_y(Get_rows(Dist_func, 1), Lidar.left_dist);
        float y_dist_hig = Rules_y(Get_rows(Dist_func, 2), Lidar.left_dist);
        float[] mass_dist_l = { y_dist_low, y_dist_med, y_dist_hig};
        Array.Sort(mass_dist_l);
        if (y_dist_low == mass_dist_l[2]) Distance_left = Distance_low_name;
        if (y_dist_med == mass_dist_l[2]) Distance_left = Distance_med_name;
        if (y_dist_hig == mass_dist_l[2]) Distance_left = Distance_high_name;

        // ������
        y_dist_low = Rules_y(Get_rows(Dist_func, 0), Lidar.right_dist);
        y_dist_med = Rules_y(Get_rows(Dist_func, 1), Lidar.right_dist);
        y_dist_hig = Rules_y(Get_rows(Dist_func, 2), Lidar.right_dist);
        float[] mass_dist_r = { y_dist_low, y_dist_med, y_dist_hig };
        Array.Sort(mass_dist_r);
        if (y_dist_low == mass_dist_r[2]) Distance_right = Distance_low_name;
        if (y_dist_med == mass_dist_r[2]) Distance_right = Distance_med_name;
        if (y_dist_hig == mass_dist_r[2]) Distance_right = Distance_high_name;

        // �����
        y_dist_low = Rules_y(Get_rows(Dist_func, 0), Lidar.forward_dist);
        y_dist_med = Rules_y(Get_rows(Dist_func, 1), Lidar.forward_dist);
        y_dist_hig = Rules_y(Get_rows(Dist_func, 2), Lidar.forward_dist);
        float[] mass_dist_f = { y_dist_low, y_dist_med, y_dist_hig };
        Array.Sort(mass_dist_f);
        if (y_dist_low == mass_dist_f[2]) Distance_front = Distance_low_name;
        if (y_dist_med == mass_dist_f[2]) Distance_front = Distance_med_name;
        if (y_dist_hig == mass_dist_f[2]) Distance_front = Distance_high_name;


        // ���������� �� ����
        float _dist_to_traget = Vector3.Distance(target.position, Lidar.transform.position);
        float y_dist_s = Rules_y(Get_rows(Dist_to_target_func, 0), _dist_to_traget);
        y_dist_low = Rules_y(Get_rows(Dist_to_target_func, 1), _dist_to_traget);
        y_dist_med = Rules_y(Get_rows(Dist_to_target_func, 2), _dist_to_traget);
        y_dist_hig = Rules_y(Get_rows(Dist_to_target_func, 3), _dist_to_traget);


        float[] mass_dist_to_target = { y_dist_s, y_dist_low, y_dist_med, y_dist_hig };
        Array.Sort(mass_dist_to_target);
        if (y_dist_s == mass_dist_to_target[3]) Dist_to_target = Distance_to_target_stop_name;
        if (y_dist_low == mass_dist_to_target[3]) Dist_to_target = Distance_to_target_low_name;
        if (y_dist_med == mass_dist_to_target[3]) Dist_to_target = Distance_to_target_med_name;
        if (y_dist_hig == mass_dist_to_target[3]) Dist_to_target = Distance_to_target_high_name;

    // ������� ����������� �� ���� ��� ����������� ����������
    //float angle = transform.eulerAngles.y;

    float angle = AngleAroundAxis(target.transform.forward, target.transform.position - transform.position, transform.up)-90f;
        if (angle < -180)
        {
            angle += 360;
        }


        //UnityEngine.Debug.Log(angle);

        float y_angle_norm = Rules_y(Get_rows(Deg_to_target_func, 0), angle);
        float y_angle_left = Rules_y(Get_rows(Deg_to_target_func, 1), angle);
        float y_angle_m_left = Rules_y(Get_rows(Deg_to_target_func, 2), angle);
        float y_angle_right = Rules_y(Get_rows(Deg_to_target_func, 3), angle);
        float y_angle_m_right = Rules_y(Get_rows(Deg_to_target_func, 4), angle);

        float[] mass_angle = { y_angle_norm, y_angle_left, y_angle_m_left, y_angle_right, y_angle_m_right };
        Array.Sort(mass_angle);

        if (y_angle_norm == mass_angle[4]) To_target = To_target_norm;
        if (y_angle_left == mass_angle[4]) To_target = To_target_left;
        if (y_angle_m_left == mass_angle[4]) To_target = To_target_more_left;
        if (y_angle_right == mass_angle[4]) To_target = To_target_right;
        if (y_angle_m_right == mass_angle[4]) To_target = To_target_more_right;


    }

    public float[] Get_rows(float[,] mass, int Row)
    {
        float[] result = new float[mass.GetLength(1)];
        for (int i = 0; i < mass.GetLength(1); i++) 
        {
            result[i] = mass[Row, i]; 
        }
        return result;
    }


    public void rules()
    {

    }


    public static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);
        float angle = Vector3.Angle(dirA, dirB);
        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
    }


}
