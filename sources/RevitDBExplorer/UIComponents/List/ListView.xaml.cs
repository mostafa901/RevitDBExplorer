﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using RevitDBExplorer.Domain.DataModel;
using RevitDBExplorer.Domain.DataModel.ValueViewModels.Base;

// (c) Revit Database Explorer https://github.com/NeVeSpl/RevitDBExplorer/blob/main/license.md

namespace RevitDBExplorer.UIComponents.List
{
    public partial class ListView : UserControl
    {  
        public ListView()
        {
            InitializeComponent();           
        }

        private void ContextMenuForGroup_Copy_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = e.Source as MenuItem;
            var menu = menuItem.Parent as ContextMenu;
            var item = menu.PlacementTarget as GroupItem;
            var content = item.Content as CollectionViewGroup;

            Clipboard.SetDataObject(content?.Name);
        }
           
        

        private Point? _initialMousePosition  = null;

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {           
            _initialMousePosition = e.GetPosition(this);
            base.OnPreviewMouseDown(e);
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);

            if (e.LeftButton == MouseButtonState.Pressed && _initialMousePosition.HasValue)
            {
                var movedDistance = (_initialMousePosition.Value - e.GetPosition(this)).Length;
                if (movedDistance < 7) return;

                string textValue = "";
                var item = Mouse.DirectlyOver as FrameworkElement;

                if (item?.DataContext is SnoopableMember snoopableMember)
                {
                    var isNameColumn = item.GetParent(x => string.Equals(x.Tag, "NameColumn")) != null;
                    if (isNameColumn)
                    {
                        textValue = snoopableMember.Name;
                    }
                    else
                    {
                        if (snoopableMember.ValueViewModel is IValuePresenter presenter)
                        {
                            textValue = presenter.Label;
                        }
                    }
                }
                else
                {
                    if (e.OriginalSource is TextBlock textBlock)
                    {
                        textValue = textBlock.Text;
                    }

                    if (e.OriginalSource is Run run)
                    {
                        textValue = run.Text;
                    }
                }

                if (string.IsNullOrWhiteSpace(textValue)) return;

                var bracketIndex = textValue.IndexOf('(');
                if (bracketIndex > 0)
                {
                    textValue = textValue.Substring(0, bracketIndex).Trim();
                }

                if (string.IsNullOrWhiteSpace(textValue)) return;

                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, textValue);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                _initialMousePosition = null;

                e.Handled = false;
            }
        }
    }
}