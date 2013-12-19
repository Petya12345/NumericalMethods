using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Laboratornaja4
{
    class Program
    {

        public static float function(float x)
        {
            return (float)(0.25 * x - 0.05 * x * x);
        }

        public static float analyticalFunction(float t)
        {
            return (float)(0.5 * 0.25 * (float)Math.Pow(Math.E, 0.25 * t) / (0.25 + 0.05 * 0.5 * ((float)Math.Pow(Math.E, 0.25 * t) - 1)));
        }

        static void Main(string[] args)
        {
            float right = 40;
            PointF leftmost = new PointF(0, 0.5F);
            float epsilon = (float)0.001;
            float[] t = { 0, 40 };

            List<PointF> a1 = analytical(leftmost.X, right, (float)0.1);
            print("A1", a1);
            List<PointF> a2 = analytical(leftmost.X, right, (float)0.01);
            print("A2", a2);

            List<PointF> e1 = euler(leftmost, t, (float)0.1);
            print("E1", e1);
            List<PointF> e2 = euler(leftmost, t, (float)0.01);
            print("E2", e2);

            List<PointF> g1 = gear(leftmost, right, (float)0.1, epsilon);
            print("G1", g1);
            List<PointF> g2 = gear(leftmost, right, (float)0.01, epsilon);
            print("G2", g2);

            printDiff("ErrE1", a1, e1);
            printDiff("ErrE2", a2, e2);
            printDiff("ErrG1", a1, g1);
            printDiff("ErrG2", a2, g2);

            float firstDiff = maxDiff(a1, e1);
            float secondDiff = maxDiff(a2, e2);
            Console.WriteLine("Euler: diff with h=0.1 and epsilon=" + epsilon + ": " + firstDiff.ToString("0.00000000000000"));
            Console.WriteLine("Euler: diff with h=0.01 and epsilon=" + epsilon + ": " + secondDiff.ToString("0.00000000000000"));
            firstDiff = maxDiff(a1, g1);
            secondDiff = maxDiff(a2, g2);
            Console.WriteLine("Gears: diff with h=0.1 and epsilon=" + epsilon + ": " + firstDiff.ToString("0.00000000000000"));
            Console.WriteLine("Gears: diff with h=0.01 and epsilon=" + epsilon + ": " + secondDiff.ToString("0.00000000000000"));

            Console.ReadKey();
        }

        public static List<PointF> gear(PointF leftmost, float right, float h, float epsilon)
        {
            List<PointF> result = new List<PointF>();
            float previous;
            float current;
            float next;
            float correctedNext;
            result.Add(leftmost); //x(0)
            float x = leftmost.X + h;
            previous = leftmost.Y;
            current = previous + h * function(previous);

            result.Add(new PointF(x, current));
            x += h;

            while (x <= right)
            {
                correctedNext = current + h * function(current);
                do
                {
                    next = correctedNext;
                    correctedNext = (float)(4 / 3d * current - 1 / 3d * previous + 2 / 3d * h * function(next));
                } while (Math.Abs(correctedNext - next) > epsilon);
                next = correctedNext;

                result.Add(new PointF(x, next));
                x += h;

                // move all variables one step right
                previous = current;
                current = next;
            }

            return result;
        }


        public static List<PointF> analytical(float left, float right, float h)
        {
            List<PointF> ty = new List<PointF>();
            float x = left;
            while (x <= right)
            {
                ty.Add(new PointF(x, analyticalFunction(x)));
                x += h;
            }
            return ty;
        }

        public static List<PointF> diff(List<PointF> f1, List<PointF> f2)
        {
            List<PointF> diff = new List<PointF>();
            float delta;
            for (int i = 0; i < f1.Count(); i++)
            {
                delta = f1[i].Y - f2[i].Y;
                diff.Add(new PointF(f1[i].X, delta));
            }
            return diff;
        }

        public static float maxDiff(List<PointF> f1, List<PointF> f2)
        {
            List<PointF> deltas = diff(f1, f2);
            float delta = 0;
            foreach (PointF p in deltas)
            {
                if (Math.Abs(p.Y) >= Math.Abs(delta))
                    delta = Math.Abs(p.Y);
            }
            return delta;
        }


        public static List<PointF> euler(PointF leftmost, float[] t, float h)
        {
            List<PointF> ty = new List<PointF>();
            float x = t[0];
            float y = leftmost.Y;
            float nextY;
            while (x <= t[1])
            {
                nextY = y + h * function(y);
                ty.Add(new PointF((float)x, (float)nextY));
                x += h;
                y = nextY;
            }

            return ty;
        }

        static void print(string variable, List<PointF> points)
        {
            Console.Write(variable.ToUpper() + " = [");
            foreach (var y in points.Select(f => f.Y))
            {
                Console.Write(y.ToString("0.0000000000") + " ");
            }
            Console.WriteLine("];");
        }

        static void printDiff(string variable, List<PointF> p1, List<PointF> p2)
        {
            var err = new List<PointF>(p1.Count);
            for (int i = 0; i < p1.Count; i++)
            {
                err.Add(new PointF(p1[i].X, Math.Abs(p1[i].Y - p2[i].Y)));
            }
            print(variable, err);
        }
    }
}
