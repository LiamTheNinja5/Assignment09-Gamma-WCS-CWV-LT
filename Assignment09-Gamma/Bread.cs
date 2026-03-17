using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment09_Gamma
{
    internal class Bread
{
    public class bread
    {
        private string breadName;
        private int breadCalories;

        public bread(string breadName, int breadCalories)
        {
            this.breadName = breadName;
            this.breadCalories = breadCalories;
        }

        public string GetBreadName()
        {
            return this.breadName;
        }
        public int GetBreadCalories()
        {
            return this.breadCalories;
        }

        public void SetBreadName(string breadName)
        {
            this.breadName = breadName;
        }
        public void SetBreadCalories(int breadCalories)
        {
            this.breadCalories = breadCalories;
        }

        public override string ToString()
        {
            return this.breadName;
        }
    }
}

}
