using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation.CustomControl
{
	public class CustomDataGridView : DataGridView
	{
		public CustomDataGridView()
		{
			AutoGenerateColumns = true;
			DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			AutoGenerateColumns = true;
			AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			RowHeadersVisible = false;
			ColumnHeadersVisible = false;
			AllowUserToAddRows = false;
			AllowUserToResizeRows = false;
			CellClick += DataGridView_CellClick;
			SelectionChanged += DataGridView_SelectionChanged;
		}

		internal event EventHandler<List<string>> CustomDataGridViewChanged;


		internal void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == NewRowIndex || e.RowIndex < 0) return;
			if (e.ColumnIndex != Columns["dataGridViewDeleteButton"]?.Index) return;
			Rows.RemoveAt(e.RowIndex);
			var lootList = (from DataGridViewRow row in Rows select row.Cells["Value"].Value.ToString()).ToList();
			CustomDataGridViewChanged?.Invoke(this, lootList);
		}

		private void DataGridView_SelectionChanged(object sender, EventArgs e)
		{
			ClearSelection();
		}

		internal void AddDeleteBtn()
		{
			Columns.Add(new DataGridViewButtonColumn
			{
				Name = @"dataGridViewDeleteButton",
				HeaderText = @"Delete",
				Text = @"X",
				UseColumnTextForButtonValue = true
			});
			Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		}

		internal void CreateDataTable(List<string> list)
		{
			DataSource = null;
			Rows.Clear();
			Columns.Clear();

			var dt = new DataTable();
			AddDeleteBtn();
			dt.Columns.Add("Value", typeof(string));
			foreach (var value in list) dt.Rows.Add(value);
			DataSource = dt;
		}

		internal List<string> GetListFromDataTable()
		{
			return (from DataGridViewRow row in Rows select row.Cells["Value"].Value.ToString()).ToList();
		}
	}
}