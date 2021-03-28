using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using OpenHardwareMonitor.Hardware;
using System.Threading;

namespace ConsoleTemp
{
    class Program
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }
            public void VisitParameter(IParameter parameter) { }
        }

        static int getCPUTemp()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();

            int cpuTemp = 0;

            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);

            foreach (var hardware in computer.Hardware)
            {
                hardware.Update();
                hardware.GetReport();

                foreach(var sensor in hardware.Sensors)
                {
                    if(sensor.SensorType == SensorType.Temperature)
                    {
                        if((int)sensor.Value > cpuTemp)
                        {
                            cpuTemp = (int)sensor.Value;
                        }  
                    }
                }
            }

            computer.Close();
            return cpuTemp;
        }

        static int getGPUTemp()
        {
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();

            int gpuTemp = 0;

            computer.Open();
            computer.GPUEnabled = true;
            computer.Accept(updateVisitor);

            foreach (var hardware in computer.Hardware)
            {
                hardware.Update();
                hardware.GetReport();

                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature)
                    {
                        gpuTemp = (int)sensor.Value;
                    }
                }
            }

            return gpuTemp;
        }

        static SerialPort port = new SerialPort();

        static void portInit()
        {
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Handshake = Handshake.None;
            port.RtsEnable = true;
            port.BaudRate = 9600;
        }

        static void Main(string[] args)
        {
            string userPort, interval;

            while (true)
            {
                Console.WriteLine("Enter port (ex. COMx): ");
                userPort = Console.ReadLine();
                //userPort = "COM3";

                Console.WriteLine("Enter interval: ");
                interval = Console.ReadLine();
                //interval = "500";

                portInit();

                try
                {
                    if (!port.IsOpen)
                    {
                        port.PortName = userPort;
                        port.Open();
                        Console.WriteLine("Connected to " + userPort);
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Port does not exist!");
                }
            }

            Console.WriteLine("Sending data...");

            while (true)
            {
                int temp1 = getCPUTemp();
                int temp2 = getGPUTemp();

                port.Write(temp1 + "c" + temp2 + "g");

                int val = Int32.Parse(interval);
                Thread.Sleep(val);
            }

            port.Write("s");
        }
    }
}
