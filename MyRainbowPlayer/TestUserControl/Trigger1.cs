using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interactivity;

namespace TestUserControl
{
	public class Trigger1 : TriggerBase<DependencyObject>
	{
		protected override void OnAttached()
		{
			base.OnAttached();

			// Insert code that you want to run when the Trigger is attached to an object.
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			// Insert code that you would want run when the Trigger is removed from an object.
		}

		//
		// To invoke any associated Actions when this Trigger gets called, use
		// this.InvokeActions(o) where o is an object that you can pass in as a parameter
		//
	}
}