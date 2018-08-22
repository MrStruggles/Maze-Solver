using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeSolver
{
    public partial class frmSolver : Form
    {
        Maze maze;
        public frmSolver()
        {
            InitializeComponent();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text|*.png|All|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                maze = new Maze(new Bitmap(openFileDialog.FileName));
                lblDirectory.Text = openFileDialog.FileName;
            }

            
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (maze == null)
            {
                MessageBox.Show("Please select a .png image","No File Selected",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                // solve maxe and display process visually
            }
            
        }
    }
}
