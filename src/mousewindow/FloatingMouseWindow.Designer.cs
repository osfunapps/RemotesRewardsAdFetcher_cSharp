using gma.System.Windows;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.program.valuesparser
{
    partial class FloatingMouseWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        UserActivityHook actHook;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            actHook = new UserActivityHook(); // crate an instance
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mouseTxtLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.mouseTxtLabel.AutoSize = true;
            this.mouseTxtLabel.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mouseTxtLabel.ForeColor = System.Drawing.Color.Coral;
            this.mouseTxtLabel.Location = new System.Drawing.Point(0, 0);
            this.mouseTxtLabel.Margin = new System.Windows.Forms.Padding(0);
            this.mouseTxtLabel.Name = "label1";
            this.mouseTxtLabel.Size = new System.Drawing.Size(50, 17);
            this.mouseTxtLabel.TabIndex = 0;
            this.mouseTxtLabel.Text = "volUp : width";
            this.mouseTxtLabel.Click += new System.EventHandler(this.label1_Click);

            // 
            // FloatingMouseWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(350, 5);
            this.Size = new System.Drawing.Size(350, 5);
            this.Controls.Add(this.mouseTxtLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FloatingMouseWindow";
            this.Text = "FloatingMouseWindow";
            this.ResumeLayout(false);
            this.TopMost = true;
            this.PerformLayout();
            this.Load += new EventHandler(FrameLoad);
            

            //transperent color
            this.BackColor = System.Drawing.Color.LightCoral;
            this.TransparencyKey = System.Drawing.Color.LightCoral;

        }

        private void FrameLoad(object sender, EventArgs e)
        {
            actHook = new UserActivityHook(); // crate an instance

            // hang on events
            actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
        }

        private int Y_FRAME_POSITION_OFFSET = 40;

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            this.Location = new Point(Cursor.Position.X + 10, Cursor.Position.Y - Y_FRAME_POSITION_OFFSET);
        }

        #endregion


        private System.Windows.Forms.Label mouseTxtLabel;

        public System.Windows.Forms.Label getMouseTxtLabel()
        {
            return mouseTxtLabel;
        }


        public void AppendMouseTxtLabel(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendMouseTxtLabel), new object[] { value });
                return;
            }
            try
            {
                this.mouseTxtLabel.Text = value;
            }catch(Exception e)
            {
                e.Message.ToString();
            }
        }

    }

  

}