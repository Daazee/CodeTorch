﻿using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CodeTorch.Web.Data;
using CodeTorch.Core;
using System.Drawing;
namespace CodeTorch.Web.FieldTemplates
{
    public class CheckBox : BaseFieldTemplate
    {
        protected System.Web.UI.WebControls.CheckBox ctrl;

        protected override void CreateChildControls()
        {
            ctrl = new System.Web.UI.WebControls.CheckBox();
            ctrl.ID = "ctrl";
            Controls.Add(ctrl);
        }

        CheckBoxControl _Me = null;
        public CheckBoxControl Me
        {
            get
            {
                if (_Me == null)
                {
                    _Me = (CheckBoxControl)this.Widget;
                }
                return _Me;
            }
        }

        public override string Value
        {
            get
            {
                string retVal = Convert.ToString(ctrl.Checked);

                string CheckedValue = Me.CheckedValue;
                string UncheckedValue = Me.UncheckedValue;

                if (ctrl.Checked)
                {
                    if ((CheckedValue != null) && (CheckedValue.Trim() != String.Empty))
                    {
                        retVal = CheckedValue;
                    }
                }
                else
                {
                    if ((UncheckedValue != null) && (UncheckedValue.Trim() != String.Empty))
                    {
                        retVal = UncheckedValue;
                    }
                }

                return retVal;
            }
            set
            {
                string retVal = Convert.ToString(value);
                string CheckedValue = Me.CheckedValue;
                string UncheckedValue = Me.UncheckedValue;


                if
                    (
                        (retVal.ToLower() == true.ToString().ToLower()) ||
                        (retVal.ToLower() == false.ToString().ToLower())
                    )
                {
                    ctrl.Checked = Convert.ToBoolean(retVal);
                }
                else
                {
                    if ((CheckedValue != null) && (CheckedValue.Trim() != String.Empty))
                    {
                        if (retVal.ToLower() == CheckedValue.ToLower())
                        {
                            ctrl.Checked = true;
                        }
                    }


                    if ((UncheckedValue != null) && (UncheckedValue.Trim() != String.Empty))
                    {
                        if (retVal.ToLower() == UncheckedValue.ToLower())
                        {
                            ctrl.Checked = false;
                        }
                    }
                }

                
            }
        }

        

        public override void InitControl(object sender, EventArgs e)
        {
            base.InitControl(sender, e);

            try
            {
                if (!String.IsNullOrEmpty(Me.Width))
                {
                    ctrl.Width = new Unit(Me.Width);
                }

                if (!String.IsNullOrEmpty(Me.CssClass))
                {
                    ctrl.InputAttributes["class"] = Me.CssClass;
                }

                if (!String.IsNullOrEmpty(Me.SkinID))
                {
                    ctrl.SkinID = Me.SkinID;
                }

                ctrl.Text = Me.Text;

            }
            catch (Exception ex)
            {
                string ErrorMessageFormat = "ERROR - {0} - Control {1} ({2} - {3})";
                string ErrorMessages = String.Format(ErrorMessageFormat, ex.Message, this.ControlID, Me.Type, this.ID);

                this.ctrl.Text = ErrorMessages;
                this.ctrl.BackColor = Color.Red;

            }
        }

       
    }
}
