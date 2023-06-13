using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Lidar : MonoBehaviour
{
    public GameObject Lid;
    public GameObject Start_ray;
    public float Lidar_speed = 0;
    public float Point_min_distance = 0;
    public GameObject point_collect;
    public GameObject Point_Lidar;                  // Префаб токи от лидара

    public GameObject Laser_obj_forw;               // До точки луч
    public GameObject Laser_obj_right;              // До точки луч
    public GameObject Laser_obj_left;               // До точки луч
    public GameObject Laser_obj_45_left;            // До точки луч
    public GameObject Laser_obj_45_righ;            // До точки луч

    public float left_dist = 0;
    public float right_dist = 0;
    public float left_45_dist = 0;
    public float right_45_dist = 0;

    public float forward_dist = 0;

    private Vector3 rotationVector;
    private float degree_lidar = 0;


    public List<Vector3> Lidar_vect = new List<Vector3>(); // Позиции точек препятствий

    void FixedUpdate()
    {
        // Вращение
        rotationVector = new Vector3(0, degree_lidar, 0);
        Quaternion rotation = Quaternion.Euler(rotationVector);
        Lid.transform.rotation = Quaternion.Lerp(Lid.transform.rotation, rotation, 5.5f * Time.deltaTime);
        degree_lidar += Lidar_speed;
        if (degree_lidar >= 360)
        {
            degree_lidar = 0;
        }
        Dist_to_nav();
        // Получение показаний
        //Point_lidat();

    }

    private void Dist_to_nav()
    {
        
        RaycastHit hit;
        Ray ray = new Ray(Start_ray.transform.position, Start_ray.transform.right);
        Physics.Raycast(ray, out hit, 1000);
        if (hit.collider != null)
        {
            forward_dist = hit.distance;

            Vector3 center = (Start_ray.transform.position + hit.point) / 2;
            Laser_obj_forw.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - hit.point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - hit.point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - hit.point.z, 2)
            );
            Laser_obj_forw.transform.localScale = new Vector3(0.1f, spaceBetween/2, 0.1f);

        }
        else
        {
            forward_dist = 100;
            float angle = Start_ray.transform.eulerAngles.y;
            if (angle >= 360) angle -= 360;
            if (angle <= -360) angle += 360;
            angle *= Mathf.Deg2Rad;

            Vector3 end_point = new Vector3(Start_ray.transform.position.x + 100 * Mathf.Cos(angle), Start_ray.transform.position.y, Start_ray.transform.position.z - 100 * Mathf.Sin(angle));
            Vector3 center = (Start_ray.transform.position + end_point) / 2;
            Laser_obj_forw.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - end_point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - end_point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - end_point.z, 2)
            );
            Laser_obj_forw.transform.localScale = new Vector3(0.1f, spaceBetween/2, 0.1f);
        }
        
        ray = new Ray(Start_ray.transform.position, Start_ray.transform.forward*-1);
        Physics.Raycast(ray, out hit, 1000);
        if (hit.collider != null)
        {
            right_dist = hit.distance;

            Vector3 center = (Start_ray.transform.position + hit.point) / 2;
            Laser_obj_right.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - hit.point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - hit.point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - hit.point.z, 2)
            );
            Laser_obj_right.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);

        }
        else
        {
            right_dist = 100;
            float angle = Start_ray.transform.eulerAngles.y+90f;
            if (angle >= 360) angle -= 360;
            if (angle <= -360) angle += 360;
            angle *= Mathf.Deg2Rad;

            Vector3 end_point = new Vector3(Start_ray.transform.position.x + 100 * Mathf.Cos(angle), Start_ray.transform.position.y, Start_ray.transform.position.z - 100 * Mathf.Sin(angle));
            Vector3 center = (Start_ray.transform.position + end_point) / 2;
            Laser_obj_right.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - end_point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - end_point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - end_point.z, 2)
            );
            Laser_obj_right.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);
        }

        
        ray = new Ray(Start_ray.transform.position, Start_ray.transform.forward);
        Physics.Raycast(ray, out hit, 1000);
        if (hit.collider != null)
        {
            left_dist = hit.distance;

            Vector3 center = (Start_ray.transform.position + hit.point) / 2;
            Laser_obj_left.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - hit.point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - hit.point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - hit.point.z, 2)
            );
            Laser_obj_left.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);

        }
        else
        {
            left_dist = 100;
            float angle = Start_ray.transform.eulerAngles.y-90f;
            if (angle >= 360) angle -= 360;
            if (angle <= -360) angle += 360;
            angle *= Mathf.Deg2Rad;

            Vector3 end_point = new Vector3(Start_ray.transform.position.x + 100 * Mathf.Cos(angle), Start_ray.transform.position.y, Start_ray.transform.position.z - 100 * Mathf.Sin(angle));
            Vector3 center = (Start_ray.transform.position + end_point) / 2;
            Laser_obj_left.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - end_point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - end_point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - end_point.z, 2)
            );
            Laser_obj_left.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);
        }


        ray = new Ray(Start_ray.transform.position, (Start_ray.transform.forward + Start_ray.transform.right).normalized);
        Physics.Raycast(ray, out hit, 150);
        if (hit.collider != null)
        {
            left_45_dist = hit.distance;

            Vector3 center = (Start_ray.transform.position + hit.point) / 2;
            Laser_obj_45_left.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - hit.point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - hit.point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - hit.point.z, 2)
            );
            Laser_obj_45_left.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);

        }
        else
        {
            left_45_dist = 100;
            float angle = Start_ray.transform.eulerAngles.y - 45f;
            if (angle >= 360) angle -= 360;
            if (angle <= -360) angle += 360;
            angle *= Mathf.Deg2Rad;

            Vector3 end_point = new Vector3(Start_ray.transform.position.x + 100 * Mathf.Cos(angle), Start_ray.transform.position.y, Start_ray.transform.position.z - 100 * Mathf.Sin(angle));
            Vector3 center = (Start_ray.transform.position + end_point) / 2;
            Laser_obj_45_left.transform.position = center;
            Laser_obj_45_left.transform.localScale = new Vector3(0.1f, 50, 0.1f);
        }

        ray = new Ray(Start_ray.transform.position, (Start_ray.transform.forward - Start_ray.transform.right).normalized*-1);
        Physics.Raycast(ray, out hit, 150);
        if (hit.collider != null)
        {
            right_45_dist = hit.distance;

            Vector3 center = (Start_ray.transform.position + hit.point) / 2;
            Laser_obj_45_righ.transform.position = center;
            float spaceBetween = Mathf.Sqrt
            (
                Mathf.Pow(Start_ray.transform.position.x - hit.point.x, 2) +
                Mathf.Pow(Start_ray.transform.position.y - hit.point.y, 2) +
                Mathf.Pow(Start_ray.transform.position.z - hit.point.z, 2)
            );
            Laser_obj_45_righ.transform.localScale = new Vector3(0.1f, spaceBetween / 2, 0.1f);

        }
        else
        {
            right_45_dist = 100;
            float angle = Start_ray.transform.eulerAngles.y + 45f;
            if (angle >= 360) angle -= 360;
            if (angle <= -360) angle += 360;
            angle *= Mathf.Deg2Rad;

            Vector3 end_point = new Vector3(Start_ray.transform.position.x + 100 * Mathf.Cos(angle), Start_ray.transform.position.y, Start_ray.transform.position.z - 100 * Mathf.Sin(angle));
            Vector3 center = (Start_ray.transform.position + end_point) / 2;
            Laser_obj_45_righ.transform.position = center;
            Laser_obj_45_righ.transform.localScale = new Vector3(0.1f, 50, 0.1f);
        }

    }

    private void Point_lidat()
    {
        RaycastHit hit;
        Ray ray = new Ray(Lid.transform.position, Lid.transform.forward);
        Vector3 Lidar_posirion = Lid.transform.position;
        float angle = Lid.transform.eulerAngles.y + 90f;

        Physics.Raycast(ray, out hit, 150);
        if (hit.collider != null)
        {
            float Distance = hit.distance;
            //if (angle == 0) right_dist = Distance;
            //if (angle == 90) right_dist = Distance;
            //if (angle == 180) right_dist = Distance;

            if (angle >= 360) angle -= 360;
            if (angle <= -360)angle += 360;

            angle *= Mathf.Deg2Rad;

            Vector3 position = new Vector3(Lidar_posirion.x - Distance * Mathf.Cos(angle), Lidar_posirion.y, Lidar_posirion.z + Distance * Mathf.Sin(angle));
            if (Point_correct(position, Point_min_distance))
            {
                Lidar_vect.Add(position);
                Instantiate(Point_Lidar, position, Quaternion.identity).transform.SetParent(point_collect.transform);
            }
        }
    }
    private bool Point_correct(Vector3 pos_point, float dist)
    {
        for (int i = 0; i < Lidar_vect.Count; i++)
        {
            if (Vector2.Distance(new Vector2(Lidar_vect[i].x, Lidar_vect[i].z), new Vector2(pos_point.x, pos_point.z)) < dist)
            {
                return false;
            }
        }
        return true;
    }

}
