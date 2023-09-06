using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Xceed.Editors;
using Xceed.Grid;

namespace TLIConfiguration
{
	public partial class ColorPickerCell : UserControl
	{
		private Color m_cValue;

		public ColorPickerCell()
		{
			InitializeComponent();
		}

		public Color Value
		{
			get { return colorPicker.Color; }
			set { colorPicker.Color = value; }
		}
	}
	
	public class ColorPickerCellEditorManager : Xceed.Grid.Editors.CellEditorManager
	{

		public ColorPickerCellEditorManager()
			: base (new ColorPickerCell(), true, false)
		{
			// Set properties here that affect all instances of the control, regardless of cell contents
			((ColorPickerCell)this.TemplateControl).AutoSize = true;
		}

		protected override void SetControlValueCore(Control control, Cell cell)
		{
			// No need to call base since everything is handled here.
			// Set the value of the cell to the control currently editing the cell, NOT to the TemplateControl.

			// The actual column that contains this cell doesn't really represent any meaningful data, the meaningful
			// data should be in sibling cells in this row
			ColorPickerCell theControl = (ColorPickerCell)control;

			if (cell.Value.ToString() == "")
				cell.Value = Color.Black;

			theControl.Value = (Color)cell.Value;
		}


		protected override CreateControlMode CreateControlMode
		{
			get
			{
				// We override CreateControlMode to return ClonedInstance so that we can 
				// support all the CellEditorDisplayConditions. 
				// 
				// Using a ClonedInstace is only possible when deriving. It is not possible when creating
				// a custom CellEditorManager using events.
				return CreateControlMode.ClonedInstance;
			}
		}


		// Because we have overridden CreateControlMode, we must return a cloned instance
		// of our TemplateControl in the CreateControl method.
		protected override Control CreateControl()
		{
			// If you do not want to do the clone manually, you can use the static CloneControl method.
			return Xceed.UI.ThemedControl.CloneControl(this.TemplateControl);
		}


		protected override object GetControlValueCore(Control control, Cell cell, Type returnDataType)
		{
			// Return the value of the control that is currently editing the cell and not the TemplateControl.
			ColorPickerCell theControl = (ColorPickerCell)control;

			return theControl.Value;
		}


		protected override bool IsInputKeyCore(Control control, Cell cell, Keys keyData)
		{
			// There is no need to override IsInputKeyCore as base will call the underlying control's
			// IsInputKey method automatically.
			return base.IsInputKeyCore(control, cell, keyData);
		}


		protected override bool IsActivationKeyCore(Cell cell, Keys keyData)
		{
			// There is no need to call base as nothing happens there.
			return ((keyData == Keys.Left) || (keyData == Keys.Right));
		}
	}


}
