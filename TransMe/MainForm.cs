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
        MouseHook hook;
        string input;
        bool CombineBeforeTranslating = false;
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "TransMe";
            
            var delay = Settings.GetOrDefaultInt("delay",500);
            button = ButtonStrToButton(Settings.GetOrDefault("button", "Middle"));

            hook = new MouseHook();
            
            hook.MouseDown += Hook_MouseDown;
            hook.MouseUp += Hook_MouseUp; ;
            hook.Install();
            timer = new Timer();            
            timer.Interval = delay;
            timer.Tick += Timer_Tick;

        }


        #region Event Handlers
        private void Hook_MouseUp(object sender, MouseHookEventArgs e)
        {
            Debug.WriteLine(e.ToString() + " up");
            if (timer.Enabled)
            {
                timer.Stop();
            }
        }

        private void Hook_MouseDown(object sender, MouseHookEventArgs e)
        {
            Debug.WriteLine(e.ToString() + " down");
            if (e.Button == button && !timer.Enabled)
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
        #endregion
        #region Commands
        public void ShowApp()
        {
            ActivateWindow.SetActivate(this.Handle);
            ActivateWindow.MoveTo(this, MouseUtil.GetCursorPosition());
            input = Clipboard.GetText();            
            Translate();
        }
        public void Translate()
        {
            if (CombineBeforeTranslating)
            {
                input = input.Replace("\r", "").Replace("\n", " ");
            }
            this.textClipboard.Text = input;

            this.textBoxTranslation.Text = "Translating...";
            new System.Threading.Thread(async () =>
            {
                var translation = await new Translator().Translate(input);
                this.BeginInvoke((Action)(() =>
                {
                    this.textBoxTranslation.Text = translation;
                }));
            }).Start();
        }
        #endregion
        #region Others

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
        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hook.Uninstall();
        }

        private void menuItemJoinLines_CheckStateChanged(object sender, EventArgs e)
        {
            CombineBeforeTranslating = (sender as ToolStripMenuItem).Checked;
        }

        private void menuItemTranslate_Click(object sender, EventArgs e)
        {
            input = this.textClipboard.Text;
            Translate();
        }
    }
}
