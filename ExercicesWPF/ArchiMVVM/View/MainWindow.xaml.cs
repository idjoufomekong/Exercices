using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Divers.View
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new ViewModel.VMMain();

			//var p = new Personne { Prenom="Jean-Pierre", Nom = "Lebon" };
			//var context = new ValidationContext(p, null, null);
			//var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

			//// Validation de propriété
			////context.MemberName = "FirstName";
			////bool res = Validator.TryValidateProperty(p.FirstName, context,results);

			//// Validation d'instance
			//bool res = Validator.TryValidateObject(p, context, results, true);
		}
	}
}
