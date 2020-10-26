using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsoleApp
{
    public enum CompassDirections
    {
        N = 1,  //North
        E = 2,  //East
        S = 3,  //South
        W = 4   //West
    }
    public enum Axis
    {
        X = 1,
        Y = 2
    }
    public enum CommandDirection
    {
        Right = 1,
        Left = 2,
        Move = 3
    }

    class Direction
    {
        private CompassDirections GetNewCompassPoint(CommandDirection command, CompassDirections direction)
        {
            if (command == CommandDirection.Right) return GetCompassDirectionTurnRight(direction); //Turn Right
            else return GetCompassDirectionTurnLeft(direction); //Turn Left
        }

        private Axis GetNewAxis(CompassDirections direction)
        {
            if (direction == CompassDirections.N || direction == CompassDirections.S)
            {
                return Axis.Y;
            }
            else
            {
                return Axis.X;
            }
        }

        public AxisDirectionModel GetNewDirection(CommandDirection command, CompassDirections direction)
        {
            AxisDirectionModel modelTemp = new AxisDirectionModel();
            modelTemp.compassDirection = GetNewCompassPoint(command, direction);
            modelTemp.axisDirection = GetNewAxis(modelTemp.compassDirection);
            return modelTemp;
        }

        public CompassDirections GetCompassDirectionTurnRight(CompassDirections direction)
        {
            CompassDirections tempDirection = CompassDirections.N;
            switch (direction)
            {
                case CompassDirections.N:
                    tempDirection = CompassDirections.E;
                    break;
                case CompassDirections.E:
                    tempDirection = CompassDirections.S;
                    break;
                case CompassDirections.S:
                    tempDirection = CompassDirections.W;
                    break;
                case CompassDirections.W:
                    tempDirection = CompassDirections.N;
                    break;
                default:
                    break;
            }
            return tempDirection;
        }

        public CompassDirections GetCompassDirectionTurnLeft(CompassDirections direction)
        {
            CompassDirections tempDirection = CompassDirections.N;
            switch (direction)
            {
                case CompassDirections.N:
                    tempDirection = CompassDirections.W;
                    break;
                case CompassDirections.E:
                    tempDirection = CompassDirections.N;
                    break;
                case CompassDirections.S:
                    tempDirection = CompassDirections.E;
                    break;
                case CompassDirections.W:
                    tempDirection = CompassDirections.S;
                    break;
                default:
                    break;
            }
            return tempDirection;
        }

    }
}
