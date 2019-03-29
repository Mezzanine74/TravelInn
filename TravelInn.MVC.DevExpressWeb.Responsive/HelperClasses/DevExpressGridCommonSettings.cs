using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;

namespace TravelInn.MVC.DevExpressWeb.Responsive.HelperClasses
{
    public static class DevExpressGridCommonSettings
    {
        public static void Set(GridViewSettings settings)
        {
            settings.Settings.ShowStatusBar = GridViewStatusBarMode.Hidden;

            settings.SettingsBehavior.ConfirmDelete = true;

            settings.CommandColumn.Visible = true;
            settings.CommandColumn.Caption = " ";
            settings.CommandColumn.ShowNewButton = false;
            settings.CommandColumn.ShowEditButton = true;
            settings.CommandColumn.ShowDeleteButton = true;
            settings.CommandColumn.ShowNewButtonInHeader = true;
            settings.SettingsEditing.NewItemRowPosition = GridViewNewItemRowPosition.Top;
            settings.KeyFieldName = "Id";

            settings.SettingsPager.Visible = true;
            settings.SettingsPager.PageSize = Int32.MaxValue;
            settings.Settings.ShowGroupPanel = false;
            settings.Settings.ShowFilterRow = false;
            settings.SettingsBehavior.AllowSelectByRowClick = false;

            settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.Control;
            settings.SettingsBehavior.AllowEllipsisInText = true;

            settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off;
            settings.SettingsAdaptivity.AdaptiveColumnPosition = GridViewAdaptiveColumnPosition.Right;
            settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 1;
            settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = false;
            settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 0;


        }

    }
}