using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public string Name {
            get => name;
            set => this.OnNameChange(new NameChangeEventArgs(value));
        }

        public NameChangeEventHandler NameChange { get; set; }

        public Dispatcher()
        {
            this.NameChange = (s, a) =>
            {
                Console.WriteLine($"Dispacher Name changed to {a.Name}");
                this.name = a.Name;
            };
        }

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange.Invoke(this, args);
        }
    }
}
