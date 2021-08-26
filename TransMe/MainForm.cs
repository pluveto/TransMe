using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransMe
{
    public partial class MainForm : Form
    {
        Timer timer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // todo: config
            var interval = 500;
            var key = Keys.XButton2;

            var hook = new MouseHook();
            
            hook.MouseDown += Hook_MouseDown;
            hook.MouseUp += Hook_MouseUp; ;
            hook.Install();
            timer = new Timer();            
            timer.Interval = interval;
            timer.Tick += Timer_Tick;

        }

        private void Hook_MouseUp(object sender, MouseHookEventArgs e)
        {
            timer.Stop();
        }

        private void Hook_MouseDown(object sender, MouseHookEventArgs e)
        {
            Debug.WriteLine("Gkh_KeyboardPressed " + e.Button);

            if (e.Button == MouseButtons.XButton2)
            {
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Tick");
            (sender as Timer).Stop();
            SendInput.CtrlC();
            ShowApp();


        }
        public void ShowApp()
        {
            ActivateWindow.SetActivate(this.Handle);
            ActivateWindow.MoveTo(this, MouseUtil.GetCursorPosition());
            var input = Clipboard.GetText(); ;
            this.textClipboard.Text = input;
            this.textBoxTranslation.Text = new Translator().Translate(input);
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
