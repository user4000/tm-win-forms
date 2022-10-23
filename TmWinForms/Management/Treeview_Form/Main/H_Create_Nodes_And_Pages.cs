﻿using System;
using Telerik.WinControls.UI;
using System.Collections.Generic;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  partial class FormTreeview
  {
    void AddGroupNode(Group group)
    {
      CxNode node = CreateGroupNode(group);
      Form.TvMain.Nodes.Add(node);
    }

    void AddFormNode(TvForm subForm)
    {
      CreateFormNode(subForm);
    }

    CxNode CreateGroupNode(Group group) // NOTE: Create GROUP node // 
    {
      CxNode node = new CxNode();
      node.Text = "  " + group.Text;
      node.SetGroup(group);
      node.ColorDefault = FrameworkSettings.ColorTreeviewGroupNode;
      node.ColorDisabled = FrameworkSettings.ColorTreeviewGroupNodeDisabled;
      node.Font = FrameworkSettings.FontTreeviewGroupNode ?? Form.TvMain.Font;
      node.Image = Form.PicGroup.Image;

      node.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
      node.SetColor();
      group.SetNode(node);

      return node;
    }

    void CreateFormNode(TvForm subForm)
    {
      CxNode node = new CxNode()
      {
        Text = "  " + subForm.PageText,
        Font = FrameworkSettings.FontTreeviewSubFormNode ?? Form.TvMain.Font,
        ColorDefault = FrameworkSettings.ColorTreeviewSubFormNode,
        ColorDisabled = FrameworkSettings.ColorTreeviewSubFormNodeDisabled
      };

      CxNode groupNode = subForm.FormGroup.Node;
      groupNode.Nodes.Add(node);

      subForm.SetNodeForm(node);
      subForm.SetNodeGroup(groupNode);

      Group group = subForm.FormGroup;

      node.SetForm(subForm);
      node.SetGroup(group);

      node.Image = Form.PicItem.Image;

      node.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

      bool expandGroup = true;

      if ((group != null) && (group.CollapseOnExit)) expandGroup = false;

      if (expandGroup) groupNode.Expand();

      node.Enabled = subForm.FlagNodeEnabled;

      node.Visible = subForm.FlagNodeVisible;

      node.SetColor();
    }
  }
}