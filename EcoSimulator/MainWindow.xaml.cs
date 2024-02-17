using EcoSimulator.Controllers;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace EcoSimulator
{
    public partial class MainWindow : Window
    {
        private Valley NewVall = new(rows, cols);
        private const int rows = 39;
        private const int cols = 24;

        public MainWindow()
        {
            InitializeComponent();
            NewVall.Initialize(60, 60, 10);
            Simulate(30);
        }
        private async Task Simulate(int iterationsNumb)
        {
            for (int i = 0; i < iterationsNumb; i++)
            {
                NewVall.UpdateValley();
                VisualizeSimulation(i + 1);
                await Task.Delay(200);
            }
        }

        private void VisualizeSimulation(int iteration)
        {
            simulation.Children.Clear();
            controlPanel.Children.Clear();
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    simulation.Children.Add(Visualizer.Visualize(NewVall.GetCell(x, y, Constants.WorldLevel.Plants), x, y, Constants.WorldLevel.Plants));
                    simulation.Children.Add(Visualizer.Visualize(NewVall.GetCell(x, y, Constants.WorldLevel.Animals), x, y, Constants.WorldLevel.Animals));
                }
            }
            TextBlock textBlock = new()
            {
                Text = $"Steep: {iteration}",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = System.Windows.Media.Brushes.Black
            };
            controlPanel.Children.Add(textBlock);
        }
    }
}
