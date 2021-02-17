using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace Week6Project
{
    public class toDoTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        private string _task;// backing field 
        [MaxLength(255)]
        public string task
        {
            get { return _task; }
            set
            {
                if (value == _task)
                    return;
                _task = value;
       
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(task)));
                }
            }
        }

        public bool isUrgent { set; get; }
      
        public string taskImage {
            get {
                if (isUrgent)
                    return "https://media.istockphoto.com/vectors/checklist-rejected-red-icon-clipboard-with-failed-task-symbol-vector-vector-id1022118518";
                else
                    return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCWz-5GGIH1OHiJ7jkOO7_ebsWStneN6fDxw&usqp=CAU";

            }


            set { }
           }

    }


    }

