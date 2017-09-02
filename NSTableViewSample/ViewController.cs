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

            PersonList.Add(new Person { Name = "Ichiro", Mail = "ichiro@marines.com" });
            PersonList.Add(new Person { Name = "Darvish", Mail = "darvish@dogers.com" });

            tableView.ReloadData();

            // Do any additional setup after loading the view.
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
