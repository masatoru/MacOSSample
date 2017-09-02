using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace NSTableViewSample
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        List<Person> PersonList { get; set; } = new List<Person>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //NSTableViewのDataSourceを接続する
            var ds = new PersonDataSource(PersonList);
            tableView.Delegate = new PersonTableDelegate(ds);
            tableView.DataSource = ds;

            // 送信者を指定して購読者を指定する
            NSNotificationCenter.DefaultCenter
                                .AddObserver(NSTableView.SelectionDidChangeNotification,
                                            PersonSelected,tableView);

            PersonList.Add(new Person { Name = "Ichiro", Mail = "ichiro@marines.com" });
            PersonList.Add(new Person { Name = "Darvish", Mail = "darvish@dogers.com" });

            tableView.ReloadData();

            // Do any additional setup after loading the view.
        }

        private void PersonSelected(NSNotification obj){
            var index = tableView.SelectedRow;
            if (index < 0) return;
            var item =PersonList[(int)index];

			using (var alert = new NSAlert())
			{
                alert.MessageText = $"Name={item.Name} Mail={item.Mail}";
				alert.RunSheetModal(null);
				return;
			}

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
