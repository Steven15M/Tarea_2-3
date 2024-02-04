using System;
using System.Threading.Channels;

//Steven Moscoso Acuña
//programacion ll
//Sistema de calculo de salarios
//tarea 2/3


internal class ProgramaSt
{
    private static void Main(string[] args)
    {
        string[] cedulas = new string[100];
        string[] nombres = new string[100];
        int[] tiposEmpleados = new int[100];
        double[] horasTrabajadas = new double[100];
        double[] preciosHora = new double[100];

        int totalUsuarios = 0;
        int opcion = 0;
        bool agregarUsuario = true;

        int cantidadOperarios = 0;
        double acumuladoSalarioNetoOperarios = 0;
        int cantidadTecnicos = 0;
        double acumuladoSalarioNetoTecnicos = 0;
        int cantidadProfesionales = 0;
        double acumuladoSalarioNetoProfesionales = 0;

        Console.WriteLine("______________________________________________");
        Console.WriteLine("........Sistema de calculo de salarios........");
        Console.WriteLine("______________________________________________");
        Console.WriteLine("");

        do
        {
            Console.WriteLine("Ingrese la cedula:");
            cedulas[totalUsuarios] = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre:");
            nombres[totalUsuarios] = Console.ReadLine();

            Console.WriteLine("Ingrese el tipo de empleado (1-Operario, 2-Tecnico, 3-Profesional):");
            tiposEmpleados[totalUsuarios] = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de horas de trabajo:");
            horasTrabajadas[totalUsuarios] = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el precio por hora:");
            preciosHora[totalUsuarios] = double.Parse(Console.ReadLine());
            //salario ordinario
            double salarioOrdinario = horasTrabajadas[totalUsuarios] * preciosHora[totalUsuarios];

            double aumento = 0;
            switch (tiposEmpleados[totalUsuarios])
            {
                case 1: // operarios
                    aumento = salarioOrdinario * 0.15;
                    cantidadOperarios++;
                    acumuladoSalarioNetoOperarios += salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917;
                    break;
                case 2:
                    aumento = salarioOrdinario * 0.10;
                    cantidadTecnicos++;
                    acumuladoSalarioNetoTecnicos += salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917;
                    break;
                case 3:
                    aumento = salarioOrdinario * 0.05;
                    cantidadProfesionales++;
                    acumuladoSalarioNetoProfesionales += salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917;
                    break;
            }
            double salarioBruto = salarioOrdinario + aumento;
            double deduccionCCSS = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccionCCSS;

            Console.WriteLine("\nDatos del usuario:");
            Console.WriteLine($"Cedula: {cedulas[totalUsuarios]}");
            Console.WriteLine($"Nombre: {nombres[totalUsuarios]}");
            Console.WriteLine($"tipo empleado: {tiposEmpleados[totalUsuarios]}");
            Console.WriteLine($"salario por hora: {preciosHora[totalUsuarios]}");
            Console.WriteLine($"cantidad de horas: {horasTrabajadas[totalUsuarios]}");
            Console.WriteLine($"salario ordinario: {salarioOrdinario}");
            Console.WriteLine($"Aumento: {aumento}");
            Console.WriteLine($"Salario bruto: {salarioBruto}");
            Console.WriteLine($"Deducción CCSS: {deduccionCCSS}");
            Console.WriteLine($"Salario neto: {salarioNeto}");

            totalUsuarios++;

            Console.WriteLine("Quieres añadir otro usuario? Si=1 No=2");
            opcion = int.Parse(Console.ReadLine());

            if (opcion != 1)
            {
                agregarUsuario = false;
            }

        } while (agregarUsuario);

        Console.WriteLine("\nEstadisticas:");
        Console.WriteLine($"Cantidad empleados operarios: {cantidadOperarios}");
        Console.WriteLine($"Acumulado salario neto para operarios: {acumuladoSalarioNetoOperarios}");
        Console.WriteLine($"Promedio salario neto para operarios: {(cantidadOperarios > 0 ? acumuladoSalarioNetoOperarios / cantidadOperarios : 0)}");
        Console.WriteLine($"Cantidad empleados tecnicos: {cantidadTecnicos}");
        Console.WriteLine($"Acumulado salario neto para Tecnicos: {acumuladoSalarioNetoTecnicos}");
        Console.WriteLine($"Promedio salario neto para tecnicos: {(cantidadTecnicos > 0 ? acumuladoSalarioNetoTecnicos / cantidadTecnicos : 0)}");
        Console.WriteLine($"Cantidad empleados tipo profesionales: {cantidadProfesionales}");
        Console.WriteLine($"Acumulado salario neto para profesionales: {acumuladoSalarioNetoProfesionales}");
        Console.WriteLine($"Promedio salario neto para profesionales: {(cantidadProfesionales > 0 ? acumuladoSalarioNetoProfesionales / cantidadProfesionales : 0)}");
        Console.WriteLine("");
        Console.WriteLine("______________________________________________");
        Console.WriteLine("...........Gracias, vualva pronto :)..........");
        Console.WriteLine("______________________________________________");
    }
}
