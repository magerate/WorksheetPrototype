/*  
 * Actipro Software's WPF DataGrid Contrib Add-on
 * http://actipro.codeplex.com/
 * 
 * Copyright (c) 2009-2011 Actipro Software LLC. 
 *  
 * This source code is subject to the terms of the Microsoft Public License (Ms-PL). 
 *  
 * Redistribution and use in source and binary forms, with or without modification, 
 * is permitted provided that redistributions of the source code retain the above 
 * copyright notices and this file header. 
 *  
 * Additional copyright notices should be appended to the list above. 
 * 
 * For details, see <http://www.opensource.org/licenses/ms-pl.html>. 
 *  
 * All other rights reserved. 
 *
 */  

using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Windows.Controls.DataGrid.Themes {

	/// <summary>
	/// Represents the base class for a <see cref="ResourceDictionary"/> related to the <c>DataGrid</c> group that uses common resources.
	/// </summary>
	/// <remarks>
	/// If registered correctly with the <see cref="ThemeManager"/>, this <see cref="ResourceDictionary"/> can be swapped
	/// in at the application level automatically when the application's <see cref="ThemeManager.CurrentTheme"/> is changed.
	/// </remarks>
	public abstract class DataGridCommonDictionary : ResourceDictionary
	{

		private static ComponentResourceKey alternatingRowBackgroundBrushKey;
		private static ComponentResourceKey backgroundBrushKey;
		private static ComponentResourceKey cellGridLineBrushKey;
		private static ComponentResourceKey cellBackgroundSelectedBrushKey;
		private static ComponentResourceKey cellBorderSelectedBrushKey;
		private static ComponentResourceKey cellForegroundSelectedBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundHoverBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundHoverSelectedBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundNormalBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundPressedBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundPressedSelectedBrushKey;
		private static ComponentResourceKey columnHeaderBackgroundSelectedBrushKey;
		private static ComponentResourceKey columnHeaderBorderSelectedBrushKey;
		private static ComponentResourceKey columnHeaderForegroundNormalBrushKey;
		private static ComponentResourceKey headerGridLineBrushKey;
		private static ComponentResourceKey rowBackgroundBrushKey;
		private static ComponentResourceKey rowHeaderBackgroundHoverBrushKey;
		private static ComponentResourceKey rowHeaderBackgroundHoverSelectedBrushKey;
		private static ComponentResourceKey rowHeaderBackgroundNormalBrushKey;
		private static ComponentResourceKey rowHeaderBackgroundSelectedBrushKey;
		private static ComponentResourceKey rowHeaderBorderSelectedBrushKey;
		private static ComponentResourceKey rowHeaderForegroundNormalBrushKey;
		private static ComponentResourceKey selectAllButtonBackgroundHoverBrushKey;
		private static ComponentResourceKey selectAllButtonBackgroundNormalBrushKey;
		private static ComponentResourceKey selectAllButtonBackgroundPressedBrushKey;
		private static ComponentResourceKey selectAllButtonBorderHoverBrushKey;
		private static ComponentResourceKey selectAllButtonBorderNormalBrushKey;
		private static ComponentResourceKey selectAllButtonBorderPressedBrushKey;
		private static ComponentResourceKey selectAllButtonForegroundHoverBrushKey;
		private static ComponentResourceKey selectAllButtonForegroundNormalBrushKey;
		private static ComponentResourceKey selectAllButtonForegroundPressedBrushKey;
		private static ComponentResourceKey selectAllButtonGlyphBorderBrushKey;

		private static ComponentResourceKey pinnedGlyphKey;
		private static ComponentResourceKey unpinnedGlyphKey;

		private static ComponentResourceKey dataGridCellStyleKey;
		private static ComponentResourceKey dataGridColumnHeaderStyleKey;
		private static ComponentResourceKey dataGridRowHeaderStyleKey;
		private static ComponentResourceKey dataGridRowStyleKey;
		private static ComponentResourceKey dataGridStyleKey;

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// BRUSH RESOURCE KEYS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to an alternating row background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey AlternatingRowBackgroundBrushKey {
			get {
				if (alternatingRowBackgroundBrushKey == null)
					alternatingRowBackgroundBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "AlternatingRowBackground");
				return alternatingRowBackgroundBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a grid background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey BackgroundBrushKey {
			get {
				if (backgroundBrushKey == null)
					backgroundBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "Background");
				return backgroundBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a cell grid line border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey CellGridLineBrushKey {
			get {
				if (cellGridLineBrushKey == null)
					cellGridLineBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "CellGridLineBrush");
				return cellGridLineBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a cell background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey CellBackgroundSelectedBrushKey {
			get {
				if (cellBackgroundSelectedBrushKey == null)
					cellBackgroundSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "CellBackgroundSelected");
				return cellBackgroundSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a cell border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey CellBorderSelectedBrushKey {
			get {
				if (cellBorderSelectedBrushKey == null)
					cellBorderSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "CellBorderSelected");
				return cellBorderSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a cell foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey CellForegroundSelectedBrushKey {
			get {
				if (cellForegroundSelectedBrushKey == null)
					cellForegroundSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "CellForegroundSelected");
				return cellForegroundSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundHoverBrushKey {
			get {
				if (columnHeaderBackgroundHoverBrushKey == null)
					columnHeaderBackgroundHoverBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundHover");
				return columnHeaderBackgroundHoverBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundHoverSelectedBrushKey {
			get {
				if (columnHeaderBackgroundHoverSelectedBrushKey == null)
					columnHeaderBackgroundHoverSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundHoverSelected");
				return columnHeaderBackgroundHoverSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundNormalBrushKey {
			get {
				if (columnHeaderBackgroundNormalBrushKey == null)
					columnHeaderBackgroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundNormal");
				return columnHeaderBackgroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundPressedBrushKey {
			get {
				if (columnHeaderBackgroundPressedBrushKey == null)
					columnHeaderBackgroundPressedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundPressed");
				return columnHeaderBackgroundPressedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundPressedSelectedBrushKey {
			get {
				if (columnHeaderBackgroundPressedSelectedBrushKey == null)
					columnHeaderBackgroundPressedSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundPressedSelected");
				return columnHeaderBackgroundPressedSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBackgroundSelectedBrushKey {
			get {
				if (columnHeaderBackgroundSelectedBrushKey == null)
					columnHeaderBackgroundSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBackgroundSelected");
				return columnHeaderBackgroundSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderBorderSelectedBrushKey {
			get {
				if (columnHeaderBorderSelectedBrushKey == null)
					columnHeaderBorderSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderBorderSelected");
				return columnHeaderBorderSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a column header foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey ColumnHeaderForegroundNormalBrushKey {
			get {
				if (columnHeaderForegroundNormalBrushKey == null)
					columnHeaderForegroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "ColumnHeaderForegroundNormal");
				return columnHeaderForegroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a header grid line border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey HeaderGridLineBrushKey {
			get {
				if (headerGridLineBrushKey == null)
					headerGridLineBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "HeaderGridLineBrush");
				return headerGridLineBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowBackgroundBrushKey {
			get {
				if (rowBackgroundBrushKey == null)
					rowBackgroundBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowBackground");
				return rowBackgroundBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderBackgroundHoverBrushKey {
			get {
				if (rowHeaderBackgroundHoverBrushKey == null)
					rowHeaderBackgroundHoverBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderBackgroundHover");
				return rowHeaderBackgroundHoverBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderBackgroundHoverSelectedBrushKey {
			get {
				if (rowHeaderBackgroundHoverSelectedBrushKey == null)
					rowHeaderBackgroundHoverSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderBackgroundHoverSelected");
				return rowHeaderBackgroundHoverSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderBackgroundNormalBrushKey {
			get {
				if (rowHeaderBackgroundNormalBrushKey == null)
					rowHeaderBackgroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderBackgroundNormal");
				return rowHeaderBackgroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderBackgroundSelectedBrushKey {
			get {
				if (rowHeaderBackgroundSelectedBrushKey == null)
					rowHeaderBackgroundSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderBackgroundSelected");
				return rowHeaderBackgroundSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderBorderSelectedBrushKey {
			get {
				if (rowHeaderBorderSelectedBrushKey == null)
					rowHeaderBorderSelectedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderBorderSelected");
				return rowHeaderBorderSelectedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a row header foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey RowHeaderForegroundNormalBrushKey {
			get {
				if (rowHeaderForegroundNormalBrushKey == null)
					rowHeaderForegroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "RowHeaderForegroundNormal");
				return rowHeaderForegroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBackgroundHoverBrushKey {
			get {
				if (selectAllButtonBackgroundHoverBrushKey == null)
					selectAllButtonBackgroundHoverBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBackgroundHover");
				return selectAllButtonBackgroundHoverBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBackgroundNormalBrushKey {
			get {
				if (selectAllButtonBackgroundNormalBrushKey == null)
					selectAllButtonBackgroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBackgroundNormal");
				return selectAllButtonBackgroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button background. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBackgroundPressedBrushKey {
			get {
				if (selectAllButtonBackgroundPressedBrushKey == null)
					selectAllButtonBackgroundPressedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBackgroundPressed");
				return selectAllButtonBackgroundPressedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBorderHoverBrushKey {
			get {
				if (selectAllButtonBorderHoverBrushKey == null)
					selectAllButtonBorderHoverBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBorderHover");
				return selectAllButtonBorderHoverBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBorderNormalBrushKey {
			get {
				if (selectAllButtonBorderNormalBrushKey == null)
					selectAllButtonBorderNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBorderNormal");
				return selectAllButtonBorderNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonBorderPressedBrushKey {
			get {
				if (selectAllButtonBorderPressedBrushKey == null)
					selectAllButtonBorderPressedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonBorderPressed");
				return selectAllButtonBorderPressedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonForegroundHoverBrushKey {
			get {
				if (selectAllButtonForegroundHoverBrushKey == null)
					selectAllButtonForegroundHoverBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonForegroundHover");
				return selectAllButtonForegroundHoverBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonForegroundNormalBrushKey {
			get {
				if (selectAllButtonForegroundNormalBrushKey == null)
					selectAllButtonForegroundNormalBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonForegroundNormal");
				return selectAllButtonForegroundNormalBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button foreground. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonForegroundPressedBrushKey {
			get {
				if (selectAllButtonForegroundPressedBrushKey == null)
					selectAllButtonForegroundPressedBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonForegroundPressed");
				return selectAllButtonForegroundPressedBrushKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Brush"/> that may be applied to a select all button glyph border. 
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey SelectAllButtonGlyphBorderBrushKey {
			get {
				if (selectAllButtonGlyphBorderBrushKey == null)
					selectAllButtonGlyphBorderBrushKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "SelectAllButtonGlyphBorderBrushKey");
				return selectAllButtonGlyphBorderBrushKey;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// GLYPH RESOURCE KEYS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a pinned glyph.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey PinnedGlyphKey {
			get {
				if (pinnedGlyphKey == null)
					pinnedGlyphKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "PinnedGlyph");
				return pinnedGlyphKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a unpinned glyph.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey UnpinnedGlyphKey {
			get {
				if (unpinnedGlyphKey == null)
					unpinnedGlyphKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "UnpinnedGlyph");
				return unpinnedGlyphKey;
			}
		}

		/////////////////////////////////////////////////////////////////////////////////////////////////////
		// STYLE RESOURCE KEYS
		/////////////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Style"/> that may be applied to applied to a <see cref="DataGridCell"/>.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey DataGridCellStyleKey {
			get {
				if (dataGridCellStyleKey == null)
					dataGridCellStyleKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "DataGridCellStyle");
				return dataGridCellStyleKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Style"/> that may be applied to applied to a <see cref="DataGridColumnHeader"/>.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey DataGridColumnHeaderStyleKey {
			get {
				if (dataGridColumnHeaderStyleKey == null)
					dataGridColumnHeaderStyleKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "DataGridColumnHeaderStyle");
				return dataGridColumnHeaderStyleKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Style"/> that may be applied to applied to a <see cref="DataGridRowHeader"/>.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey DataGridRowHeaderStyleKey {
			get {
				if (dataGridRowHeaderStyleKey == null)
					dataGridRowHeaderStyleKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "DataGridRowHeaderStyle");
				return dataGridRowHeaderStyleKey;
			}
		}

		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Style"/> that may be applied to applied to a <see cref="DataGridRow"/>.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey DataGridRowStyleKey {
			get {
				if (dataGridRowStyleKey == null)
					dataGridRowStyleKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "DataGridRowStyle");
				return dataGridRowStyleKey;
			}
		}
	
		/// <summary>
		/// Gets the <see cref="ResourceKey"/> for a <see cref="Style"/> that may be applied to applied to a <see cref="DataGridControl"/>.
		/// </summary>
		/// <value>A resource key.</value>
		public static ResourceKey DataGridStyleKey {
			get {
				if (dataGridStyleKey == null)
					dataGridStyleKey = new ComponentResourceKey(typeof(System.Windows.Controls.DataGrid), "DataGridStyle");
				return dataGridStyleKey;
			}
		}
	}
}

