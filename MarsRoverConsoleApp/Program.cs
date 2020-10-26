using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperation fileOps = new FileOperation();
            
            int length = args.Length;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Path:");
                Console.WriteLine(args[0]);
                string[] fileStr = fileOps.ReadFile(args[0]);
                int[] intArrOfMaxPoints = { 0, 0 };

                if (fileStr.Length > 0 && !string.IsNullOrEmpty(fileStr[0]))
                {
                    intArrOfMaxPoints = GetMaxPointOfArea(fileStr[0]);
                }

                Dictionary<int, string[]> marsRoverInfo = GetMarsRoverInfo(fileStr);


                StringBuilder strbuilder = new StringBuilder("");

                for (int i = 1; i <= marsRoverInfo.Count; i++)
                {
                    string[] tempInfoArray = marsRoverInfo[i];
                    CompassDirections roverCompassDirection = GetCompassDirectionFromLetter(tempInfoArray[2]);

                    MarsRover marsRover = new MarsRover(
                        Convert.ToInt32(tempInfoArray[0]),
                        Convert.ToInt32(tempInfoArray[1]),
                        roverCompassDirection,
                        intArrOfMaxPoints[0],
                        intArrOfMaxPoints[1]);
                    marsRover.ChangePosition(tempInfoArray[3]);

                    strbuilder.Append(marsRover.PositionX.ToString() + "\t"
                        + marsRover.PositionY.ToString() + "\t"
                        + marsRover.RoverCompassDirection.ToString() + Environment.NewLine);

                }

                Console.WriteLine("\n");
                Console.WriteLine("Expected Outputs:");
                Console.WriteLine(strbuilder);
            }
            else
            {
                Console.WriteLine($"Oops! File Not Found: Check args !!");
            }
        }

        public static int[] GetMaxPointOfArea(string text)
        {
            try
            {
                int[] maxPoint = { 0, 0 };
                string[] tempStr = text.Split(' ');
                for (int i = 0; i < 2; i++)
                {
                    maxPoint[i] = Convert.ToInt32(tempStr[i]);
                }

                return maxPoint;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:\nException:" + ex.Message);
                return null;
            }
        }

        public static Dictionary<int, string[]> GetMarsRoverInfo(string[] text)
        {
            Dictionary<int, string[]> marsRoverDict = new Dictionary<int, string[]>();
            try
            {
                int countOfMarsRover = 0;
                for (int i = 1; i < text.Length; i += 2)
                {
                    string[] tempStr = text[i].Split(' ');

                    string[] strInfo = { "", "", "", "" };
                    strInfo[0] = tempStr[0];
                    strInfo[1] = tempStr[1];
                    strInfo[2] = tempStr[2];
                    strInfo[3] = text[i + 1]; //Letter

                    countOfMarsRover = countOfMarsRover + 1;
                    marsRoverDict.Add(countOfMarsRover, strInfo);
                }
                return marsRoverDict;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:\nException:" + ex.Message);
                return null;
            }
        }

        public static CompassDirections GetCompassDirectionFromLetter(string text)
        {
            CompassDirections tempCompassDirection = CompassDirections.N;
            switch (text)
            {
                case "N":
                    tempCompassDirection = CompassDirections.N;
                    break;
                case "E":
                    tempCompassDirection = CompassDirections.E;
                    break;
                case "S":
                    tempCompassDirection = CompassDirections.S;
                    break;
                case "W":
                    tempCompassDirection = CompassDirections.W;
                    break;
            }
            return tempCompassDirection;
        }

    }
}