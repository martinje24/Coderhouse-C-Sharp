﻿namespace EjemploDeClase
{
    class ProbarObjetos
    {
        static void Main(string[] args)
        {
            Cubo cubo = new Cubo(5);
            Rectangulo rectangulo = new Rectangulo(2,3);
            Circulo circulo = new Circulo(6);
            Console.WriteLine(circulo.Perimetro());
        }
    }

    public interface I2DMedidasCalculable
    {
        double Area();
        double Perimetro();
    }
    public interface I3DMedidasCalbulable
    {
        double Volumen();
    }

    public abstract class FiguraGeometrica
    {
        public abstract double Area();
    }

    public class Circulo : FiguraGeometrica, I2DMedidasCalculable
    {
        double radio;
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(this.radio, 2);
        }
        public double Perimetro()
        {
            return 2 * Math.PI * this.radio;
        }
    }

    public class Rectangulo : I2DMedidasCalculable
    {
        double base_r;
        double altura_r;

        public Rectangulo(double base_r, double altura_r)
        {
            this.base_r = base_r;
            this.altura_r = altura_r;
        }
        public double Area()
        {
            return this.base_r*this.altura_r;
        }
        public double Perimetro()
        {
            return 2 * this.base_r + 2 * this.altura_r;
        }
    }

    public class Cubo : I2DMedidasCalculable , I3DMedidasCalbulable
    {
        double lado;

        public Cubo(double lado)
        {
            this.lado = lado;
        }

        public double Area()
        {
            return 6*Math.Pow(this.lado,2);
        }
        public double Perimetro()
        {
            return 12*this.lado;
        }
        public double Volumen()
        {
            return Math.Pow(this.lado,3);
        }
    }
}