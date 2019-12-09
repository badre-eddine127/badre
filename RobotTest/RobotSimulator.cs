using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotTest
{
    public class RobotSimulator
    {
        public RobotSimulator(Bearing bearing, Coordinate coordinate)
        {
            Bearing = bearing;
            Coordinate = coordinate;
        }

        public Bearing Bearing
        {
            get; private set;
        }

        public Coordinate Coordinate
        {
            get; private set;
        }

        public void TurnRight()
        {
            switch (Bearing)
            {
                case Bearing.N:
                    Bearing = Bearing.E;
                    break;
                case Bearing.E:
                    Bearing = Bearing.S;
                    break;
                case Bearing.S:
                    Bearing = Bearing.W;
                    break;
                case Bearing.W:
                    Bearing = Bearing.N;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Bearing)
            {
                case Bearing.N:
                    Bearing = Bearing.W;
                    break;
                case Bearing.E:
                    Bearing = Bearing.N;
                    break;
                case Bearing.S:
                    Bearing = Bearing.E;
                    break;
                case Bearing.W:
                    Bearing = Bearing.S;
                    break;
            }
        }

        public void Advance()
        {
            switch (Bearing)
            {
                case Bearing.N:
                    Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                    break;
                case Bearing.E:
                    Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                    break;
                case Bearing.S:
                    Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                    break;
                case Bearing.W:
                    Coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                    break;
            }
        }

        public void Simulate(string instructions)
        {
            var move = new Dictionary<char, Action>
            {
                ['R'] = TurnRight,
                ['L'] = TurnLeft,
                ['A'] = Advance,
            };

            instructions.Where(c => move.ContainsKey(c))    //ignore unknown commands
                        .Select(c => move[c])
                        .ToList()
                        .ForEach(a => a.Invoke());
        }

        public String Display()
        {
            String state= "Vrai";
            if(this.Coordinate.X<0 || this.Coordinate.Y < 0)
            {
                state = "Faux";
            }
            return state+","+ this.Bearing + "," + "(" + this.Coordinate.X + "," + this.Coordinate.Y + ")";
        }
    }


}
