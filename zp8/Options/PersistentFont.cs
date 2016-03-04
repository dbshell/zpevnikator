using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace zp8
{
    public class FontEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                if (!context.PropertyDescriptor.IsReadOnly)
                {
                    return UITypeEditorEditStyle.Modal;
                }
            }
            return UITypeEditorEditStyle.None;
        }

        [RefreshProperties(RefreshProperties.All)]
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            if (context == null || provider == null || context.Instance == null)
            {
                return base.EditValue(provider, value);
            }
            FontDialog dlg = new FontDialog();
            PersistentFont src = (PersistentFont)value;
            dlg.ShowColor = true;
            dlg.Font = src.ToFont();
            dlg.Color = src.FontColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return PersistentFont.FromFont(dlg.Font, dlg.Color);
            }
            else
            {
                return value;
            }
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            if (context == null || context.Instance == null)
            {
                return base.GetPaintValueSupported(context);
            }
            return true;
        }
        public override void PaintValue(PaintValueEventArgs e)
        {
            if (e.Value != null)
            {
                PersistentFont font = (PersistentFont)e.Value;
                using (Brush color = new SolidBrush(font.FontColor))
                {
                    GraphicsState state = e.Graphics.Save();
                    e.Graphics.FillRectangle(color, e.Bounds);
                    e.Graphics.Restore(state);
                }
            }
            else
            {
                base.PaintValue(e);
            }
        }
    }


    [Editor(typeof(FontEditor), typeof(UITypeEditor))]
    public class PersistentFont
    {
        private static readonly XPdfFontOptions XFontOptions = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
        private String m_fontName = "Arial";
        public String FontName
        {
            get { return m_fontName; }
            set { m_fontName = value; }
        }

        private Single m_fontSize = 10;
        public Single FontSize
        {
            get { return m_fontSize; }
            set { m_fontSize = value; }
        }

        private FontStyle m_fontStyle = FontStyle.Regular;
        public FontStyle FontStyle
        {
            get { return m_fontStyle; }
            set { m_fontStyle = value; }
        }

        private Color m_fontColor = Color.Black;
        [System.Xml.Serialization.XmlIgnore]
        public Color FontColor
        {
            get { return m_fontColor; }
            set { m_fontColor = value; }
        }

        [System.Xml.Serialization.XmlElement("FontColor")]
        [Browsable(false)]
        public string _ColorName
        {
            get { return m_fontColor.Name; }
            set { m_fontColor = Color.FromName(value); }
        }

        //[System.Xml.Serialization.XmlIgnore]
        //[Browsable(false)]
        //public Single FontSizeInPoints
        //{
        //    get { return FontSize / 72.0f * MainForm.MainGraphics.DpiX; }
        //}

        public static PersistentFont FromFont(Font font)
        {
            return FromFont(font, Color.Black);
        }

        public static PersistentFont FromFont(Font font, Color color)
        {
            PersistentFont result = new PersistentFont();
            result.FontName = font.Name;
            result.FontSize = font.Size;
            result.FontStyle = font.Style;
            result.FontColor = color;
            return result;
        }

        public Font ToFont()
        {
            return new Font(FontName, FontSize, FontStyle);
        }

        public XFont ToXFont(float mmky)
        {
            //float worldSize = FontSize * MainForm.MainGraphics.DpiX / 72.0f;
            //float worldSize = FontSize * (mmky / 2.834f) * 96.0f / 72.0f;
            float worldSize = FontSize * (mmky / 2.834f);
            XFont res = new XFont(FontName, worldSize, ToXFontStyle(this), XFontOptions);
            return res;
        }
        //public XFont ToXFont(float mmkx)
        //{
        //    //float worldSize = FontSize * MainForm.MainGraphics.DpiX / 72.0f;
        //    float worldSize = FontSize * MainForm.MainGraphics.DpiX / 72.0f;
        //    XFont res = new XFont(FontName, worldSize, ToXFontStyle(this), XFontOptions);
        //    return res;
        //}
        public bool Bold
        { 
            get { return (m_fontStyle & FontStyle.Bold) == FontStyle.Bold; }
            set { if (value) m_fontStyle |= FontStyle.Bold; else m_fontStyle &= ~FontStyle.Bold; }
        }
        public bool Italic { 
            get { return (m_fontStyle & FontStyle.Italic) == FontStyle.Italic; }
            set { if (value) m_fontStyle |= FontStyle.Italic;else m_fontStyle &= ~FontStyle.Italic; }
        }
        public bool Underline
        {
            get { return (m_fontStyle & FontStyle.Underline) == FontStyle.Underline; }
            set { if (value) m_fontStyle |= FontStyle.Underline; else m_fontStyle &= ~FontStyle.Underline; }
        }
        public bool Strikeout
        {
            get { return (m_fontStyle & FontStyle.Strikeout) == FontStyle.Strikeout; }
            set { if (value) m_fontStyle |= FontStyle.Strikeout; else m_fontStyle &= ~FontStyle.Strikeout; }
        }
        private static XFontStyle ToXFontStyle(PersistentFont font)
        {
            return
              (font.Bold ? XFontStyle.Bold : 0) |
              (font.Italic ? XFontStyle.Italic : 0) |
              (font.Strikeout ? XFontStyle.Strikeout : 0) |
              (font.Underline ? XFontStyle.Underline : 0);
        }

        public string GetTitle()
        {
            string flags = "";
            if (Bold) flags += "B";
            if (Italic) flags += "I";
            if (Strikeout) flags += "S";
            if (Underline) flags += "U";
            return String.Format("{0} {1}pt {2}", FontName, FontSize, flags);
        }

        public override string ToString()
        {
            return GetTitle();
        }
    }
}
