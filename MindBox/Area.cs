﻿namespace MindBox
{
    public class Area//можно наследовать и добавлять новые методы
    {
        //Is It Right?
        public static double Circle(double radius) => radius>=0?Math.PI * Math.Pow(radius, 2):throw new Exception("Radius must be >= 0!");

        public static double Triangle(double side1, double side2, double side3)
        {
            double p = (side1 + side2 + side3)/2;

            double[] sides = { side1, side2, side3 };
            Array.Sort(sides);

            if (sides[0]<0||sides[2] > sides[0] + sides[1])
                throw new Exception("Wrong sides!");

            if (sides[2] == Math.Sqrt(sides[0] * sides[0] + sides[1] * sides[1]))
                Console.WriteLine("It is right triangle!");
 
            return Math.Sqrt(p*(p-side1)*(p-side2)*(p-side3));
        }

        //[[x1, y1], [x2, y2], [x3, y3]...] и фигура не должна быть самопересекающейся.
        //Я мог бы скопировать алгоритм проверки на самопересечение откуда-то, но вдруг решите, что я не добросовестный или еще чего.
        //Методом сравнения отрезка с другими я бы и сам сделал открыв формулы, но для тестового задания уж слишком много усилий бы приложил :D
        public static double Gauss(double[,] crds)
        {
            int n1 = crds.GetLength(0);
            int n2 = crds.GetLength(1);

            if (n1  < 3)
                throw new Exception("Length of coordinates array must be >=3");

            if (n2 != 2)
                throw new Exception("It takes only XY coordinates!");

            double lace1 = 0;
            double lace2 = 0;

            for( int i = 0; i < n1 - 1; i++)
            {
                lace1 += lace1 + crds[i,0] * crds[i + 1, 1];
                lace2 += lace2 + crds[i,1] * crds[i + 1, 0];
            }

            return Math.Abs(lace1 - lace2)/2;
        }

        //Or this?
        public static double GetArea(double radius) => Circle(radius);
        public static double GetArea(double side1, double side2, double side3) => Triangle(side1, side2, side3);
        public static double GetArea(double[,] crds) => Gauss(crds);
    }
}

/*
    SELECT "Product"."name", "Categories"."name" 
    FROM Products AS "Product"
    LEFT JOIN Categories AS "Categories" ON "Product"."category_id" = "Categories"."id";
 */