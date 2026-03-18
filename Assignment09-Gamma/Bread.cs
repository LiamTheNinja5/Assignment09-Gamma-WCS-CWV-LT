using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
    internal class Bread
    {
        public Bread()
        {
        }
            //TODO: FIX bread
            private string breadName;
            private int breadCalories;

            public Bread(string breadName, int breadCalories)
            {
                this.breadName = breadName;
                this.breadCalories = breadCalories;
            }

            public string getName()
            {
                return this.breadName;
            }
            public int getCalories()
            {
                return this.breadCalories;
            }

            public void setName(string breadName)
            {
                this.breadName = breadName;
            }
            public void setCalories(int breadCalories)
            {
                this.breadCalories = breadCalories;
            }

            public override string ToString()
            {
                return this.breadName;
            }
        }
    

}
