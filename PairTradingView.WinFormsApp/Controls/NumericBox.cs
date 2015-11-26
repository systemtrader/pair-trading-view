﻿/*
Copyright 2015 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PairTradingView.Controls
{
    public partial class NumericBox : UserControl
    {
        private decimal value;

        public decimal Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;

                textBox.Text = this.value.ToString();
            }
        }

        public event EventHandler ValueChanged;

        public NumericBox()
        {
            InitializeComponent();
        }

        private void NumericBox_Load(object sender, EventArgs e)
        {
            textBox.BackColor = Color.Black;
            textBox.ForeColor = Color.White;

            textBox.Leave += textBox_Leave;

            BackColor = Color.Black;
            ForeColor = Color.White;

            this.Height = textBox.Height;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            decimal temp;

            if (decimal.TryParse(textBox.Text, out temp) && temp >= 0)
            {
                value = temp;
                OnValueChanged(this, null);
            }
            else
            {
                textBox.Text = value.ToString();
            }
        }

        private void decrementButton_Click(object sender, EventArgs e)
        {
            decimal temp;

            if (decimal.TryParse(textBox.Text, out temp) && temp - 1 >= 0)
            {
                textBox.Text = (--value).ToString();
                OnValueChanged(this, null);
            }
        }

        private void incrementButton_Click(object sender, EventArgs e)
        {
            decimal temp;

            if (decimal.TryParse(textBox.Text, out temp) && temp >= 0)
            {
                textBox.Text = (++value).ToString();
                OnValueChanged(this, null);
            }
        }

        protected void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(sender, e);
        }

    }
}
