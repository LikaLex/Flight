using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Flight
{
    class Flight
    {
      
        public string Name;
        public double Speed;
        public string AirFile;
        public double z;
        public double x;
        public double y;
        public Flight(string name, string file)
        {
            Name = name;
            x = 0;
            y = 0;
            z = 0;
            Speed = 0;
            AirFile = file;
        }
        public void Start()
        {
            Thread thread = new Thread(Flying);
            thread.Start();
        }
        public void State()
        {
            Console.WriteLine(Name + " heigh is " + z + ", coordinate x " + x + ", coordinate y " + y + ", current speed " + Speed + '\n');
        }
        public void MoveTo(double x1, double y1, double z1, double time)
        {
            double S = Math.Sqrt(((x1 - x) * (x1 - x)) + ((y1 - y) * (y1 - y)) + ((z1 - z) * (z1 - z)));
            Speed = S / time;
            Thread.Sleep((int)time * 1000);
            x = x1;
            y = y1;
            z = z1;
            State();
        }
        public void Flying()
        {
            State();

            using (FileStream filestream = new FileStream(AirFile, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(filestream))
                {
                    while (reader.Peek() != -1)
                    {
                        var airParams = reader.ReadLine().Split(',');
                        double time = (double)Int32.Parse(airParams[0]);
                        double x1 = (double)Int32.Parse(airParams[1]);
                        double y1 = (double)Int32.Parse(airParams[2]);
                        double z1 = (double)Int32.Parse(airParams[3]);
                        MoveTo(x1, y1, z1, time);

                    }
                }
            }

        }
    }
}
