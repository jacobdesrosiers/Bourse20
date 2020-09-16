using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourse.Outils
{
	// Argument de l'évènement: ce que l'évènement transporte comme information
	public class ChangementImageProprioEventArgs
	{
		public int ProprioId { get; set; }

		public ChangementImageProprioEventArgs(int Id)
		{
			ProprioId = Id;
		}
	}
	// Le prototype que devront respecter les méthodes qui désirent réagir à l'évènement
	public delegate void ChangementImageProprioEventHandler(object sender, ChangementImageProprioEventArgs e);

	class EvenementBourse
	{
		static public event ChangementImageProprioEventHandler ChangementImageProprio;
		static public void OnChangementImageProprio(ChangementImageProprioEventArgs e)
		{
			ChangementImageProprio?.Invoke(null, e);
		}
	}

}
