namespace IdiomExam
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtInterpretation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gpSetting = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSaveFilePath = new DevComponents.DotNetBar.ButtonX();
            this.txtSaveFilePath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTransparent = new System.Windows.Forms.TextBox();
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.sldAutoChange = new DevComponents.DotNetBar.Controls.Slider();
            this.sldTransparent = new DevComponents.DotNetBar.Controls.Slider();
            this.chkAutoChange = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSaveImg = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkEnableTop = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tpgIdiomData = new DevComponents.DotNetBar.TabItem(this.components);
            this.tmrAutoChange = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SttLableCountDown = new System.Windows.Forms.ToolStripStatusLabel();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.btnInfo = new DevComponents.DotNetBar.ButtonX();
            this.btnPrev = new DevComponents.DotNetBar.ButtonX();
            this.btnNext = new DevComponents.DotNetBar.ButtonX();
            this.btnExpCol = new DevComponents.DotNetBar.ButtonX();
            this.picSecIdiom = new System.Windows.Forms.PictureBox();
            this.btnSaveConfig = new DevComponents.DotNetBar.ButtonX();
            this.picFirstIdiom = new System.Windows.Forms.PictureBox();
            this.gpSetting.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSecIdiom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirstIdiom)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInterpretation
            // 
            this.txtInterpretation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(228)))));
            // 
            // 
            // 
            this.txtInterpretation.Border.Class = "TextBoxBorder";
            this.txtInterpretation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInterpretation.DisabledBackColor = System.Drawing.Color.White;
            this.txtInterpretation.ForeColor = System.Drawing.Color.Black;
            this.txtInterpretation.Location = new System.Drawing.Point(63, 110);
            this.txtInterpretation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtInterpretation.Multiline = true;
            this.txtInterpretation.Name = "txtInterpretation";
            this.txtInterpretation.PreventEnterBeep = true;
            this.txtInterpretation.Size = new System.Drawing.Size(640, 123);
            this.txtInterpretation.TabIndex = 9;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(8, 27);
            this.labelX2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(50, 31);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "成語:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(8, 165);
            this.labelX1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(48, 31);
            this.labelX1.TabIndex = 8;
            this.labelX1.Text = "釋義:";
            // 
            // gpSetting
            // 
            this.gpSetting.BackColor = System.Drawing.Color.White;
            this.gpSetting.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpSetting.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.gpSetting.Controls.Add(this.btnSaveConfig);
            this.gpSetting.Controls.Add(this.btnSaveFilePath);
            this.gpSetting.Controls.Add(this.txtSaveFilePath);
            this.gpSetting.Controls.Add(this.txtTransparent);
            this.gpSetting.Controls.Add(this.txtCountDown);
            this.gpSetting.Controls.Add(this.labelX4);
            this.gpSetting.Controls.Add(this.sldAutoChange);
            this.gpSetting.Controls.Add(this.sldTransparent);
            this.gpSetting.Controls.Add(this.chkAutoChange);
            this.gpSetting.Controls.Add(this.chkSaveImg);
            this.gpSetting.Controls.Add(this.chkEnableTop);
            this.gpSetting.DisabledBackColor = System.Drawing.Color.Empty;
            this.gpSetting.DrawTitleBox = false;
            this.gpSetting.Location = new System.Drawing.Point(753, 3);
            this.gpSetting.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gpSetting.Name = "gpSetting";
            this.gpSetting.Size = new System.Drawing.Size(390, 178);
            // 
            // 
            // 
            this.gpSetting.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpSetting.Style.BackColorGradientAngle = 90;
            this.gpSetting.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpSetting.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSetting.Style.BorderBottomWidth = 1;
            this.gpSetting.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpSetting.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSetting.Style.BorderLeftWidth = 1;
            this.gpSetting.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSetting.Style.BorderRightWidth = 1;
            this.gpSetting.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpSetting.Style.BorderTopWidth = 1;
            this.gpSetting.Style.CornerDiameter = 4;
            this.gpSetting.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpSetting.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpSetting.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpSetting.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpSetting.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpSetting.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpSetting.TabIndex = 6;
            this.gpSetting.Text = "參數設定";
            // 
            // btnSaveFilePath
            // 
            this.btnSaveFilePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveFilePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveFilePath.Location = new System.Drawing.Point(336, 77);
            this.btnSaveFilePath.Name = "btnSaveFilePath";
            this.btnSaveFilePath.Size = new System.Drawing.Size(21, 27);
            this.btnSaveFilePath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSaveFilePath.TabIndex = 14;
            this.btnSaveFilePath.Text = "..";
            this.btnSaveFilePath.Click += new System.EventHandler(this.btnSaveFilePath_Click);
            // 
            // txtSaveFilePath
            // 
            this.txtSaveFilePath.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSaveFilePath.Border.Class = "TextBoxBorder";
            this.txtSaveFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSaveFilePath.DisabledBackColor = System.Drawing.Color.White;
            this.txtSaveFilePath.ForeColor = System.Drawing.Color.Black;
            this.txtSaveFilePath.Location = new System.Drawing.Point(125, 77);
            this.txtSaveFilePath.Name = "txtSaveFilePath";
            this.txtSaveFilePath.PreventEnterBeep = true;
            this.txtSaveFilePath.Size = new System.Drawing.Size(206, 27);
            this.txtSaveFilePath.TabIndex = 13;
            // 
            // txtTransparent
            // 
            this.txtTransparent.Location = new System.Drawing.Point(299, 38);
            this.txtTransparent.Name = "txtTransparent";
            this.txtTransparent.ReadOnly = true;
            this.txtTransparent.Size = new System.Drawing.Size(50, 27);
            this.txtTransparent.TabIndex = 12;
            this.txtTransparent.Text = "100";
            this.txtTransparent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTransparent.TextChanged += new System.EventHandler(this.txtTransparent_TextChanged);
            // 
            // txtCountDown
            // 
            this.txtCountDown.Location = new System.Drawing.Point(299, 0);
            this.txtCountDown.Name = "txtCountDown";
            this.txtCountDown.Size = new System.Drawing.Size(50, 27);
            this.txtCountDown.TabIndex = 11;
            this.txtCountDown.Text = "30";
            this.txtCountDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCountDown.TextChanged += new System.EventHandler(this.txtCountDown_TextChanged);
            this.txtCountDown.Validated += new System.EventHandler(this.txtCountDown_Validated);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(354, -2);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(29, 31);
            this.labelX4.TabIndex = 10;
            this.labelX4.Text = "秒";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // sldAutoChange
            // 
            // 
            // 
            // 
            this.sldAutoChange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sldAutoChange.LabelWidth = 45;
            this.sldAutoChange.Location = new System.Drawing.Point(125, 0);
            this.sldAutoChange.Margin = new System.Windows.Forms.Padding(4);
            this.sldAutoChange.Maximum = 1800;
            this.sldAutoChange.Minimum = 5;
            this.sldAutoChange.Name = "sldAutoChange";
            this.sldAutoChange.Size = new System.Drawing.Size(167, 31);
            this.sldAutoChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sldAutoChange.TabIndex = 9;
            this.sldAutoChange.Text = "時間:";
            this.sldAutoChange.Value = 60;
            this.sldAutoChange.ValueChanged += new System.EventHandler(this.sliderAutoChange_ValueChanged);
            // 
            // sldTransparent
            // 
            // 
            // 
            // 
            this.sldTransparent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sldTransparent.LabelWidth = 60;
            this.sldTransparent.Location = new System.Drawing.Point(125, 36);
            this.sldTransparent.Margin = new System.Windows.Forms.Padding(4);
            this.sldTransparent.Minimum = 25;
            this.sldTransparent.Name = "sldTransparent";
            this.sldTransparent.Size = new System.Drawing.Size(167, 31);
            this.sldTransparent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sldTransparent.TabIndex = 8;
            this.sldTransparent.Text = "透明度:";
            this.sldTransparent.Value = 100;
            this.sldTransparent.ValueChanged += new System.EventHandler(this.sldTransparent_ValueChanged);
            // 
            // chkAutoChange
            // 
            // 
            // 
            // 
            this.chkAutoChange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkAutoChange.Checked = true;
            this.chkAutoChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoChange.CheckValue = "Y";
            this.chkAutoChange.Location = new System.Drawing.Point(4, 0);
            this.chkAutoChange.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutoChange.Name = "chkAutoChange";
            this.chkAutoChange.Size = new System.Drawing.Size(114, 31);
            this.chkAutoChange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkAutoChange.TabIndex = 7;
            this.chkAutoChange.Text = "自動切換";
            this.chkAutoChange.CheckedChanged += new System.EventHandler(this.chkAutoChange_CheckedChanged);
            // 
            // chkSaveImg
            // 
            // 
            // 
            // 
            this.chkSaveImg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSaveImg.Location = new System.Drawing.Point(4, 75);
            this.chkSaveImg.Margin = new System.Windows.Forms.Padding(4);
            this.chkSaveImg.Name = "chkSaveImg";
            this.chkSaveImg.Size = new System.Drawing.Size(114, 31);
            this.chkSaveImg.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSaveImg.TabIndex = 7;
            this.chkSaveImg.Text = "輸出圖檔";
            this.chkSaveImg.CheckedChanged += new System.EventHandler(this.chkSaveImg_CheckedChanged);
            // 
            // chkEnableTop
            // 
            // 
            // 
            // 
            this.chkEnableTop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkEnableTop.Location = new System.Drawing.Point(4, 36);
            this.chkEnableTop.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableTop.Name = "chkEnableTop";
            this.chkEnableTop.Size = new System.Drawing.Size(114, 31);
            this.chkEnableTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkEnableTop.TabIndex = 7;
            this.chkEnableTop.Text = "最上層顯示";
            this.chkEnableTop.CheckedChanged += new System.EventHandler(this.chkEnableTop_CheckedChanged);
            // 
            // tpgIdiomData
            // 
            this.tpgIdiomData.Name = "tpgIdiomData";
            this.tpgIdiomData.Text = "資料表頁面";
            // 
            // tmrAutoChange
            // 
            this.tmrAutoChange.Enabled = true;
            this.tmrAutoChange.Interval = 6000;
            this.tmrAutoChange.Tick += new System.EventHandler(this.tmrAutoChange_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SttLableCountDown});
            this.statusStrip1.Location = new System.Drawing.Point(0, 237);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1150, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SttLableCountDown
            // 
            this.SttLableCountDown.Name = "SttLableCountDown";
            this.SttLableCountDown.Size = new System.Drawing.Size(0, 17);
            // 
            // superTooltip1
            // 
            this.superTooltip1.DefaultTooltipSettings = new DevComponents.DotNetBar.SuperTooltipInfo("", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.Gray);
            // 
            // btnInfo
            // 
            this.btnInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInfo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnInfo.Location = new System.Drawing.Point(712, 89);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(32, 107);
            this.btnInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInfo.TabIndex = 10;
            this.btnInfo.Text = "其\r\n它\r\n資\r\n訊";
            this.btnInfo.TextColor = System.Drawing.Color.Black;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(712, 45);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(36, 36);
            this.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.btnPrev, new DevComponents.DotNetBar.SuperTooltipInfo("上一筆資料", "", "", global::IdiomExam.Properties.Resources.ben1_96pix, null, DevComponents.DotNetBar.eTooltipColor.Apple));
            this.btnPrev.TabIndex = 15;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(712, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 36);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.btnNext, new DevComponents.DotNetBar.SuperTooltipInfo("下一筆資料", "", "", global::IdiomExam.Properties.Resources.ben1_96pix, null, DevComponents.DotNetBar.eTooltipColor.Apple, true, false, new System.Drawing.Size(0, 0)));
            this.btnNext.TabIndex = 14;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExpCol
            // 
            this.btnExpCol.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpCol.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExpCol.Image = ((System.Drawing.Image)(resources.GetObject("btnExpCol.Image")));
            this.btnExpCol.Location = new System.Drawing.Point(712, 201);
            this.btnExpCol.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExpCol.Name = "btnExpCol";
            this.btnExpCol.Size = new System.Drawing.Size(32, 32);
            this.btnExpCol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.btnExpCol, new DevComponents.DotNetBar.SuperTooltipInfo("顯示設定介面", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.Gray));
            this.btnExpCol.TabIndex = 11;
            this.btnExpCol.Click += new System.EventHandler(this.btnExpCol_Click);
            // 
            // picSecIdiom
            // 
            this.picSecIdiom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(228)))));
            this.picSecIdiom.Location = new System.Drawing.Point(63, 53);
            this.picSecIdiom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.picSecIdiom.Name = "picSecIdiom";
            this.picSecIdiom.Size = new System.Drawing.Size(640, 50);
            this.picSecIdiom.TabIndex = 2;
            this.picSecIdiom.TabStop = false;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveConfig.Image")));
            this.btnSaveConfig.Location = new System.Drawing.Point(4, 113);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(32, 32);
            this.btnSaveConfig.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTooltip1.SetSuperTooltip(this.btnSaveConfig, new DevComponents.DotNetBar.SuperTooltipInfo("儲存設定", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.Gray));
            this.btnSaveConfig.TabIndex = 15;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // picFirstIdiom
            // 
            this.picFirstIdiom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(228)))));
            this.picFirstIdiom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picFirstIdiom.Location = new System.Drawing.Point(63, 3);
            this.picFirstIdiom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.picFirstIdiom.Name = "picFirstIdiom";
            this.picFirstIdiom.Size = new System.Drawing.Size(640, 50);
            this.picFirstIdiom.TabIndex = 0;
            this.picFirstIdiom.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 259);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnExpCol);
            this.Controls.Add(this.txtInterpretation);
            this.Controls.Add(this.picSecIdiom);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.gpSetting);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.picFirstIdiom);
            this.Font = new System.Drawing.Font("新細明體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "成語學習";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.Move += new System.EventHandler(this.frmMain_Move);
            this.gpSetting.ResumeLayout(false);
            this.gpSetting.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSecIdiom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirstIdiom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.TabItem tpgIdiomData;
        private System.Windows.Forms.PictureBox picFirstIdiom;
        private System.Windows.Forms.PictureBox picSecIdiom;
        private DevComponents.DotNetBar.Controls.GroupPanel gpSetting;
        private DevComponents.DotNetBar.Controls.Slider sldTransparent;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkEnableTop;
        private DevComponents.DotNetBar.Controls.TextBoxX txtInterpretation;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.Slider sldAutoChange;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkAutoChange;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Timer tmrAutoChange;
        private DevComponents.DotNetBar.ButtonX btnExpCol;
        private DevComponents.DotNetBar.ButtonX btnInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SttLableCountDown;
        private System.Windows.Forms.TextBox txtCountDown;
        private System.Windows.Forms.TextBox txtTransparent;
        private DevComponents.DotNetBar.ButtonX btnNext;
        private DevComponents.DotNetBar.ButtonX btnSaveFilePath;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSaveFilePath;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSaveImg;
        private DevComponents.DotNetBar.ButtonX btnSaveConfig;
        private DevComponents.DotNetBar.ButtonX btnPrev;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
    }
}

