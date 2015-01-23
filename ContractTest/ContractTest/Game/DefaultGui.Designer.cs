using System.Windows.Forms;

namespace Inf3Project
{
    partial class DefaultGui
    {
        /// <summary>
        /// required designvariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Cleaning used resources.
        /// </summary>
        /// <param name="disposing">True, if manages resources should be deleted; else False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label9;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultGui));
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            this.chatInput = new System.Windows.Forms.TextBox();
            this.chatWindow = new System.Windows.Forms.RichTextBox();
            this.board = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Btn_ChatSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelBusy = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            label9.Location = new System.Drawing.Point(374, 8);
            label9.MaximumSize = new System.Drawing.Size(40, 40);
            label9.MinimumSize = new System.Drawing.Size(40, 40);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(40, 40);
            label9.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            label10.Location = new System.Drawing.Point(480, 12);
            label10.MaximumSize = new System.Drawing.Size(40, 40);
            label10.MinimumSize = new System.Drawing.Size(40, 40);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(40, 40);
            label10.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Image = ((System.Drawing.Image)(resources.GetObject("label15.Image")));
            label15.Location = new System.Drawing.Point(9, 164);
            label15.MaximumSize = new System.Drawing.Size(40, 40);
            label15.MinimumSize = new System.Drawing.Size(40, 40);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(40, 40);
            label15.TabIndex = 6;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Image = ((System.Drawing.Image)(resources.GetObject("label16.Image")));
            label16.Location = new System.Drawing.Point(73, 165);
            label16.MaximumSize = new System.Drawing.Size(40, 40);
            label16.MinimumSize = new System.Drawing.Size(40, 40);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(40, 40);
            label16.TabIndex = 11;
            // 
            // chatInput
            // 
            this.chatInput.BackColor = System.Drawing.SystemColors.Window;
            this.chatInput.Location = new System.Drawing.Point(113, 459);
            this.chatInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(398, 20);
            this.chatInput.TabIndex = 0;
            // 
            // chatWindow
            // 
            this.chatWindow.Location = new System.Drawing.Point(23, 368);
            this.chatWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chatWindow.Name = "chatWindow";
            this.chatWindow.ReadOnly = true;
            this.chatWindow.Size = new System.Drawing.Size(488, 81);
            this.chatWindow.TabIndex = 1;
            this.chatWindow.Text = "";
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(23, 12);
            this.board.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(350, 350);
            this.board.TabIndex = 2;
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // Btn_ChatSend
            // 
            this.Btn_ChatSend.Location = new System.Drawing.Point(23, 457);
            this.Btn_ChatSend.Name = "Btn_ChatSend";
            this.Btn_ChatSend.Size = new System.Drawing.Size(75, 23);
            this.Btn_ChatSend.TabIndex = 3;
            this.Btn_ChatSend.Text = "Senden";
            this.Btn_ChatSend.UseVisualStyleBackColor = true;
            this.Btn_ChatSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(384, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 71);
            this.panel1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Opponent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Dragon";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "You";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Cyan;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "    ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Key";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelY);
            this.panel2.Controls.Add(this.labelX);
            this.panel2.Controls.Add(this.labelBusy);
            this.panel2.Controls.Add(this.labelPoints);
            this.panel2.Controls.Add(label16);
            this.panel2.Controls.Add(label15);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label53);
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(384, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 218);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(66, 138);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(0, 13);
            this.labelY.TabIndex = 15;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(66, 109);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(0, 13);
            this.labelX.TabIndex = 14;
            // 
            // labelBusy
            // 
            this.labelBusy.AutoSize = true;
            this.labelBusy.Location = new System.Drawing.Point(66, 80);
            this.labelBusy.Name = "labelBusy";
            this.labelBusy.Size = new System.Drawing.Size(0, 13);
            this.labelBusy.TabIndex = 13;
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(66, 53);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(0, 13);
            this.labelPoints.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Y - Coord:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "X - Coord:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Busy:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 53);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(39, 13);
            this.label53.TabIndex = 2;
            this.label53.Text = "Points:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(66, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Name: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(412, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Your status";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DefaultGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(528, 495);
            this.Controls.Add(this.button1);
            this.Controls.Add(label10);
            this.Controls.Add(label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_ChatSend);
            this.Controls.Add(this.board);
            this.Controls.Add(this.chatWindow);
            this.Controls.Add(this.chatInput);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DefaultGui";
            this.ShowIcon = false;
            this.Text = "Spiel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.RichTextBox chatWindow;
        private System.Windows.Forms.Panel board;
        private ContextMenuStrip contextMenuStrip1;
        private Button Btn_ChatSend;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label7;
        private Panel panel2;
        private Label label8;
        private Label labelName;
        private Label label11;
        private Button button1;
        private Label labelPoints;
        private Label label12;
        private Label label14;
        private Label label13;
        private Label label53;
        private Label labelY;
        private Label labelX;
        private Label labelBusy;
    }
}

