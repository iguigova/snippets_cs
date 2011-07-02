using System;
using System.IO;
using System.Text;

namespace RegularPolygons
{
    class Broker
    {
        public void Process(string filename)
        {
            // Assumptions: 
            //  . ErrorHandling is not a priority and is reduced to a minimum
            //  . <filename> is a path to a well-formatted text file
            //  . Polygons are created sequentially and are in memory only long enough to output the required data
            StreamReader stream = new StreamReader(filename);
            try
            {
                string line;
                string[] tokens;
                while ((line = stream.ReadLine()) != null)
                {
                    tokens = line.Split(',');
                    Console.WriteLine((new RegularPolygonBroker(tokens[0], Convert.ToDouble(tokens[1])).ToString()));
                }
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
