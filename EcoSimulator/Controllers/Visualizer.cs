using EcoSimulator.Organisms.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace EcoSimulator.Controllers
{
    static class Visualizer
    {
        private static Dictionary<Type, List<BitmapImage>> Assets = new Dictionary<Type, List<BitmapImage>>()
        {
            { typeof(Carrot), new List<BitmapImage> { new BitmapImage(new Uri("Assets/Carrot.png", UriKind.Relative)), new BitmapImage(new Uri("Assets/Seed.png", UriKind.Relative)) } },
            { typeof(Fox), new List<BitmapImage> { new BitmapImage(new Uri("Assets/Fox.png", UriKind.Relative)) } },
            { typeof(Rabbit), new List<BitmapImage> { new BitmapImage(new Uri("Assets/Rabbit.png", UriKind.Relative)) } },
            { typeof(Cell), new List<BitmapImage> { new BitmapImage(new Uri("Assets/Dirt.png", UriKind.Relative)) } }
        };
        public static Image Visualize(Cell? cell,int x, int y, int z)
        {
            Image image = new()
            {
                Width = Constants.ImageSize,
                Height = Constants.ImageSize,
            };
            Canvas.SetLeft(image, x * Constants.ImageSize);
            Canvas.SetTop(image, y * Constants.ImageSize);

            if (z == Constants.WorldLevel.Plants)
            {
                if(cell is not Carrot carrot)
                {
                    image.Source = Assets[typeof(Cell)][0];
                }
                else
                {
                    if (carrot.Seed)
                    {
                        image.Source = Assets[typeof(Carrot)][1];
                    }
                    else
                    {
                        image.Source = Assets[typeof(Carrot)][0];
                    }
                }
            }
            else
            {
                if(cell is null)
                {
                    image.Source = null; 
                }
                else
                {
                    image.Source = Assets[typeof(Rabbit)][0];
                }
            }
            return image;
        }
    }
}
