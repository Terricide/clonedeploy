﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BasePages;
using Helpers;

namespace views.images
{
    public partial class ImageSearch : Images
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            PopulateGrid();
        }

        protected void btnHds_Click(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;
            var row = (GridViewRow) control.Parent.Parent;    
            var gvHDs = (GridView) row.FindControl("gvHDs");
            var imageId = ((HiddenField)row.FindControl("HiddenID")).Value;
            var btn = (LinkButton) row.FindControl("btnHDs");

            if (gvHDs.Visible == false)
            {
                var td = row.FindControl("tdHds");
                td.Visible = true;
                gvHDs.Visible = true;

                gvHDs.DataSource = new BLL.ImageSchema(null,"deploy", BLL.Image.GetImage(Convert.ToInt32(imageId))).GetHardDrivesForGridView();
                gvHDs.DataBind();
                btn.Text = "-";
            }
            else
            {
                var td = row.FindControl("tdHds");
                td.Visible = false;
                gvHDs.Visible = false;
                btn.Text = "+";
            }

            foreach (GridViewRow hdrow in gvHDs.Rows)
            {
                var selectedHd = hdrow.RowIndex;
                var lbl = hdrow.FindControl("lblHDSize") as Label;
                if (lbl != null)
                    lbl.Text = BLL.ImageSchema.ImageSizeOnServerForGridView(row.Cells[5].Text, selectedHd.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RequiresAuthorization(Authorizations.DeleteImage);
            var deleteCount = 0;
            foreach (GridViewRow row in gvImages.Rows)
            {
                var cb = (CheckBox) row.FindControl("chkSelector");
                if (cb == null || !cb.Checked) continue;
                var dataKey = gvImages.DataKeys[row.RowIndex];
                if (dataKey == null) continue;
                var image = BLL.Image.GetImage(Convert.ToInt32(dataKey.Value));
                if (BLL.Image.DeleteImage(image).IsValid) deleteCount++;
            }
            EndUserMessage = "Successfully Deleted " + deleteCount + " Images";

            PopulateGrid();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ChkAll(gvImages);
        }

        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            PopulateGrid();
            List<Models.Image> listImages = (List<Models.Image>)gvImages.DataSource;
            switch (e.SortExpression)
            {
                case "Name":
                    listImages = GetSortDirection(e.SortExpression) == "Asc"
                        ? listImages.OrderBy(h => h.Name).ToList()
                        : listImages.OrderByDescending(h => h.Name).ToList();
                    break;
            
            }
            gvImages.DataSource = listImages;
            gvImages.DataBind();
            PopulateSizes();
        }



        protected void PopulateGrid()
        {
            gvImages.DataSource = BLL.Image.SearchImagesForUser(CloneDeployCurrentUser.Id, txtSearch.Text);
            gvImages.DataBind();
            lblTotal.Text = gvImages.Rows.Count + " Result(s) / " + BLL.Image.ImageCountUser(CloneDeployCurrentUser.Id) + " Total Image(s)";
            PopulateSizes();
        }

        protected void PopulateSizes()
        {
            foreach (GridViewRow row in gvImages.Rows)
            {
                var lbl = row.FindControl("lblSize") as Label;
                if (lbl != null) lbl.Text = BLL.ImageSchema.ImageSizeOnServerForGridView(row.Cells[5].Text, "0");
            }
        }

        protected void search_Changed(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}