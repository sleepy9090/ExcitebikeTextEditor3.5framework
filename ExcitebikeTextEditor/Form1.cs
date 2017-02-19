using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Shawn M. Crawford [sleepy]
 * sleepy3d@gmail.com
 * 03/26/2016
 */
namespace ExcitebikeTextEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void buttonOpenROM_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open file...";
            ofd.Filter = "nes files (*.nes)|*.nes|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK) {
                textBoxAbsoluteFilename.Text = ofd.FileName;

                readRomText();
            }
        }

        private void readRomText() {
            try {
                string absoluteFilename = textBoxAbsoluteFilename.Text;

                Backend backend = new Backend();

                backend.getText(absoluteFilename, textBoxEB1, 0x8, 0x14E7);
                backend.getText(absoluteFilename, textBoxEB2, 0x4, 0x156E);
                backend.getText(absoluteFilename, textBoxEB3, 0x4, 0x1588);
                backend.getText(absoluteFilename, textBoxEB4, 0xA, 0x15B7);
                backend.getText(absoluteFilename, textBoxEB5, 0xC, 0x15CB);

                backend.getText(absoluteFilename, textBoxEB6, 0x12, 0x15DB);
                backend.getText(absoluteFilename, textBoxEB7, 0x9, 0x15F5);
                backend.getText(absoluteFilename, textBoxEB8, 0x12, 0x1602);
                backend.getText(absoluteFilename, textBoxEB9, 0x7, 0x161C);
                backend.getText(absoluteFilename, textBoxEB10, 0x7, 0x162B);

                backend.getText(absoluteFilename, textBoxEB11, 0x6, 0x163A);
                backend.getText(absoluteFilename, textBoxEB12, 0x5, 0x1644);
                backend.getText(absoluteFilename, textBoxEB13, 0xB, 0x16B0);
                backend.getText(absoluteFilename, textBoxEB14, 0xB, 0x16BE);
                backend.getText(absoluteFilename, textBoxEB15, 0x6, 0x16CC);

                backend.getText(absoluteFilename, textBoxEB16, 0xE, 0x16D5);
                backend.getText(absoluteFilename, textBoxEB17, 0x9, 0x16FD);
                backend.getText(absoluteFilename, textBoxEB18, 0x4, 0x1709);
                backend.getText(absoluteFilename, textBoxEB19, 0x6, 0x1710);
                backend.getText(absoluteFilename, textBoxEB20, 0x1, 0x1719);

                backend.getText(absoluteFilename, textBoxEB21, 0x1, 0x171C);
                backend.getText(absoluteFilename, textBoxEB22, 0x1, 0x171F);
                backend.getText(absoluteFilename, textBoxEB23, 0x1, 0x1722);
                backend.getText(absoluteFilename, textBoxEB24, 0x1, 0x1725);
                backend.getText(absoluteFilename, textBoxEB25, 0x9, 0x1769);

                backend.getText(absoluteFilename, textBoxEB26, 0x4, 0x1775);
                backend.getText(absoluteFilename, textBoxEB27, 0x9, 0x177C);
                backend.getText(absoluteFilename, textBoxEB28, 0x9, 0x1788);
                backend.getText(absoluteFilename, textBoxEB29, 0x7, 0x1794);
                backend.getText(absoluteFilename, textBoxEB30, 0xA, 0x17C9);

                backend.getText(absoluteFilename, textBoxEB31, 0x5, 0x17D7);
                backend.getText(absoluteFilename, textBoxEB32, 0x9, 0x17EC);
                backend.getText(absoluteFilename, textBoxEB33, 0xB, 0x1821);
                backend.getText(absoluteFilename, textBoxEB34, 0xB, 0x182F);
                backend.getText(absoluteFilename, textBoxEB35, 0x6, 0x183D);

                backend.getText(absoluteFilename, textBoxEB36, 0x4, 0x1846);
                backend.getText(absoluteFilename, textBoxEB37, 0x4, 0x184D);
                backend.getText(absoluteFilename, textBoxEB38, 0x5, 0x1854);
                backend.getText(absoluteFilename, textBoxEB39, 0x13, 0x185D);
                backend.getText(absoluteFilename, textBoxEB40, 0x3, 0x1554);

                backend.getText(absoluteFilename, textBoxEB41, 0x2, 0x1759);
                backend.getText(absoluteFilename, textBoxEB42, 0x2, 0x1764);
                backend.getText(absoluteFilename, textBoxEB43, 0x3, 0x34DD);

                enableButtons();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Console.WriteLine("Error: " + ex);
            }
        }

        private void enableButtons() {
            buttonUpdateText.Enabled = true;
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e) {
            buttonOpenROM_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e) {
            setMaxLengthOfTextBoxes();
        }

        private void setMaxLengthOfTextBoxes() {
            textBoxEB1.MaxLength = 0x8;
            textBoxEB2.MaxLength = 0x4;
            textBoxEB3.MaxLength = 0x4;
            textBoxEB4.MaxLength = 0xA;
            textBoxEB5.MaxLength = 0xC;
 
            textBoxEB6.MaxLength = 0x12;
            textBoxEB7.MaxLength = 0x9;
            textBoxEB8.MaxLength = 0x12;
            textBoxEB9.MaxLength = 0x7;
            textBoxEB10.MaxLength = 0x7;

            textBoxEB11.MaxLength = 0x6;
            textBoxEB12.MaxLength = 0x5;
            textBoxEB13.MaxLength = 0xB;
            textBoxEB14.MaxLength = 0xB;
            textBoxEB15.MaxLength = 0x6;

            textBoxEB16.MaxLength = 0xE;
            textBoxEB17.MaxLength = 0x9;
            textBoxEB18.MaxLength = 0x4;
            textBoxEB19.MaxLength = 0x6;
            textBoxEB20.MaxLength = 0x1;

            textBoxEB21.MaxLength = 0x1;
            textBoxEB22.MaxLength = 0x1;
            textBoxEB23.MaxLength = 0x1;
            textBoxEB24.MaxLength = 0x1;
            textBoxEB25.MaxLength = 0x9;

            textBoxEB26.MaxLength = 0x4;
            textBoxEB27.MaxLength = 0x9;
            textBoxEB28.MaxLength = 0x9;
            textBoxEB29.MaxLength = 0x7;
            textBoxEB30.MaxLength = 0xA;

            textBoxEB31.MaxLength = 0x5;
            textBoxEB32.MaxLength = 0x9;
            textBoxEB33.MaxLength = 0xB;
            textBoxEB34.MaxLength = 0xB;
            textBoxEB35.MaxLength = 0x6;

            textBoxEB36.MaxLength = 0x4;
            textBoxEB37.MaxLength = 0x4;
            textBoxEB38.MaxLength = 0x5;
            textBoxEB39.MaxLength = 0x13;
            textBoxEB40.MaxLength = 0x3;

            textBoxEB41.MaxLength = 0x2;
            textBoxEB42.MaxLength = 0x2;
            textBoxEB43.MaxLength = 0x3;
        }

        private void buttonUpdateText_Click(object sender, EventArgs e) {

            string absoluteFilename = textBoxAbsoluteFilename.Text;
            Backend backend = new Backend();

            backend.updateROMText(absoluteFilename, 0x8, textBoxEB1, 0x14E7);
            backend.updateROMText(absoluteFilename, 0x4, textBoxEB2, 0x156E);
            backend.updateROMText(absoluteFilename, 0x4, textBoxEB3, 0x1588);
            backend.updateROMText(absoluteFilename, 0xA, textBoxEB4, 0x15B7);
            backend.updateROMText(absoluteFilename, 0xC, textBoxEB5, 0x15CB);
            
            backend.updateROMText(absoluteFilename, 0x12, textBoxEB6, 0x15DB);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB7, 0x15F5);
            backend.updateROMText(absoluteFilename, 0x12, textBoxEB8, 0x1602);
            backend.updateROMText(absoluteFilename, 0x7, textBoxEB9, 0x161C);
            backend.updateROMText(absoluteFilename, 0x7, textBoxEB10, 0x162B);

            backend.updateROMText(absoluteFilename, 0x6, textBoxEB11, 0x163A);
            backend.updateROMText(absoluteFilename, 0x5, textBoxEB12, 0x1644);
            backend.updateROMText(absoluteFilename, 0xB, textBoxEB13, 0x16B0);
            backend.updateROMText(absoluteFilename, 0xB, textBoxEB14, 0x16BE);
            backend.updateROMText(absoluteFilename, 0x6, textBoxEB15, 0x16CC);

            backend.updateROMText(absoluteFilename, 0xE, textBoxEB16, 0x16D5);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB17, 0x16FD);
            backend.updateROMText(absoluteFilename, 0x4, textBoxEB18, 0x1709);
            backend.updateROMText(absoluteFilename, 0x6, textBoxEB19, 0x1710);
            backend.updateROMText(absoluteFilename, 0x1, textBoxEB20, 0x1719);
            
            backend.updateROMText(absoluteFilename, 0x1, textBoxEB21, 0x171C);
            backend.updateROMText(absoluteFilename, 0x1, textBoxEB22, 0x171F);
            backend.updateROMText(absoluteFilename, 0x1, textBoxEB23, 0x1722);
            backend.updateROMText(absoluteFilename, 0x1, textBoxEB24, 0x1725);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB25, 0x1769);

            backend.updateROMText(absoluteFilename, 0x4, textBoxEB26, 0x1775);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB27, 0x177C);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB28, 0x1788);
            backend.updateROMText(absoluteFilename, 0x7, textBoxEB29, 0x1794);
            backend.updateROMText(absoluteFilename, 0xA, textBoxEB30, 0x17C9);

            backend.updateROMText(absoluteFilename, 0x5, textBoxEB31, 0x17D7);
            backend.updateROMText(absoluteFilename, 0x9, textBoxEB32, 0x17EC);
            backend.updateROMText(absoluteFilename, 0xB, textBoxEB33, 0x1821);
            backend.updateROMText(absoluteFilename, 0xB, textBoxEB34, 0x182F);
            backend.updateROMText(absoluteFilename, 0x6, textBoxEB35, 0x183D);

            backend.updateROMText(absoluteFilename, 0x4, textBoxEB36, 0x1846);
            backend.updateROMText(absoluteFilename, 0x4, textBoxEB37, 0x184D);
            backend.updateROMText(absoluteFilename, 0x5, textBoxEB38, 0x1854);
            backend.updateROMText(absoluteFilename, 0x13, textBoxEB39, 0x185D);
            backend.updateROMText(absoluteFilename, 0x3, textBoxEB40, 0x1554);

            backend.updateROMText(absoluteFilename, 0x2, textBoxEB41, 0x1759);
            backend.updateROMText(absoluteFilename, 0x2, textBoxEB42, 0x1764);
            backend.updateROMText(absoluteFilename, 0x3, textBoxEB43, 0x34DD);

            MessageBox.Show("Updated Text!", "Excitebike", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}