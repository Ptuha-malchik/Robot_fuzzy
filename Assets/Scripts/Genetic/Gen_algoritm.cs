using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_algoritm : MonoBehaviour
{
    // Создает особей и ведет отбор и мутации

 /*
    public double[,] Genetic(double x1, double x2, double x3, double y1, double y2, double y3, double z1, double z2, double z3)
    {
        double Dist_1 = Math.Sqrt((Form1.M_P1_x - Form1.P_Obj_x) * (Form1.M_P1_x - Form1.P_Obj_x) + (Form1.M_P1_y - Form1.P_Obj_y) * (Form1.M_P1_y - Form1.P_Obj_y));
        double Dist_2 = Math.Sqrt((Form1.M_P2_x - Form1.P_Obj_x) * (Form1.M_P2_x - Form1.P_Obj_x) + (Form1.M_P2_y - Form1.P_Obj_y) * (Form1.M_P2_y - Form1.P_Obj_y));
        double Dist_3 = Math.Sqrt((Form1.M_P3_x - Form1.P_Obj_x) * (Form1.M_P3_x - Form1.P_Obj_x) + (Form1.M_P3_y - Form1.P_Obj_y) * (Form1.M_P3_y - Form1.P_Obj_y));

        double[] time = new double[3];
        time[0] = Dist_1 / Form1.Speed_sig;
        time[1] = Dist_2 / Form1.Speed_sig;
        time[2] = Dist_3 / Form1.Speed_sig;

        double[,] Gold_population = new double[5, 7];

        //double delta_time_1 = 
        //Array.Sort(time);

        double d12 = (time[0] - time[1]) * 1500;
        double d23 = (time[1] - time[2]) * 1500;


        double[] position_x = { x1, x2, x3 };
        double[] position_y = { y1, y2, y3 };
        //double[] position_x = { 140, 160, 160 };
        //double[] position_y = { 100, 90, 110 };
        Array.Sort(position_x);
        Array.Sort(position_y);
        Random rnd = new Random();


        int POPULATION_SIZE = 200;          // количество индивидуумов в популяции
        float Mutation_pr = 0f;          // шанс мутации
        int MAX_GENERATIONS = 250;          //максимальное количество поколений


        double[,] population = new double[POPULATION_SIZE, 7];
        double[,] next_population = new double[POPULATION_SIZE, 7];
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            double x = rnd.NextDouble() * (position_x[2] - position_x[0]) + position_x[0];
            double y = rnd.NextDouble() * (position_y[2] - position_y[0]) + position_y[0];
            double uv_x = -1f + (rnd.NextDouble() * 2.0f);
            double uv_y = -1f + (rnd.NextDouble() * 2.0f);
            population[i, 0] = x;
            population[i, 1] = y;
            population[i, 2] = uv_x;
            population[i, 3] = uv_y;
        }



        for (int i = 0; i < MAX_GENERATIONS; i++)
        {

            // Вычисление пригодности
            double obr_koeff = 0;
            for (int j = 0; j < POPULATION_SIZE; j++)
            {
                double buff = function(population[j, 0], x1, x2, x3, population[j, 1], y1, y2, y3, 0, z1, z2, z3, d12, d23);
                population[j, 4] = buff;
                obr_koeff += 1 / population[j, 4];

                population[j, 5] = 0;

                next_population[j, 0] = 1000;
                next_population[j, 1] = 1000;
                next_population[j, 2] = 0;
                next_population[j, 3] = 0;
                next_population[j, 4] = 1000;
                next_population[j, 5] = 0;
                next_population[j, 6] = 0;

            }


            population = sort_genetic(population);
            for (int j = 0; j < POPULATION_SIZE; j++)
            {
                population[j, 6] = 1 / population[j, 4] / obr_koeff;
            }



            population = sort_genetic(population);

            for (int j = 0; j < 5; j++)
            {
                Gold_population[j, 0] = population[j, 0];
                Gold_population[j, 1] = population[j, 1];
                Gold_population[j, 2] = population[j, 2];
                Gold_population[j, 3] = population[j, 3];
                Gold_population[j, 4] = population[j, 4];
                Gold_population[j, 5] = population[j, 5];
                Gold_population[j, 6] = population[j, 6];
            }


            // Скрещивание
            //population = sort_genetic(population);
            int pop_count = 0;
            for (int j = 0; j < POPULATION_SIZE; j++)
            {
                for (int k = 0; k < POPULATION_SIZE; k++)
                {
                    if ((j != k) && (next_population[j, 5] != 1) && (next_population[k, 5] != 1))
                    {

                        //byte[] b_x_father = BitConverter.GetBytes(population[j, 2]);
                        //byte[] b_y_father = BitConverter.GetBytes(population[j, 3]);

                        //byte[] b_x_mather = BitConverter.GetBytes(population[k, 2]);
                        //byte[] b_y_mather = BitConverter.GetBytes(population[k, 3]);
                        //byte[] child_x = new byte[8];
                        //byte[] child_y = new byte[8];

                        double proc = rnd.NextDouble();
                        if (population[j, 6] >= proc)
                        {
                            int rand = rnd.Next(0, 2);

                            if (rand == 0)
                            {


                                rand = rnd.Next(0, 4);
                                for (int s = 0; s < rand; s++)
                                {
                                    next_population[pop_count, s] = population[j, s];
                                }
                                for (int s = rand; s < 5; s++)
                                {
                                    next_population[pop_count, s] = population[k, s];
                                }
                            }
                            else
                            {
                                rand = rnd.Next(0, 4);
                                for (int s = 0; s < rand; s++)
                                {
                                    next_population[pop_count, s] = population[k, s];
                                }
                                for (int s = rand; s < 5; s++)
                                {
                                    next_population[pop_count, s] = population[j, s];
                                }
                            }


                            proc = rnd.NextDouble();
                            if (Mutation_pr >= proc)
                            {
                                next_population[pop_count, 2] += -1f + (rnd.NextDouble() * 2.0f);
                                next_population[pop_count, 3] += -1f + (rnd.NextDouble() * 2.0f);
                            }

                            next_population[pop_count, 0] = next_population[pop_count, 2] + population[pop_count, 0];
                            next_population[pop_count, 1] = next_population[pop_count, 3] + population[pop_count, 1];


                            pop_count += 1;
                            next_population[k, 5] = 1;
                            next_population[j, 5] = 1;
                        }

                    }
                }
            }
            //return population;


            for (int j = pop_count; j < POPULATION_SIZE; j++)
            {
                double x = rnd.NextDouble() * (position_x[2] - position_x[0]) + position_x[0];
                double y = rnd.NextDouble() * (position_y[2] - position_y[0]) + position_y[0];
                double uv_x = -1f + (rnd.NextDouble() * 2.0f);
                double uv_y = -1f + (rnd.NextDouble() * 2.0f);
                next_population[pop_count, 0] = x;
                next_population[pop_count, 1] = y;
                next_population[pop_count, 2] = uv_x;
                next_population[pop_count, 3] = uv_y;
                pop_count += 1;
            }


            for (int j = 0; j < POPULATION_SIZE; j++)
            {
                population[j, 0] = next_population[j, 0];
                population[j, 1] = next_population[j, 1];
                population[j, 2] = next_population[j, 2];
                population[j, 3] = next_population[j, 3];
                population[j, 4] = next_population[j, 4];
                population[j, 5] = next_population[j, 5];
            }

            for (int j = POPULATION_SIZE - 4; j < POPULATION_SIZE - 1; j++)
            {
                population[j, 0] = Gold_population[POPULATION_SIZE - j, 0];
                population[j, 1] = Gold_population[POPULATION_SIZE - j, 1];
                population[j, 2] = Gold_population[POPULATION_SIZE - j, 2];
                population[j, 3] = Gold_population[POPULATION_SIZE - j, 3];
                population[j, 4] = Gold_population[POPULATION_SIZE - j, 4];
                population[j, 5] = Gold_population[POPULATION_SIZE - j, 5];
            }
            pop_count = 0;

        }
        population = sort_genetic(population);
        return population;
    }
    public double[,] sort_genetic(double[,] mas)
    {
        double buff = 0;
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            for (int j = i + 1; j < mas.GetLength(0); j++)
            {
                if (mas[i, 4] > mas[j, 4])
                {
                    buff = mas[i, 0];
                    mas[i, 0] = mas[j, 0];
                    mas[j, 0] = buff;

                    buff = mas[i, 1];
                    mas[i, 1] = mas[j, 1];
                    mas[j, 1] = buff;

                    buff = mas[i, 2];
                    mas[i, 2] = mas[j, 2];
                    mas[j, 2] = buff;

                    buff = mas[i, 3];
                    mas[i, 3] = mas[j, 3];
                    mas[j, 3] = buff;

                    buff = mas[i, 4];
                    mas[i, 4] = mas[j, 4];
                    mas[j, 4] = buff;

                    buff = mas[i, 5];
                    mas[i, 5] = mas[j, 5];
                    mas[j, 5] = buff;

                    buff = mas[i, 6];
                    mas[i, 6] = mas[j, 6];
                    mas[j, 6] = buff;
                }
            }
        }

        return mas;
    }

    */
}
