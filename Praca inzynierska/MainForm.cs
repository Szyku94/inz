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
            string title;
            switch(selectedAlgorithm)
            {
                case 0:
                    sortingAlgorithm = new Sort.Bubble();
                    title = "Bubble sort";
                    break;
                case 1:
                    sortingAlgorithm = new Sort.Cocktail();
                    title = "Cocktail sort";
                    break;
                case 2:
                    sortingAlgorithm = new Sort.Comb();
                    title = "Comb sort";
                    break;
                case 3:
                    sortingAlgorithm = new Sort.Counting();
                    title = "Counting sort";
                    break;
                case 4:
                    sortingAlgorithm = new Sort.Heap();
                    title = "Heap sort";
                    break;
                case 5:
                    sortingAlgorithm = new Sort.Insertion();
                    title = "Insertion sort";
                    break;
                case 6:
                    sortingAlgorithm = new Sort.Merge();
                    title = "Merge sort";
                    break;
                case 7:
                    sortingAlgorithm = new Sort.Quick();
                    title = "Quick sort";
                    break;
                case 8:
                    sortingAlgorithm = new Sort.Selection();
                    title = "Selection sort";
                    break;
                case 9:
                    sortingAlgorithm = new Sort.Shell();
                    title = "Shell sort";
                    break;
                default:
                    sortingAlgorithm = new Sort.Bubble();
                    title = "Bubble sort";
                    break;
            }
            int selectedStartingData = SortStartingDataComboBox.SelectedIndex;
            int numberOfElements = (int)SortNumberOfElementsNumericUpDown.Value;
            using (SortWindow win = new SortWindow(800, 600, 
                numberOfElements,sortingAlgorithm, selectedStartingData, title))
            {
                win.Run(30.0);
            }
        }

        private void PathfindingStartButton_Click(object sender, EventArgs e)
        {
            Pathfinding.Pathfinding pathfindingAlgorithm;
            int selectedAlgorithm = PathfindingAlgorithmComboBox.SelectedIndex;
            string title;
            switch (selectedAlgorithm)
            {
                case 0:
                    pathfindingAlgorithm = new Pathfinding.AStar();
                    title = "A*";
                    break;
                case 1:
                    pathfindingAlgorithm = new Pathfinding.BFS();
                    title = "BFS";
                    break;
                case 2:
                    pathfindingAlgorithm = new Pathfinding.BidirectionalBFS();
                    title = "Bidirectional BFS";
                    break;
                case 3:
                    pathfindingAlgorithm = new Pathfinding.Dijkstra();
                    title = "Dijkstra";
                    break;
                default:
                    pathfindingAlgorithm = new Pathfinding.AStar();
                    title = "A*";
                    break;
            }
            using (PathfindingWindow win = new PathfindingWindow(800, 600, pathfindingAlgorithm, title))
            {
                win.Run(30.0);
            }
        }
    }
}
