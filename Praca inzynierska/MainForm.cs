using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_inzynierska
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedAlgorithm = SortAlgorithmComboBox.SelectedIndex;
            Sort.Sort sortingAlgorithm;
            switch(selectedAlgorithm)
            {
                case 0:
                    sortingAlgorithm = new Sort.Bubble();
                    break;
                case 1:
                    sortingAlgorithm = new Sort.Cocktail();
                    break;
                case 2:
                    sortingAlgorithm = new Sort.Comb();
                    break;
                case 3:
                    sortingAlgorithm = new Sort.Counting();
                    break;
                case 4:
                    sortingAlgorithm = new Sort.Heap();
                    break;
                case 5:
                    sortingAlgorithm = new Sort.Insertion();
                    break;
                case 6:
                    sortingAlgorithm = new Sort.Merge();
                    break;
                case 7:
                    sortingAlgorithm = new Sort.Quick();
                    break;
                case 8:
                    sortingAlgorithm = new Sort.Selection();
                    break;
                case 9:
                    sortingAlgorithm = new Sort.Shell();
                    break;
                default:
                    sortingAlgorithm = new Sort.Bubble();
                    break;
            }
            int selectedStartingData = SortStartingDataComboBox.SelectedIndex;
            int numberOfElements = (int)SortNumberOfElementsNumericUpDown.Value;
            using (SortWindow win = new SortWindow(800, 600, 
                numberOfElements,sortingAlgorithm, selectedStartingData))
            {
                win.Run(30.0);
            }
        }

        private void PathfindingStartButton_Click(object sender, EventArgs e)
        {
            Pathfinding.Pathfinding pathfindingAlgorithm;
            int selectedAlgorithm = SortAlgorithmComboBox.SelectedIndex;
            Sort.Sort sortingAlgorithm;
            switch (selectedAlgorithm)
            {
                case 0:
                    pathfindingAlgorithm = new Pathfinding.AStar();
                    break;
                case 1:
                    pathfindingAlgorithm = new Pathfinding.BFS();
                    break;
                case 2:
                    pathfindingAlgorithm = new Pathfinding.BidirectionalBFS();
                    break;
                case 3:
                    pathfindingAlgorithm = new Pathfinding.Dijkstra();
                    break;
                default:
                    pathfindingAlgorithm = new Pathfinding.AStar();
                    break;
            }
            using (PathfindingWindow win = new PathfindingWindow(800, 600, pathfindingAlgorithm))
            {
                win.Run(30.0);
            }
        }
    }
}
