using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarThing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class Car
        {
            //Parts of a car

            //Body
            //Doors
            //Seats
            //Seatbelts
            //Radio
            //Trunk
            //Engine
            //Windows
            //SteeringWheel
            //GasPedal
            //BrakePedal
            //Mirrors
            //Airbags

            public string BodyColor { get; set; }
            public string DoorType { get; set; }
            public string DoorNumber { get; set; }
            public string SeatType { get; set; }
            public string RadioType { get; set; }
            public string TrunkSize { get; set; }
            public bool AutomaticTransmission { get; set; }
            public string EngineSize { get; set; }
            public string EngineFuel { get; set; }
            public bool KeylessEntry { get; set; }
            public bool TouchScreen { get; set; }
            public bool ReverseCamera { get; set; }
            public bool AutomaticWindows { get; set; }
            public int Airbags { get; set; }
            public bool Locked { get; set; }


            //Things a car does

            //Accelerate
            //Brake
            //Turn
            //UnlockDoors
            //LightHeadlamps
            //OpenTrunk
            //RegisterSpeed
            //ChangeGears
            //ReportFuelLevel
            //PlayRadio
            //RollWindows
            //ActivateAirbags

            /// <summary>
            /// Pressure on the gas pedel causes this method to return that same amount of gas to the engine
            /// </summary>
            /// <param name="pressure"></param>
            /// <returns></returns>
            public double Accelerate(double? pressure)
            {
                double amountGas;

                if (pressure.HasValue)
                {
                    amountGas = (double)pressure;
                }
                else
                {
                    amountGas = 0;
                }
                return amountGas;
            }

            /// <summary>
            /// Pressure on the brake pedal causes this method to return that same amount of force to the brake pads
            /// </summary>
            /// <param name="pressure"></param>
            /// <returns></returns>
            public double Brake(double? pressure)
            {
                double brakePressure;

                if (pressure.HasValue)
                {
                    brakePressure = (double)pressure;
                }
                else
                {
                    brakePressure = 0;
                }

                return brakePressure;
            }

            /// <summary>
            /// If the steering wheel is turned, this method amplifies the angle of the turn (x4) and returns the amount the wheels should turn (positive or negative, left or right)
            /// </summary>
            /// <param name="angle"></param>
            /// <returns></returns>
            public double Turn(double? angle)
            {
                double turnRatio;

                if (angle.HasValue)
                {
                    turnRatio = ((double)angle * 4);
                }
                else
                {
                    turnRatio = 0;
                }

                return turnRatio;
            }

            /// <summary>
            /// When the unlock signal is received, the door lock bool is set to mirror the signal being received. This state is returned by the method.
            /// </summary>
            /// <param name="unlockSignal"></param>
            /// <returns></returns>
            public bool doorLock(bool unlockSignal)
            {
                bool locked = true;

                if (unlockSignal)
                {
                    locked = false;
                }
                else
                {
                    locked = true;
                }

                return locked;
            }





        }
    }
}
