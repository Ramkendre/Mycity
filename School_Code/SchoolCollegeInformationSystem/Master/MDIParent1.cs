using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolCollegeInformationSystem.Master
{
    public partial class MDIParent1 : Form
    {

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Main.start startObj = new Main.start();
            startObj.MdiParent = this;
            startObj.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.start startObj = new Main.start();
            startObj.MdiParent = this;
            startObj.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.aboutus aboutUsObj = new Main.aboutus();
            aboutUsObj.MdiParent = this;
            aboutUsObj.Show();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main.contactus contactobj = new Main.contactus();
            contactobj.MdiParent = this;
            contactobj.Show();
        }


    }
}
