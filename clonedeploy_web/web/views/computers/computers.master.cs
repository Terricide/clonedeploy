﻿using System;
using BasePages;
using Helpers;
using Models;

namespace views.computers
{
    public partial class ComputerMaster : MasterBaseMaster
    {
        private Computers ComputerBasePage { get; set; }
        public Computer Computer { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComputerBasePage = (Page as Computers);
            Computer = ComputerBasePage.Computer;
            if (Computer == null) //level 2
            {
                Level2.Visible = false;
                Level3.Visible = false;
                actions_left.Visible = false;
            }
            else
            {
                Level1.Visible = false;
                if (Request.QueryString["level"] == "3")
                    Level2.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Delete " + Computer.Name + "?";
            Session["action"] = "delete";
            DisplayConfirm();
        }

        protected void btnDeploy_Click(object sender, EventArgs e)
        {
            Session["action"] = "push";
            lblTitle.Text = "Deploy " + Computer.Name + "?";
            DisplayConfirm();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Session["action"] = "pull";
            lblTitle.Text = "Upload " + Computer.Name + "?";
            DisplayConfirm();
        }

        protected void buttonConfirm_Click(object sender, EventArgs e)
        {
            var action = (string)(Session["action"]);
            Session.Remove("action");
            switch (action)
            {
                case "delete":
                    ComputerBasePage.RequiresAuthorization(Authorizations.DeleteComputer);
                    BLL.Computer.DeleteComputer(Computer.Id);
                    Response.Redirect("~/views/computers/search.aspx");
                    break;
                case "push":
                {
                    ComputerBasePage.RequiresAuthorizationOrManagedComputer(Authorizations.ImageDeployTask, Computer.Id);
                    PageBaseMaster.EndUserMessage = new BLL.Workflows.Unicast(Computer, action).Start();
                }
                    break;
                case "pull":
                {
                    ComputerBasePage.RequiresAuthorizationOrManagedComputer(Authorizations.ImageUploadTask, Computer.Id);
                    PageBaseMaster.EndUserMessage = new BLL.Workflows.Unicast(Computer, action).Start();
                }
                    break;
            }
        }
    }
}