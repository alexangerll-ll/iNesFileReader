using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace iNesreader
{
    public partial class Form1 : Form
    {
        byte[] prg,chr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "iNes Files|*.nes";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Read the binary data from the stream.
                using (BinaryReader br = new BinaryReader(openFileDialog1.OpenFile()))
                {
                    byte[] header = br.ReadBytes(16);

                    string title = Encoding.Default.GetString(header, 0, 4);
                    int prgSize = header[4];
                    int chrSize = header[5];
                    prg = br.ReadBytes(0 + 8192 * 2 * prgSize);
                    chr = br.ReadBytes(0 + 8192 * chrSize);
                    byte[] res = br.ReadBytes(256);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < prg.Length; i++)
            {
                MessageBox.Show(prg[i].ToString(""));
            }
        }
    }
}
