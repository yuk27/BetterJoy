using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BetterJoyForCemu {
    class Selector3rdPartyType {
        private const string fileName = "3rdpartyList.dat";

        class Controller {
            public string serial;
            public ushort product_id;

            public string GetStringId() {
                return product_id.ToString();
            }

            public Controller(string serial, string type) {
                this.serial = serial;
                product_id = Convert.ToUInt16(type);
            }

            public Controller(string serial, ushort type) {
                this.serial = serial;
                product_id = type;
            }

        }

        List<Controller> Controllers = new List<Controller>();

        public bool Load() {
            if (File.Exists(fileName)) {
                foreach (string line in File.ReadAllLines(fileName).ToList()) {
                    string[] parts = line.Split(' ');
                    Controllers.Add(new Controller(parts[0], parts[1]));
                }
                return true;
            }
            return false;
        }

        public void Save() {
            string lines = "";
            foreach (Controller controller in Controllers) {
                lines += controller.serial + " " + controller.GetStringId() + "\n";
            }

            System.IO.File.WriteAllText(fileName, lines);

        }

        public void Add(string serial, ushort type) {
            var serialList = Controllers.Where(c => c.serial == serial).ToList(); //Search the serial on the list

            if (serialList.Count() == 0) { // If the controller doesnt exist already add it
                Controllers.Add(new Controller(serial, type));
            } else { //If the controller already exists modify it
                Controllers.ForEach(c => c.product_id = type);
            }
        }

        public ushort GetProductId(string serial) {

            try {
                var controller = Controllers.First(c => c.serial == serial);
                return controller.product_id;
            } catch (InvalidOperationException) {
                return 0x2009; // By default return pro controller
            }
        }

    }
}
