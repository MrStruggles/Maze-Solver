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
        Bitmap img;
        public frmSolver()
        {
            InitializeComponent();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text|*.png|All|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(openFileDialog.FileName);
                lblDirectory.Text = openFileDialog.FileName;
            }

            
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                MessageBox.Show("Please select a .png image","No File Selected",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                rtbOutput.Clear();
                bool[,] maze = MazeHandler.ConvertToArray(img);

                for (int i = 0; i < maze.GetLength(1); i++)
                {
                    for (int j = 0; j < maze.GetLength(0); j++)
                    {
                        if (maze[j, i])
                        {
                            rtbOutput.AppendText(" 1 ");
                        }
                        else
                        {
                            rtbOutput.AppendText(" 0 ");
                        }
                    }
                    rtbOutput.AppendText(Environment.NewLine);
                }

                MazeHandler.FloodFillSolve(maze);
            }
            
        }
    }
}
