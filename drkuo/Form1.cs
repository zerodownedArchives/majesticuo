﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
        
namespace drkuo
{
    public partial class drkGui : Form
    {
        uonetwork uonet;
        private Thread mythread;
        private String ip;
        private int port;
        private String user;
        private String pass;
        public drkGui()
        {
            InitializeComponent();
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            txtOutput.Text = uonet.myoutput;
            //txtVarwindow.Text = uonet.myvars;
            if (uonet.mystate.buffer != null)
            {
                txtVarwindow.Text = BitConverter.ToString(uonet.mystate.buffer);
            }
        
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ip = txtIP.Text;
            user = txtUsername.Text;
            pass = txtPassword.Text;
            port = Convert.ToInt32(txtPort.Text);
            uonet = new uonetwork(ip, port, user, pass,Convert.ToInt32(txtCharSlot.Text));         
            mythread = new Thread(new ThreadStart(uonet.main));
            mythread.IsBackground = true;
            mythread.Start();
            timer1.Interval = 100;
            timer1.Start();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mythread.IsAlive)
            {
                mythread.Abort();
            }
            this.Close();
        }       
    }
}
