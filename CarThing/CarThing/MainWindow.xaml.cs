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
            public bool ClutchIn { get; set; }


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
                    Accelerating = true;
                }
                else
                {
                    amountGas = 0;
                }
                return amountGas;
            }

            public bool? Accelerating = null;

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
                    Accelerating = false;
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

            /// <summary>
            /// This method accepts a bool that represents the current the headlights need to shine. If the current is on, the headlights are set to true, and this method returns true. Otherwise it always returns false
            /// </summary>
            /// <param name="current"></param>
            /// <returns></returns>
            public bool headlightsOn(bool current)
            {
                bool lights = false;

                if (current)
                {
                    lights = true;
                }

                return lights;
            }

            public double revPerMin(double engineStrokes)
            {
                return (engineStrokes);
            }


            public enum Gear { Neutral, First, Second, Third, Fourth, Fifth, Reverse, Overdrive };
            public Gear transmissionGear = Gear.Neutral;


            public void changeGears(Gear currentGear, Gear stickPosition, bool clutchIn, bool? accelerating, bool automaticTransmission)
            {
                //Always put the clutch in to change gears
                if (!clutchIn)
                {
                    ClutchIn = true;
                }

                //If the user desires to enage the reverse gear, engage the reverse gear
                if (stickPosition == Gear.Reverse)
                {
                    transmissionGear = Gear.Reverse;
                }

                //Automatic Transmission Cars
                if (automaticTransmission)
                {
                    if (!accelerating.HasValue)
                    {
                        transmissionGear = Gear.First;
                    }
                    else
                    {
                        if ((bool)accelerating)
                        {
                            switch (currentGear)
                            {
                                //case Gear.Neutral:
                                //    transmissionGear = Gear.First
                                //break;
                                case Gear.First:
                                    transmissionGear = Gear.Second;
                                    break;
                                case Gear.Second:
                                    transmissionGear = Gear.Third;
                                    break;
                                case Gear.Third:
                                    transmissionGear = Gear.Fourth;
                                    break;
                                case Gear.Fourth:
                                    transmissionGear = Gear.Fifth;
                                    break;
                                default:
                                    //If you're accelerating, you should only choose from these options
                                    break;
                            }
                        }
                        if (!(bool)accelerating)
                        {

                            switch (currentGear)
                            {
                                case Gear.Neutral:
                                    break;
                                case Gear.First:
                                    transmissionGear = Gear.Neutral;
                                    break;
                                case Gear.Second:
                                    transmissionGear = Gear.First;
                                    break;
                                case Gear.Third:
                                    transmissionGear = Gear.Second;
                                    break;
                                case Gear.Fourth:
                                    transmissionGear = Gear.Third;
                                    break;
                                case Gear.Fifth:
                                    transmissionGear = Gear.Fourth;
                                    break;
                                case Gear.Reverse:
                                    transmissionGear = Gear.Neutral;
                                    break;
                                default:
                                    //if you're breaking, you should only choose from these options
                                    break;
                            }
                        }
                    }

                    ClutchIn = false;
                }

                //Manual Transmission Cars
                if (!automaticTransmission)
                {
                    //Do whatever you feel like, you're a big boy now
                }

            }



        }
    }
}
