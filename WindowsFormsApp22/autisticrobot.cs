using Lego.Ev3.Core;
using Lego.Ev3.Desktop;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace WindowsFormsApp22
{
    public partial class Form1 : Form
    {
        Brick _autisticrobot;
        int moverobotfoward = 30;
        int moverobotbackward = -30;
        uint time = 300;
        public Form1()
        {
            InitializeComponent();
        }

      

        private async void Form1_Load(object sender, EventArgs e)
        {
            // find out which port the robot has for the com port, normal has been com3 for our autistic robot, change when needed.
            _autisticrobot = new Brick(new BluetoothCommunication("COM3"));
            _autisticrobot.BrickChanged += _autisticrobot_BrickChanged;
            await _autisticrobot.ConnectAsync();
            await _autisticrobot.DirectCommand.PlayToneAsync(500,5000,500);
            // set forward if polarity makes it move backwards when forward button is pressed.
            await _autisticrobot.DirectCommand.SetMotorPolarity(OutputPort.B | OutputPort.C, Polarity.Backward);
            await _autisticrobot.DirectCommand.StopMotorAsync(OutputPort.All, false);

         
        }

        private void _autisticrobot_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            Debug.WriteLine("autism robot has been changed!");
        }

        private async void buttonforwards(object sender, EventArgs e)
        {
            int moverobotforward = 30;
            uint time = 300;
            // change ports for the ports we're using for wheels
            await _autisticrobot.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B | OutputPort.C, moverobotforward, time, false);
        }

        private async void buttonbackwards(object sender, EventArgs e)
        {
            await _autisticrobot.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.B | OutputPort.C, moverobotbackward, time, false);
        }

        private async void buttonlefft(object sender, EventArgs e)
        {
            // CHANGE OUTPUTPORTS TO WHATEVER KHONDAKER SET IT TO GODDAMNIT
             _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, moverobotbackward, time, false);
            _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, moverobotfoward, time, false);
            await _autisticrobot.BatchCommand.SendCommandAsync();
        }

        private async void buttonright_Click(object sender, EventArgs e)
        {
            // PUT OUTPUTPORTS TO WHATEVER KHONDAKER PUT IT TO, BUT REVERSE OF BUTTONLEFT.
            _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, moverobotbackward, time, false);
            _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, moverobotfoward, time, false);
            await _autisticrobot.BatchCommand.SendCommandAsync();
        }

        private async void Buttonemergencystop(object sender, EventArgs e)
        {
           await _autisticrobot.DirectCommand.StopMotorAsync(OutputPort.All, false);
            
        }

        private void buttongrab_Click(object sender, EventArgs e)
        {
            // change number to what is needed to get it to grab, change port to Grabber port
            _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, moverobotfoward, 3000, false);
        }

        private void buttonrelease_Click(object sender, EventArgs e)
        {
            // change value to what is needed to let the object go. change port to same as grabber
            _autisticrobot.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, moverobotbackward, 3000, false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Run_Application_Click(object sender, EventArgs e)
        {
            /* 
             await _autisticrobot.SystemCommand.CopyfileAsync( name of file, gotta import it on the solution explorer)
             */
        }

       
    }
}
