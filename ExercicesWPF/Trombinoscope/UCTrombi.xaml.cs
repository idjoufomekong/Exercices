using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for UCTrombi.xaml
    /// </summary>
    public partial class UCTrombi : UserControl
    {
        private List<ImageSource> _listPhotos;
        public UCTrombi()
        {
            InitializeComponent();
            _listPhotos = DAL.GetPictures();
            foreach (var a in _listPhotos)
            {
                Image photo = new Image();
                photo.Source = a;
                photo.Width = 200;
                lbPhotos.Items.Add(photo);
            }
        }
    }
}
