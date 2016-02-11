﻿using System;
using Helpers;
using Models;

public partial class views_global_sysprep_create : BasePages.Global
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        RequiresAuthorization(Authorizations.CreateGlobal);
        var sysPrepTag = new SysprepTag()
        {
            Name = txtName.Text,
            OpeningTag = txtOpenTag.Text,
            ClosingTag = txtCloseTag.Text,
            Description = txtSysprepDesc.Text,
            Contents = txtContent.Text
        };

        var result = BLL.SysprepTag.AddSysprepTag(sysPrepTag);
        if (result.IsValid)
        {
            EndUserMessage = "Successfully Created Sysprep Tag";
            Response.Redirect("~/views/global/sysprep/edit.aspx?cat=sub1&syspreptagid=" + sysPrepTag.Id);
        }
        else
        {
            EndUserMessage = result.Message;
        }
    }
}