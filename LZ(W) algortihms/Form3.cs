﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LZ_W__algortihms.Utils;

namespace LZ_W__algortihms
{
    public partial class Form3 : Form
    {
        public Form3(string input, List<LZ78Entry> entries, LZ78Entry newOne, List<StepInfo> stepInfos)
        {
            InitializeComponent();
                       
            int m = 4;
            int n = Math.Max(entries.Count + 2, 20);

            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.ColumnCount = m;
            tableLayoutPanel1.RowCount = n;

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < m; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / m));
            }

            for (int j = 0; j < n; j++)
            {
                tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / n));
            }

            Label l1 = new Label();
            l1.Text = "Step";
            Label l2 = new Label();
            l2.Text = "Output";
            Label l3 = new Label();
            l3.Text = "Position";
            Label l4 = new Label();
            l4.Text = "Word";

            tableLayoutPanel1.Controls.Add(l1, 0, 0);
            tableLayoutPanel1.Controls.Add(l2, 1, 0);
            tableLayoutPanel1.Controls.Add(l3, 2, 0);
            tableLayoutPanel1.Controls.Add(l4, 3, 0);

            int k = 1;
            foreach(var entry in entries)
            {
                Label l11 = new Label();
                l11.Text = entry.Step.ToString();
                Label l12 = new Label();
                l12.Text = entry.Output;
                Label l13 = new Label();
                l13.Text = entry.Pos.ToString();
                Label l14 = new Label();
                l14.Text = entry.Word;

                tableLayoutPanel1.Controls.Add(l11, 0, k);
                tableLayoutPanel1.Controls.Add(l12, 1, k);
                tableLayoutPanel1.Controls.Add(l13, 2, k);
                tableLayoutPanel1.Controls.Add(l14, 3, k);

                k++;
            }
            MessageTextBox.Text = "Dictionary before this step";
            InputTextBox.Text = input;
            InputTextBox.SelectionStart = stepInfos[0].StartPos;
            InputTextBox.SelectionLength = 100;
            InputTextBox.SelectionColor = Color.Red;

            this.infos = stepInfos;
            this.newOne = newOne;
            this.cnt = entries.Count;
            currIdx = -1;

        }

        private void Next_Click(object sender, EventArgs e)
        {
            currIdx++;
            if(infos.Count == currIdx)
            {
                if (infos[infos.Count - 1].DoAdd)
                {
                    Label l11 = new Label();
                    l11.Text = newOne.Step.ToString();
                    Label l12 = new Label();
                    l12.Text = newOne.Output;
                    l12.BackColor = Color.Yellow;
                    Label l13 = new Label();
                    l13.Text = newOne.Pos.ToString();
                    Label l14 = new Label();
                    l14.Text = newOne.Word;
                    l14.BackColor = Color.Red;

                    tableLayoutPanel1.Controls.Add(l11, 0, cnt+1);
                    tableLayoutPanel1.Controls.Add(l12, 1, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l13, 2, cnt + 1);
                    tableLayoutPanel1.Controls.Add(l14, 3, cnt + 1);
                }
            } else if (infos.Count == currIdx - 1)
            {
                this.Close();
                return;
            } else
            {

                StepInfo si = infos[currIdx];
                if(currIdx < infos.Count - 1)
                {
                    Label l = tableLayoutPanel1.GetControlFromPosition(3, si.PrefixIdx) as Label;
                    l.BackColor = Color.Blue;
                } else
                {
                    if(si.PrefixIdx != -1)
                    {
                        tableLayoutPanel1.GetControlFromPosition(3, si.PrefixIdx).BackColor = Color.Yellow;
                        tableLayoutPanel1.GetControlFromPosition(0, si.PrefixIdx).BackColor = Color.Yellow;
                    }
                    InputTextBox.Text = InputTextBox.Text;
                    InputTextBox.SelectionStart = infos[infos.Count-1].StartPos;
                    InputTextBox.SelectionLength = infos[infos.Count - 1].MatchLen;
                    InputTextBox.SelectionColor = Color.Red;
                    this.Refresh();
                }
                MessageTextBox.Text = si.StepMessage;

                this.Refresh();            
            }

        }
    }
}
