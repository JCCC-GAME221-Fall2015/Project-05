using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04_Map_Maker {
    public partial class Form1 : Form {
        #region fields

        Node[] nodes = new Node[19];
        int activeNum = 0;
        string worldName = "world";

        #endregion

        public Form1() {
            InitializeComponent();

            for (int i = 0; i < 19; i++) {
                nodes[i] = new Node();
            }

            radioButtonSwitch1.Checked = true;
            ChangeFields(0);

            nameBox.Text = worldName;
        }   

        #region menu strip

        void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            //create about window
            AboutBox about = new AboutBox();
            about.Show();
        }

        void newToolStripMenuItem_Click(object sender, EventArgs e) {
            worldName = "world";
            nameBox.Text = worldName;

            for (int i = 0; i < nodes.Length; i++) {
                nodes[i] = new Node();
            }

            radioButtonSwitch1.Checked = true;
            ChangeFields( 0 );
        }

        void openToolStripMenuItem_Click(object sender, EventArgs e) {
            //ImportNodes();
        }

        void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            ExportNodes();
        }

        #endregion

        #region Value Handlers

        private void nameBox_TextChanged( object sender, EventArgs e ) {
            worldName = nameBox.Text;
        }

        void typeBox_SelectedIndexChanged(object sender, EventArgs e) {
            nodes[activeNum].Type = (NodeType) typeBox.SelectedIndex;
        }

        void activationBox_ValueChanged(object sender, EventArgs e) {
            nodes[activeNum].Activation = (int) activationBox.Value;
            Console.WriteLine($"active {activeNum} activtion num {nodes[activeNum].Activation}");
        }

        void countBox_ValueChanged(object sender, EventArgs e) {
            if (RadioButtonSwitch.Active == activeNum) {
                nodes[RadioButtonSwitch.Active].Count = (int) countBox.Value;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButtonSwitch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void radioButtonSwitch_CheckedChanged(object sender, EventArgs e) {
            //RadioButtonSwitch me = (RadioButtonSwitch)sender;
            //Console.Write("Am I checked: " + me.Checked + " I am number: " + me.ID);

            //tiffany
            foreach (Control control in this.groupBox1.Controls) {
                if (control is RadioButtonSwitch) {
                    RadioButtonSwitch radio = control as RadioButtonSwitch;
                    if (radio.Checked) {
                        // Console.WriteLine("Pulling the button that is clicked");
                        // Console.WriteLine(radio.ID);
                        activeNum = radio.ID;
                        ChangeFields(activeNum);
                    }
                }
            }
        }

        /// <summary>
        /// Changes the fields to the properties of the node matching index
        /// </summary>
        /// <param name="index">The index of the node.</param>
        void ChangeFields(int index) {
            //Console.WriteLine("Changing fields..." + index);
            countBox.Value = nodes[index].Count;

            typeBox.Text = nodes[index].Type.ToString();
            activationBox.Value = nodes[index].Activation;
        }

        #endregion

        /// <summary>
        /// Imports the nodes from a user selected file. not yet implemented
        /// </summary>
        void ImportNodes() {
            OpenFileDialog pathDialog = new OpenFileDialog();
            pathDialog.InitialDirectory = "";
            pathDialog.ShowDialog();
            using ( StreamReader sr = new StreamReader( pathDialog.FileName ) ) {

            }
        }

        /// <summary>
        /// Exports the nodes to a file next to the build named using the worldname
        /// </summary>
        void ExportNodes() {
            using ( StreamWriter sw = new StreamWriter( $"{nameBox.Text}.txt" ) ) {
                string fullPath = ( (FileStream)( sw.BaseStream ) ).Name;
                Console.WriteLine( fullPath );

                sw.WriteLine( worldName );
                foreach ( Node node in nodes ) {
                    sw.WriteLine( node.Type + " " + node.Activation + " " + node.Count );
                }
            }
        }

    }

    public enum NodeType {
        Grain,
        Brick,
        Wood,
        Wool
    }

    public class Node {
        //tiffany made class from struct

        public NodeType Type { get; set; }
        public int Activation { get; set; }
        public int Count { get; set; }

        public Node() {
            Type = NodeType.Grain;
            Activation = 1;
            Count = 1;
        }

    }

}