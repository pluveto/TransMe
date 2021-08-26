using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        // 触发的鼠标按键
        MouseButtons button;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "TransMe";
            
            var delay = Settings.GetOrDefaultInt("delay",500);
            button = ButtonStrToButton(Settings.GetOrDefault("button", "Middle"));

            var hook = new MouseHook();
            
            hook.MouseDown += Hook_MouseDown;
            hook.MouseUp += Hook_MouseUp; ;
            hook.Install();
            timer = new Timer();            
            timer.Interval = delay;
            timer.Tick += Timer_Tick;

        }

        private MouseButtons ButtonStrToButton(string v)
        {
            switch (v.ToLower())
            {
                case "middle":
                case "mid":
                    return MouseButtons.Middle;
                case "left":
                    return MouseButtons.Left;
                case "right":
                    return MouseButtons.Right;
                case "forward":
                    return MouseButtons.XButton1;
                case "back":
                    return MouseButtons.XButton2;
                default:
                    return MouseButtons.Right;
            }
        }

        private void Hook_MouseUp(object sender, MouseHookEventArgs e)
        {
            timer.Stop();
        }

        private void Hook_MouseDown(object sender, MouseHookEventArgs e)
        {
            Debug.WriteLine("Gkh_KeyboardPressed " + e.Button);

            if (e.Button == button)
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
