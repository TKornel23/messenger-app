using api.client;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace client
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<messenger> Messages { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        messenger currentMessage;

        public messenger CurrentMessage
        {
            get { return currentMessage; }
            set
            {

                currentMessage = new messenger()
                {
                    Date = DateTime.Now,
                    Text = value.Text
                };
                OnPropertyChanged();
                (CreateMessageCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateMessageCommand { get; set; }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Messages = new RestCollection<messenger>("http://localhost:46266/", "messenger", "hub");
                CreateMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new messenger()
                    {
                        SenderName = currentMessage.SenderName,
                        Date = currentMessage.Date,
                        Text = currentMessage.Text
                    });
                    ;
                });

            }
        }

    }
}
