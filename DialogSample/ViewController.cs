using System;
using System.Text;
using AppKit;
using Foundation;

namespace DialogSample
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        void OpenFileDialog()
        {
            var dlg = NSOpenPanel.OpenPanel;
            // ファイルを選択可能
            dlg.CanChooseFiles = true;
            // ディレクトリを選択可能
            dlg.CanChooseDirectories = true;
            // 複数選択可能
            dlg.AllowsMultipleSelection = true;
            // ファイルの種類
            //dlg.AllowedFileTypes = new string[] { "txt", "html", "md", "css" };

            if (dlg.RunModal() == 1)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"選択したファイル（またはディレクトリ）は{dlg.Urls.Length}つです");
				sb.AppendLine($"");
				foreach(var url in dlg.Urls){
                    sb.AppendLine(url.ToString());
                }
				using (var alert = new NSAlert())
				{
					alert.MessageText = sb.ToString();
					alert.RunSheetModal(null);
					return;
				}

			}
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			BtnOpenDilaog.Activated += (sender, e) =>
			{
				OpenFileDialog();
			};

		}

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
