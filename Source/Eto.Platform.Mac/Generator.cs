using System;
using System.Runtime.InteropServices;
using Eto.Drawing;
using Eto.Forms;
using Eto.IO;
using MonoMac.AppKit;
using Eto.Platform.Mac.Drawing;
using MonoMac.CoreGraphics;
using MonoMac.Foundation;
using Eto.Platform.Mac.IO;
using System.Threading;
using SD = System.Drawing;
using Eto.Platform.Mac.Forms.Controls;
using Eto.Platform.Mac.Forms.Printing;
using Eto.Platform.Mac.Forms;
using Eto.Platform.Mac.Forms.Menu;

namespace Eto.Platform.Mac
{
	public class Generator : Eto.Generator
	{ 	
		public override string ID {
			get { return Generators.Mac; }
		}

		public Generator ()
		{
			// Drawing
			Add <IBitmap> (() => new BitmapHandler ());
			Add <IFontFamily> (() => new FontFamilyHandler ());
			Add <IFont> (() => new FontHandler ());
			Add <IFonts> (() => new FontsHandler ());
			Add <IGraphics> (() => new GraphicsHandler ());
			Add <IGraphicsPath> (() => new GraphicsPathHandler ());
			Add <IIcon> (() => new IconHandler ());
			Add <IIndexedBitmap> (() => new IndexedBitmapHandler ());
			Add <IMatrixHandler> (() => new MatrixHandler ());
			
			// Forms.Cells
			Add <ICheckBoxCell> (() => new CheckBoxCellHandler ());
			Add <IComboBoxCell> (() => new ComboBoxCellHandler ());
			Add <IImageTextCell> (() => new ImageTextCellHandler ());
			Add <IImageViewCell> (() => new ImageViewCellHandler ());
			Add <ITextBoxCell> (() => new TextBoxCellHandler ());
			
			// Forms.Controls
			Add <IButton> (() => new ButtonHandler ());
			Add <ICheckBox> (() => new CheckBoxHandler ());
			Add <IComboBox> (() => new ComboBoxHandler ());
			Add <IDateTimePicker> (() => new DateTimePickerHandler ());
			Add <IDrawable> (() => new DrawableHandler ());
			Add <IGridColumn> (() => new GridColumnHandler ());
			Add <IGridView> (() => new GridViewHandler ());
			Add <IGroupBox> (() => new GroupBoxHandler ());
			Add <IImageView> (() => new ImageViewHandler ());
			Add <ILabel> (() => new LabelHandler ());
			Add <IListBox> (() => new ListBoxHandler ());
			Add <INumericUpDown> (() => new NumericUpDownHandler ());
			Add <IPanel> (() => new PanelHandler ());
			Add <IPasswordBox> (() => new PasswordBoxHandler ());
			Add <IProgressBar> (() => new ProgressBarHandler ());
			Add <IRadioButton> (() => new RadioButtonHandler ());
			Add <IScrollable> (() => new ScrollableHandler ());
			Add <ISlider> (() => new SliderHandler ());
			Add <ISplitter> (() => new SplitterHandler ());
			Add <ITabControl> (() => new TabControlHandler ());
			Add <ITabPage> (() => new TabPageHandler ());
			Add <ITextArea> (() => new TextAreaHandler ());
			Add <ITextBox> (() => new TextBoxHandler ());
			Add <ITreeGridView> (() => new TreeGridViewHandler ());
			Add <ITreeView> (() => new TreeViewHandler ());
			Add <IWebView> (() => new WebViewHandler ());
			
			// Forms.Menu
			Add <ICheckMenuItem> (() => new CheckMenuItemHandler ());
			Add <IContextMenu> (() => new ContextMenuHandler ());
			Add <IImageMenuItem> (() => new ImageMenuItemHandler ());
			Add <IMenuBar> (() => new MenuBarHandler ());
			Add <IRadioMenuItem> (() => new RadioMenuItemHandler ());
			Add <ISeparatorMenuItem> (() => new SeparatorMenuItemHandler ());
			
			// Forms.Printing
			Add <IPrintDialog> (() => new PrintDialogHandler ());
			Add <IPrintDocument> (() => new PrintDocumentHandler ());
			Add <IPrintSettings> (() => new PrintSettingsHandler ());
			
			// Forms.ToolBar
			Add <ICheckToolBarButton> (() => new CheckToolBarButtonHandler ());
			Add <ISeparatorToolBarItem> (() => new SeparatorToolBarItemHandler ());
			Add <IToolBarButton> (() => new ToolBarButtonHandler ());
			Add <IToolBar> (() => new ToolBarHandler ());
			
			// Forms
			Add <IApplication> (() => new ApplicationHandler ());
			Add <IClipboard> (() => new ClipboardHandler ());
			Add <IColorDialog> (() => new ColorDialogHandler ());
			Add <ICursor> (() => new CursorHandler ());
			Add <IDialog> (() => new DialogHandler ());
			Add <IDockLayout> (() => new DockLayoutHandler ());
			Add <IFontDialog> (() => new FontDialogHandler ());
			Add <IForm> (() => new FormHandler ());
			Add <IMessageBox> (() => new MessageBoxHandler ());
			Add <IOpenFileDialog> (() => new OpenFileDialogHandler ());
			Add <IPixelLayout> (() => new PixelLayoutHandler ());
			Add <ISaveFileDialog> (() => new SaveFileDialogHandler ());
			Add <ISelectFolderDialog> (() => new SelectFolderDialogHandler ());
			Add <ITableLayout> (() => new TableLayoutHandler ());
			Add <IUITimer> (() => new UITimerHandler ());
			
			// IO
			Add <ISystemIcons> (() => new SystemIconsHandler ());

			// General
			Add <IEtoEnvironment> (() => new EtoEnvironmentHandler ());
		}

		public override IDisposable ThreadStart ()
		{
			return new NSAutoreleasePool ();
		}
        public static RectangleF Convert(System.Drawing.RectangleF rect)
        {
            return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }

		
        public static System.Drawing.RectangleF Convert(RectangleF rect)
        {
            return new System.Drawing.RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }
		
        public static System.Drawing.PointF Convert(PointF point)
        {
            return new System.Drawing.PointF(point.X, point.Y);
        }

        public static PointF Convert(System.Drawing.PointF point)
        {
            return new PointF(point.X, point.Y);
        }
		

        internal static Matrix Convert(
            CGAffineTransform t)
        {
            return new Matrix(
                t.xx,
                t.yx,
                t.xy,
                t.yy,
                t.x0,
                t.y0);
        }

        internal static SD.PointF[] Convert(PointF[] points)
        {
            var result =
                new SD.PointF[points.Length];

            for (var i = 0;
                i < points.Length;
                ++i)
            {
                var p = points[i];
                result[i] =
                    new SD.PointF(p.X, p.Y);
            }

            return result;
        }

        internal static CGAffineTransform Convert(
            Matrix m)
        {
            var e = m.Elements;

            return new CGAffineTransform(
                e[0],
                e[1],
                e[2],
                e[3],
                e[4],
                e[5]);
        }
    }
}
