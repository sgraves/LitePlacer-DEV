﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LitePlacer
{
	public partial class MethodSelectionForm : Form
	{
		public string SelectedMethod = "";
		public bool ShowCheckBox = false;
		public string HeaderString = "";

		public MethodSelectionForm()
		{
			InitializeComponent();
		}

		private void MethodSelectionForm_Load(object sender, EventArgs e)
		{
			UpdateJobGrid_checkBox.Visible = ShowCheckBox;
			if (ShowCheckBox)
			{
				// The form is raised at run time, because method was ?. That can't be selected again.
				Question_button.Enabled = false;
				this.Text = "Place " + HeaderString;
			}
			UpdateJobGrid_checkBox.Checked = Properties.Settings.Default.Placement_UpdateJobGridAtRuntime;
		}

		private void UpdateJobGrid_checkBox_CheckedChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Placement_UpdateJobGridAtRuntime = UpdateJobGrid_checkBox.Checked;
		}

		private void Question_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "?";
			this.Close();
		}

		private void ChangeNeedle_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Change needle";
			this.Close();
		}

		private void Recalibrate_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Recalibrate";
			this.Close();
		}

		private void Ignore_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Ignore";
			this.Close();
		}

		private void Fiducials_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Fiducials";
			this.Close();
		}

		private void Pause_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Pause";
			this.Close();
		}

		private void Place_button_Click(object sender, EventArgs e)
		{
			SelectedMethod = "Place";
			this.Close();
		}

		private void ManualUpCam_button_Click(object sender, EventArgs e)
		{
            SelectedMethod = "Place Manual UpCam";
            this.Close();
		}

        private void LoosePart_button_Click(object sender, EventArgs e)
        {
            SelectedMethod = "LoosePart";
            this.Close();
        }

        private void PlaceFast_button_Click(object sender, EventArgs e)
        {
            SelectedMethod = "Place Fast";
            this.Close();
        }

        private void ManualDownCam_button_Click(object sender, EventArgs e)
        {
            SelectedMethod = "DownCam Snapshot";
            this.Close();
        }

	}
}
