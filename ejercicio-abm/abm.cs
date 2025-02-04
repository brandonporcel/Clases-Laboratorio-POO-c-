﻿using System;
using System.Collections.Generic;

namespace abm
{
    class Persona
    {
        private string apellido;
        private DateTime fechaDeNaciemiento;
        public string Apellido
        {
            set
            {
                this.apellido = value;
            }

            get
            {
                return this.apellido;
            }
        }


        public DateTime FechaDeNacimiento
        {
            get
            {
                return this.fechaDeNaciemiento;
            }
        }
        public int CantidadDeAnios
        {
            get
            {
                return cantidadDeAnios();
            }
        }


        public Persona(string apellido, DateTime fechaNac)
        {
            this.apellido = apellido;
            this.fechaDeNaciemiento = fechaNac;
        }

        private int cantidadDeAnios()
        {
            return DateTime.Today.AddTicks(-fechaDeNaciemiento.Ticks).Year - 1;
        }
    }
    class Program
    {
        static List<Persona> listaDePersonas = new List<Persona>();
        static void Main(string[] args)
        {

            listaDePersonas.Add(new Persona("Tarantino", new DateTime(1963, 01, 01)));
            listaDePersonas.Add(new Persona("Porcel", new DateTime(2004, 06, 14)));
            listaDePersonas.Add(new Persona("Pizarnik", new DateTime(1936, 01, 01)));

            string userText;
            Console.Write("Presiona C si queres agregar a alguien\nPresiona R si queres ver a los alguien\nPresiona U si queres modificar a alguien\nPresiona D si queres eliminar a alguien\nPresiona P si queres ver el promedio de edad\n\n\n");
            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    Console.Write("---------------------------------------\n");
                    if (consoleKey == ConsoleKey.C)
                    {
                        Console.Write("Escribí el Apellido de la persona que queres añadir\n");
                        userText = Console.ReadLine();
                        ; listaDePersonas.Add(new Persona(userText, new DateTime(2050, 01, 01)));
                    }
                    else if (consoleKey == ConsoleKey.R)
                    {

                        foreach (Persona persona in listaDePersonas)
                        {
                            Console.WriteLine("{0} tiene {1} años y nacio el {2}", persona.Apellido, persona.CantidadDeAnios, persona.FechaDeNacimiento);
                        }
                    }
                    else if (consoleKey == ConsoleKey.U)
                    {
                        Console.Write("Pone el Apellido del que queres actualizar.Lo cambiaremos por Maradona:\n");
                        userText = Console.ReadLine();
                        listaDePersonas.Find(x => x.Apellido == userText).Apellido = "Maradona";
                    }
                    else if (consoleKey == ConsoleKey.D)
                    {
                        Console.Write("Pone el Apellido del que queres eliminar:\n");
                        userText = Console.ReadLine();
                        listaDePersonas.RemoveAll(p => p.Apellido == userText);

                    }
                    else if (consoleKey == ConsoleKey.P)
                    {
                        int suma = 0;
                        foreach (Persona persona in listaDePersonas)
                        {
                            suma += persona.CantidadDeAnios;
                        }
                        suma /= listaDePersonas.Count;
                        Console.Write("El promedio de edad es de {0} anios\n", suma);
                    }
                    else
                    {
                        Console.Write("- Tocaste otra tecla. Mira el top de la consola -\n");

                    }
                }
            }
        }
    }

}