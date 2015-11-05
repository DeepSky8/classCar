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
            //Static car details

            public string BodyColor { get; set; }
            public string DoorType { get; set; }
            public string DoorNumber { get; set; }
            public enum SeatType { bucket, bench, economy }
            public enum SeatFabric { fabric, leather, pleather }
            public bool HasRadio { get; set; }
            public string RadioType { get; set; }
            public bool HasCdPlayer { get; set; }
            public bool HasTapeDeck { get; set; }
            public enum TrunkSize { small, medium, large }
            public bool AutomaticTransmission { get; set; }
            public double EngineSizeCCs { get; set; }
            public enum EnergySource { gasoline, diesel, hybrid, electric, ethanol }
            public bool KeylessEntry { get; set; }
            public bool TouchScreen { get; set; }
            public bool ReverseCamera { get; set; }
            public bool AutomaticWindows { get; set; }
            public int Airbags { get; set; }
            public bool HeadlightsOn { get; set; }


            //Mutable car details

            public double? CarCurrentSpeed { get; set; }
            public double? CarDirection { get; set; }
            public bool? CarMovingForward { get; set; }
            public double TireDirection = 0.0;
            public bool ClutchIn { get; set; }

            //Doors Closed
            public bool FrontLeftDoorClosed { get; set; }
            public bool FrontRightDoorClosed { get; set; }
            public bool BackLeftDoorClosed { get; set; }
            public bool BackRightDoorClosed { get; set; }

            //DoorsLocked
            public bool FrontLeftDoorLocked { get; set; }
            public bool FrontRightDoorLocked { get; set; }
            public bool BackLeftDoorLocked { get; set; }
            public bool BackRightDoorLocked { get; set; }

            //WindowsClosed
            public bool FrontLeftWindowClosed { get; set; }
            public bool FrontRightWindowClosed { get; set; }
            public bool BackLeftWindowClosed { get; set; }
            public bool BackRightWindowClosed { get; set; }


            //Things a car does

            /// <summary>
            /// Pressure on the gas pedel locks the doors and checks to see if the car is already moving. If not, the speed is updated to match the gas pedel pressure. If the car is moving, the speed is increased by the amount of pressure.
            /// </summary>
            /// <param name="pressure"></param>
            /// <returns></returns>
            public void Accelerate(double pressure)
            {
                LockAllDoors();

                if (CarMovingForward.HasValue)
                {
                    if (CarCurrentSpeed.HasValue)
                    {
                        CarCurrentSpeed += pressure;
                        CarDirection = 0.0;
                    }
                    else
                    {
                        CarCurrentSpeed = pressure;
                    }
                }
            }



            /// <summary>
            /// Pressure on the brake pedal checks to see if the car has any speed. If so, the speed is decreased by the units of brake pressure. If this reduction goes below 0, the car speed is reset to null.
            /// </summary>
            /// <param name="pressure"></param>
            /// <returns></returns>
            public void Brake(double pressure)
            {
                if (CarCurrentSpeed.HasValue)
                {
                    CarCurrentSpeed -= pressure;

                }
                if (CarCurrentSpeed <= 0)
                {
                    CarCurrentSpeed = null;
                    CarDirection = null;
                }

            }

            /// <summary>
            /// With wheels parallel to the car represented by 0.0, this method uses a double to represent the direction the tires are pointing.
            /// </summary>
            /// <param name="angle"></param>
            /// <returns></returns>
            public void SteeringWheelTurn(double angle)
            {
                if (SomethingIndicatingRightTurn)
                {
                    TireDirection += angle;
                }
                else
                {
                    TireDirection -= angle;
                }

                CarTurn(TireDirection);
            }


            /// <summary>
            /// If the car has a direction (determined by being in motion), this method adjusts the direction of the car relative to the starting direction of the car.
            /// </summary>
            /// <param name="angle"></param>
            /// <returns></returns>
            public void CarTurn(double angle)
            {
                if (CarDirection.HasValue)
                {
                    CarDirection += angle;
                }
            }

            /// <summary>
            /// When the lock signal is false, each door is set to unlocked. All other signals set the door lock signal to true.
            /// </summary>
            /// <param name="unlockSignal"></param>
            /// <returns></returns>
            public void doorUnlock(bool unlockSignal)
            {
                if (unlockSignal)
                {
                    UnlockAllDoors();
                }
                else
                {
                    LockAllDoors();
                }
            }

            public void LockAllDoors()
            {
                FrontLeftDoorLocked = true;
                FrontRightDoorLocked = true;
                BackLeftDoorLocked = true;
                BackRightDoorLocked = true;
            }

            public void UnlockAllDoors()
            {
                FrontLeftDoorLocked = false;
                FrontRightDoorLocked = false;
                BackLeftDoorLocked = false;
                BackRightDoorLocked = false;
            }

            //I'm not sure the best way to handle this concept. Unless this car has a light sensor, the headlights are switched on manually.
            public void headlightsOn()
            {
                if (HeadlightsOn)
                {
                    HeadlightsOn = false;
                }
                else
                {
                    HeadlightsOn = true;
                }

            }







            public enum Gear { Neutral, First, Second, Third, Fourth, Fifth, Reverse, Overdrive };
            public Gear transmissionGear = Gear.Neutral;


            public void changeGears(Gear currentGear, Gear stickPosition, bool clutchIn, bool? accelerating)
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



        }
    }
}
