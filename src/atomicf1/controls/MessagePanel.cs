using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace atomicf1.controls
{
    [DefaultProperty("Message")]
    [ToolboxData("<{0}:MessagePanel runat=server></{0}:MessagePanel>")]
    public class MessagePanel : Table
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("Success")]
        [ReadOnly(false)]
        [Localizable(true)]
        public string MessageType
        {
            get
            {
                var message = ViewState["MessagePanelMessageType"] as String;
                return string.IsNullOrEmpty(message) ? "Success" : message;
            }
            set
            {
                ViewState["MessagePanelMessageType"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Message
        {
            get
            {
                var message = ViewState["MessagePanelMessage"] as String;
                return string.IsNullOrEmpty(message) ? "" : message;
            }
            set
            {
                ViewState["MessagePanelMessage"] = value;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            // Add attributes to div for the class
            var css = string.Format("MessageContainer {0}", MessageType);
            if (!string.IsNullOrEmpty(CssClass)) css += " " + CssClass;
            writer.AddAttribute(HtmlTextWriterAttribute.Class, css);
            if (string.IsNullOrEmpty(Message))
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            base.RenderContents(writer);
            writer.Write(string.Format("<tbody><tr><td class=\"Message\">{0}</td></tr></tbody>", Message));
            writer.BeginRender();
        }

        public void SetFailure(string message)
        {
            SetMessage("Failure", message);
        }

        public void SetSuccess(string message)
        {
            SetMessage("Success", message);
        }

        public void SetWarning(string message)
        {
            SetMessage("Warning", message);
        }

        public void SetInformation(string message)
        {
            SetMessage("Information", message);
        }

        protected void SetMessage(string type, string message)
        {
            MessageType = type;
            Message = message;
        }

        public bool HasError
        {
            get { return MessageType == "Failure"; }
        }

        public void Clear()
        {
            SetMessage("Success", "");
        }
    }
}