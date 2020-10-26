using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsoleApp
{
    public class MarsRover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int MaxPositionX { get; set; }
        public int MaxPositionY { get; set; }
        private int MinPositionX { get; set; } = 0;
        private int MinPositionY { get; set; } = 0;
        public CompassDirections RoverCompassDirection { get; set; } = CompassDirections.N;
        public Axis AxisOfMotion { get; set; }
        private int MovingDirection { get; set; }
        private Direction directionObj;

        public MarsRover(int posXValue, int posYValue, CompassDirections facingCompass, int maxX, int maxY)
        {
            // Create a class constructor with multiple parameters
            PositionX = posXValue;
            PositionY = posYValue;
            RoverCompassDirection = facingCompass;
            MaxPositionX = maxX;
            MaxPositionY = maxY;

            AxisOfMotion = GetAxis(RoverCompassDirection);

            directionObj = new Direction();
        }

        public void ChangePosition(string letter)
        {
            foreach (char item in letter.ToCharArray())
            {
                if (item.ToString() == "M") MoveForward();
                else SetDirections(GetCommandFromLetter(item)); //R-L
            }
        }

        private CommandDirection GetCommandFromLetter(char charCommand)
        {
            CommandDirection commandDir = CommandDirection.Move;
            switch (charCommand)
            {
                case 'R':
                    commandDir = CommandDirection.Right;
                    break;
                case 'L':
                    commandDir = CommandDirection.Left;
                    break;
                case 'M':
                    commandDir = CommandDirection.Move;
                    break;
                default:
                    break;
            }
            return commandDir;
        }

        private Axis GetAxis(CompassDirections compassPoint)
        {
            Axis retVal = Axis.X;
            switch (compassPoint)
            {
                case CompassDirections.N:
                case CompassDirections.S:
                    retVal = Axis.Y;
                    break;
                case CompassDirections.W:
                case CompassDirections.E:
                    retVal = Axis.X;
                    break;

            }
            return retVal;
        }

        private void SetDirections(CommandDirection letterRL)
        {
            AxisDirectionModel axisDirectModel = new AxisDirectionModel();
            axisDirectModel = directionObj.GetNewDirection(letterRL, RoverCompassDirection);
            RoverCompassDirection = axisDirectModel.compassDirection;  //N-E-S-W
            AxisOfMotion = axisDirectModel.axisDirection;
        }

        private void MoveForward()
        {
            if (RoverCompassDirection == CompassDirections.N || RoverCompassDirection == CompassDirections.E) MovingDirection = 1;
            else MovingDirection = -1;

            if (AxisOfMotion == Axis.X)
            {
                PositionX = CheckAndChangePosition(PositionX, MovingDirection, Axis.X);
            }
            else
            {
                PositionY = CheckAndChangePosition(PositionY, MovingDirection, Axis.Y);
            }
        }

        private int CheckAndChangePosition(int currPosition, int moving, Axis directionXY)
        {
            int maxValue;
            try
            {
                if (directionXY == Axis.X) maxValue = MaxPositionX;
                else maxValue = MaxPositionY;

                if ((currPosition + moving < 0) || (currPosition + moving > maxValue))
                {
                    throw new Exception("ERROR: The rover can not go beyond borders: " + MaxPositionX.ToString() + "-" + MaxPositionY.ToString());
                } 
                else return (currPosition + moving);
            }
            catch (Exception ex)
            {
                throw new Exception($"ERROR:\n ({ex.Message})");
            }
        }

    }
}
