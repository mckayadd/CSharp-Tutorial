namespace GatewayMessagingForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpCamera = new GroupBox();
            txtCameraLog = new TextBox();
            grpRobot = new GroupBox();
            txtRobotLog = new TextBox();
            grpConnector = new GroupBox();
            txtConnectorLog = new TextBox();
            btnStartSystem = new Button();
            grpCamera.SuspendLayout();
            grpRobot.SuspendLayout();
            grpConnector.SuspendLayout();
            SuspendLayout();
            // 
            // grpCamera
            // 
            grpCamera.Controls.Add(txtCameraLog);
            grpCamera.Location = new Point(49, 40);
            grpCamera.Name = "grpCamera";
            grpCamera.Size = new Size(308, 294);
            grpCamera.TabIndex = 0;
            grpCamera.TabStop = false;
            grpCamera.Text = "groupBox1";
            // 
            // txtCameraLog
            // 
            txtCameraLog.Location = new Point(19, 33);
            txtCameraLog.Multiline = true;
            txtCameraLog.Name = "txtCameraLog";
            txtCameraLog.ReadOnly = true;
            txtCameraLog.ScrollBars = ScrollBars.Vertical;
            txtCameraLog.Size = new Size(267, 243);
            txtCameraLog.TabIndex = 0;
            // 
            // grpRobot
            // 
            grpRobot.Controls.Add(txtRobotLog);
            grpRobot.Location = new Point(846, 40);
            grpRobot.Name = "grpRobot";
            grpRobot.Size = new Size(325, 294);
            grpRobot.TabIndex = 1;
            grpRobot.TabStop = false;
            grpRobot.Text = "groupBox1";
            // 
            // txtRobotLog
            // 
            txtRobotLog.Location = new Point(24, 33);
            txtRobotLog.Multiline = true;
            txtRobotLog.Name = "txtRobotLog";
            txtRobotLog.ReadOnly = true;
            txtRobotLog.ScrollBars = ScrollBars.Vertical;
            txtRobotLog.Size = new Size(267, 243);
            txtRobotLog.TabIndex = 1;
            // 
            // grpConnector
            // 
            grpConnector.Controls.Add(txtConnectorLog);
            grpConnector.Location = new Point(420, 73);
            grpConnector.Name = "grpConnector";
            grpConnector.Size = new Size(371, 185);
            grpConnector.TabIndex = 2;
            grpConnector.TabStop = false;
            grpConnector.Text = "groupBox1";
            // 
            // txtConnectorLog
            // 
            txtConnectorLog.Location = new Point(20, 35);
            txtConnectorLog.Multiline = true;
            txtConnectorLog.Name = "txtConnectorLog";
            txtConnectorLog.ReadOnly = true;
            txtConnectorLog.ScrollBars = ScrollBars.Vertical;
            txtConnectorLog.Size = new Size(345, 144);
            txtConnectorLog.TabIndex = 0;
            // 
            // btnStartSystem
            // 
            btnStartSystem.Font = new Font("Segoe UI", 12F);
            btnStartSystem.Location = new Point(479, 275);
            btnStartSystem.Name = "btnStartSystem";
            btnStartSystem.Size = new Size(265, 41);
            btnStartSystem.TabIndex = 3;
            btnStartSystem.Text = "Start";
            btnStartSystem.UseVisualStyleBackColor = true;
            btnStartSystem.Click += btnStartSystem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 392);
            Controls.Add(btnStartSystem);
            Controls.Add(grpConnector);
            Controls.Add(grpRobot);
            Controls.Add(grpCamera);
            Name = "MainForm";
            Text = "Form1";
            grpCamera.ResumeLayout(false);
            grpCamera.PerformLayout();
            grpRobot.ResumeLayout(false);
            grpRobot.PerformLayout();
            grpConnector.ResumeLayout(false);
            grpConnector.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpCamera;
        private TextBox txtCameraLog;
        private GroupBox grpRobot;
        private TextBox txtRobotLog;
        private GroupBox grpConnector;
        private TextBox txtConnectorLog;
        private Button btnStartSystem;
    }
}
