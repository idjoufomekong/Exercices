using System;

namespace POO
{
	// Décorateur abstrait pour un compte (bancaire ou autre)
	public abstract class DecorateurCompte : Compte
	{
		// Instance du compte qui sera décoré
		public Compte Cpt { get; }

		// Membre de la classe abstraite Compte redéfini
		public override decimal ValeurCompte
		{
			get { return Cpt.ValeurCompte; }
		}

		// L'instance du compte à décorer est passée en paramètre au constructeur
		public DecorateurCompte(Compte compte)
		{
			Cpt = compte;
		}
	}

	// Décorateur concret qui ajoute des fonctionnalités de surveillance à un compte
	// Il fournit ici des seuils d'alerte bas et haut et l'état du compte
	public class Surveillable : DecorateurCompte
	{
		// Le constructeur prend en paramètre le compte
		// et les valeurs de seuils d'alerte
		public Surveillable(Compte compte, decimal seuilBas, decimal seuilHaut) : base(compte)
		{
			SeuilAlerteBas = seuilBas;
			SeuilAlerteHaut = seuilHaut;
		}

		#region Propriétés
		public decimal SeuilAlerteBas { get; }
		public decimal SeuilAlerteHaut { get; }

		public string EtatCompte
		{
			get
			{
				if (ValeurCompte > SeuilAlerteHaut)
					return string.Format("Attention, la valeur du compte ({0}) est > {1} !",
						ValeurCompte, SeuilAlerteHaut);

				else if (ValeurCompte < SeuilAlerteBas)
					return string.Format("Attention, la valeur du compte ({0}) est < {1} !",
						ValeurCompte, SeuilAlerteBas);

				return "Tout va bien !";
			}
		}
		#endregion
	}

	// Autre décorateur concret qui convertit la valeur du compte dans différentes devises
	// On pourrait imaginer ici faire appel à un service web
	// qui renvoie la valeur courante des taux de change entre devises
	public class Convertible : DecorateurCompte
	{
		public Convertible(Compte compte) : base(compte)
		{
		}

		public decimal ValeurEnDollars
		{
			get { return ValeurCompte * 1.1054m; }
		}

		public decimal ValeurEnYuans
		{
			get { return ValeurCompte * 7.3609m; }
		}
	}
}
