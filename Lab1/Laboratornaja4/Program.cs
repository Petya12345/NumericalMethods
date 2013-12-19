using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Laboratornaja4
{
    class Program
    {
        
        static void Main(string[] args) {
		    float right = 10;
		    PointF leftmost = new PointF(0,1);
		    float epsilon = (float)0.001;
		
		    List<PointF> f1 = analytical(leftmost.X, right, (float)0.1);
            List<PointF> f2 = analytical(leftmost.X, right, (float)0.01);
		
		    List<PointF> g1 = gear(leftmost, right, (float)0.1, epsilon);
            List<PointF> g2 = gear(leftmost, right, (float)0.01, epsilon);
		
		    float firstDiff = maxDiff(f1, g1);
		    float secondDiff = maxDiff(f2, g2);
		
		
		    Console.WriteLine("diff with h=0.1 and epsilon=" + epsilon + ": " + firstDiff);
            Console.WriteLine("diff with h=0.01 and epsilon=" + epsilon + ": " + secondDiff);

            Console.ReadKey();
	    }

        public static List<PointF> gear(PointF leftmost, float right, float h, float epsilon)
        {
            List<PointF> result = new List<PointF>();
            float previous;
            float current;
            float next;
            float correctedNext;
            float x = leftmost.X + h;
            previous = leftmost.Y;
            current = euler(previous, h);

            result.Add(new PointF(x, current));
            x += h;

            while (x < right)
            {
                correctedNext = prognose(current, h);
                do
                {
                    next = correctedNext;
                    correctedNext = correct(previous, current, next, h);
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

        public static float prognose(float current, float h)
        {
            return euler(current, h);
        }

        public static float correct(float previous, float current, float next, float h)
        {
            return 0;
            //return 4 / 3d * current - 1 / 3d * previous + 2 / 3d * h * function(next);
        }



        public static List<PointF> analytical(float left, float right, float h)
        {
            List<PointF> ty = new List<PointF>();
            float x = left + h;
            while (x < right)
            {
                ty.Add(new PointF(x, analyticalFunction(x)));
                x += h;
            }

            return ty;
        }

        public static float euler(float current, float h)
        {
            float next = current + h * function(current);
            return next;
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

        public static float maxDiff(List<PointF> f1, List<PointF> f2) {
		List<PointF> deltas = diff(f1, f2);
		float delta = 0;
		foreach(PointF p in deltas) {
			if(Math.Abs(p.Y) >= Math.Abs(delta))
				delta = Math.Abs(p.Y);
		}
		return delta;
	}




    public static float function(float x)
    {
        return (float)(0.25 * x - 0.05 * x * x);
    }

    public static float analyticalFunction(float t)
    {
        return (float)(0.5 * 0.25 * (float)Math.Pow(Math.E, 0.25 * t) / (0.25 + 0.05 * 0.5 * ((float)Math.Pow(Math.E, 0.25 * t) - 1)));
    }


        /*

        static void Main(string[] args)
        {
            float[] t = { 0, 40 };
            PointF leftmost = new PointF(0, 1);

            List<PointFF> f1 = analytical(t, 0.1);
            Console.Write("X = [");
            foreach (var y in f1.Select(f => f.X))
            {
                Console.Write(y + "\t");
            }
            Console.WriteLine("];");
            Console.Write("Y1 = [");
            foreach (var y in f1.Select(f => f.Y))
            {
                Console.Write(y + "\t");
            }
            Console.WriteLine("];");
            List<PointFF> f2 = analytical(t, 0.01);
            Console.Write("Y2 = [");
            foreach (var y in f2.Select(f => f.Y))
            {
                Console.Write(y + "\t");
            }
            Console.WriteLine("];");
            List<PointFF> e1 = euler(leftmost, t, 0.1);
            Console.Write("E1 = [");
            foreach (var y in e1.Select(f => f.Y))
            {
                Console.Write(y + "\t");
            }
            Console.WriteLine("];");
            List<PointFF> e2 = euler(leftmost, t, 0.01);
            Console.Write("E2 = [");
            foreach (var y in e2.Select(f => f.Y))
            {
                Console.Write(y + "\t");
            }
            Console.WriteLine("];");

            float firstDiff = maxDiff(f1, e1);

            float secondDiff = maxDiff(f2, e2);
        }


        public static List<PointFF> analytical(float[] t, float h)
        {
            List<PointFF> ty = new List<PointFF>();
            float x = t[0] + h;
            while (x < t[1])
            {
                ty.Add(new PointFF((float)x, (float)analyticalFunction(x)));
                x += h;
            }

            return ty;
        }

        public static List<PointFF> euler(PointF leftmost, float[] t, float h)
        {
            List<PointFF> ty = new List<PointFF>();
            float x = t[0] + h;
            float y = leftmost.Y;
            float nextY;
            while (x < t[1])
            {
                nextY = y + h * function(y);
                ty.Add(new PointFF((float)x, (float)nextY));
                x += h;
                y = nextY;
            }

            return ty;
        }

        public static List<PointFF> diff(List<PointFF> f1, List<PointFF> f2)
        {
            List<PointFF> diff = new List<PointFF>();
            float delta;
            for (int i = 0; i < f1.Count(); i++)
            {
                delta = f1[i].Y - f2[i].Y;
                diff.Add(new PointFF((float)f1[i].X, (float)delta));
            }
            return diff;
        }

        public static float maxDiff(List<PointFF> f1, List<PointFF> f2)
        {
            List<PointFF> deltas = diff(f1, f2);
            float delta = 0;
            for (int i = 0; i < deltas.Count; i++)
            {
                PointFF p = deltas[i];
                if (Math.Abs(p.Y) >= Math.Abs(delta))
                    delta = Math.Abs(p.Y);
            }
            return delta;
        }

         */

    }
}
