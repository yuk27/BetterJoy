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
            public ushort[] calib;
            public ushort[] calib2;


            public string GetStringId() {
                return product_id.ToString();
            }

            public Controller(
                                string serial,
                                string type,
                                string calib_max_x,
                                string calib_min_x,
                                string calib_max_y,
                                string calib_min_y,
                                string calib2_max_x,
                                string calib2_min_x,
                                string calib2_max_y,
                                string calib2_min_y
                                ) {
                this.serial = serial;
                product_id = Convert.ToUInt16(type);
                calib = new ushort[] { Convert.ToUInt16(calib_max_x), Convert.ToUInt16(calib_min_x), Convert.ToUInt16(calib_max_y), Convert.ToUInt16(calib_min_y) };
                calib2 = new ushort[] { Convert.ToUInt16(calib2_max_x), Convert.ToUInt16(calib2_min_x), Convert.ToUInt16(calib2_max_y), Convert.ToUInt16(calib2_min_y) };
            }

            public Controller(string serial, ushort type, ushort[] calib, ushort[] calib2) {
                this.serial = serial;
                product_id = type;
                this.calib = calib;
                this.calib2 = calib2;
            }

        }

        List<Controller> Controllers = new List<Controller>();

        public bool Load() {
            if (File.Exists(fileName)) {
                foreach (string line in File.ReadAllLines(fileName).ToList()) {
                    string[] parts = line.Split(' ');
                    Controllers.Add(new Controller(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9]));
                }
                return true;
            }
            return false;
        }

        public void Save() {
            string lines = "";
            foreach (Controller controller in Controllers) {
                lines += controller.serial + " " +
                    controller.GetStringId() + " " +
                    controller.calib[0].ToString() + " " +
                    controller.calib[1].ToString() + " " +
                    controller.calib[2].ToString() + " " +
                    controller.calib[3].ToString() + " " +
                    controller.calib2[0].ToString() + " " +
                    controller.calib2[1].ToString() + " " +
                    controller.calib2[2].ToString() + " " +
                    controller.calib2[3].ToString()
                    + "\n";
            }

            System.IO.File.WriteAllText(fileName, lines);

        }

        public void Add(string serial, ushort type, ushort[] calib, ushort[] calib2) {
            var serialList = Controllers.Where(c => c.serial == serial).ToList(); //Search the serial on the list

            if (serialList.Count() == 0) { // If the controller doesnt exist already add it
                Controllers.Add(new Controller(serial, type, calib, calib2));
            } else { //If the controller already exists modify it
                serialList.ForEach(c => c.product_id = type);
                serialList.ForEach(c => c.calib = calib);
                serialList.ForEach(c => c.calib2 = calib2);
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

        public ushort[] GetCalib(string serial) {
            try {
                var controller = Controllers.First(c => c.serial == serial);
                return controller.calib;
            } catch (InvalidOperationException) {
                return new ushort[] { 0, 9999, 0, 9999 }; // By default return pro controller
            }
        }
        public ushort[] GetCalib2(string serial) {
            try {
                var controller = Controllers.First(c => c.serial == serial);
                return controller.calib2;
            } catch (InvalidOperationException) {
                return new ushort[] { 0, 9999, 0, 9999 }; // By default return pro controller
            }
        }

    }
}
