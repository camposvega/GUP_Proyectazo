﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro00081511
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public TableLayoutPanel TableLayoutPanel1
        {
            get => tableLayoutPanel1;
            set => tableLayoutPanel1 = value;
        }
    }
}